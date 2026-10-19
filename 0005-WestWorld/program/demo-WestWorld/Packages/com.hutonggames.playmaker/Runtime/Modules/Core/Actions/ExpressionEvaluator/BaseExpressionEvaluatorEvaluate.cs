using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.ExpressionEvaluator)]
    [ActionDescription(
        "Evaluates a mathematical expression. Use {VarName} to reference FSM variables.\n" +
        "Supports property paths like {Position.x}, {Velocity.magnitude}, {Owner.transform.position.y}.\n" +
        "Built-ins: {Time.deltaTime}, {Time.time}, {Time.unscaledTime} (braces optional for built-ins).\n" +
        "Supports whitelisted math functions like Abs(...), Sqrt(...), Sin(...).")]
    public abstract class BaseExpressionEvaluatorEvaluate : BaseAction
    {
        [Tooltip("Expression with {VarName} placeholders, e.g., {Health} / {Max} * 100.\n" +
                 "Property paths allowed: {Vector3Var.x}, {TransformVar.position.y}, {BoundsVar.center.x}.")]
        [DisplayOrder(-10), SerializeField, HasVariableNames]
        public StringVar Expression;

        [Tooltip("True if the expression evaluated successfully. Result is 0 if false.")]
        [OptionalField, SerializeField, WriteOnly] 
        protected BoolRef Succeeded;

        // ---------- Compile/cache ----------
        private string _cachedExpressionValue;
        private string _compiledExpr;                    // braces stripped
        private bool _compiled;
        private readonly HashSet<string> _identsToReplace = new(StringComparer.OrdinalIgnoreCase); // identifiers from {…} + built-ins
        protected readonly Dictionary<string, string> NameMap = new(StringComparer.OrdinalIgnoreCase); // ident(lower/ci) -> original Var name

        private static readonly string[] Builtins =
        {
            "Time.deltaTime",
            "Time.time",
            "Time.unscaledTime"
        };

        public override bool CanExecute() => Expression.HasValue();

        /// <summary>Call if you programmatically change Expression.Value at runtime.</summary>
        protected void ResetCache()
        {
            _compiled = false;
            _compiledExpr = null;
            _cachedExpressionValue = null;
            _identsToReplace.Clear();
            NameMap.Clear();
        }

        /// <summary>
        /// Returns the compiled expression, recompiling automatically
        /// if the Expression.Value has changed since last compile.
        /// </summary>
        protected string GetCompiledExpression()
        {
            var currentValue = Expression?.Value ?? string.Empty;

            // Recompile only if not compiled or value changed
            if (!_compiled || !string.Equals(_cachedExpressionValue, currentValue, StringComparison.Ordinal))
            {
                _cachedExpressionValue = currentValue;  // store source for which we compiled
                Compile(currentValue, out _compiledExpr);
                _compiled = true;
            }

            return _compiledExpr ?? string.Empty;
        }

        /// <summary>Evaluate to a number. Sets Succeeded; result = 0 if false.</summary>
        protected bool TryEvaluate(out double result)
        {
            var expr = GetCompiledExpression();
            var resolvedExpr = SubstituteVariables(expr, _identsToReplace, ResolveIdentifier);
            var ok = MathExpressionUtility.TryEvaluate(resolvedExpr, out result);
            Succeeded.Value = ok;
            if (!ok) result = 0.0;
            return ok;
        }
        
        protected virtual double ResolveIdentifier(string ident) => ResolveNumeric(ident);

        // ---------- Compile implementation ----------
        private void Compile(string raw, out string compiled)
        {
            if (raw == null) raw = string.Empty;

            var sb = new StringBuilder(raw.Length);
            var i = 0;

            while (i < raw.Length)
            {
                var open = raw.IndexOf('{', i);
                if (open < 0)
                {
                    sb.Append(raw, i, raw.Length - i);
                    break;
                }

                // Copy literal chunk before '{'
                sb.Append(raw, i, open - i);

                var close = raw.IndexOf('}', open + 1);
                if (close < 0)
                    throw new ArgumentException($"Unmatched '{{' at index {open} in expression: \"{raw}\"");

                var startName = open + 1;
                var lenName = close - startName;
                if (lenName <= 0)
                    throw new ArgumentException($"Empty variable name at index {open} in expression: \"{raw}\"");

                var name = raw.Substring(startName, lenName).Trim();
                if (name.Length == 0)
                    throw new ArgumentException($"Empty variable name at index {open} in expression: \"{raw}\"");
                if (name.IndexOf('{') >= 0 || name.IndexOf('}') >= 0)
                    throw new ArgumentException($"Nested braces in variable at index {open} in expression: \"{raw}\"");

                // Keep dots for property paths; normalize spaces to underscores only
                var ident = name.Replace(' ', '_');

                // Record identifier + case map for FSM lookup
                _identsToReplace.Add(ident);
                NameMap.TryAdd(ident, name);

                sb.Append(ident); // write identifier (without braces)
                i = close + 1;
            }

            // Always allow built-ins even without braces
            foreach (var bi in Builtins)
            {
                _identsToReplace.Add(bi);
                NameMap.TryAdd(bi, bi);
            }

            compiled = sb.ToString();
        }

        // ---------- Resolver / substitution ----------

        /// <summary>
        /// Shared numeric resolver for identifiers (case-insensitive).
        /// Handles built-ins, FSM variables, and property paths like Position.x.
        /// </summary>
        protected double ResolveNumeric(string ident)
        {
            if (string.IsNullOrEmpty(ident))
                return 0.0;

            // Built-ins (case-insensitive; accept dotted)
            switch (ident.ToLowerInvariant())
            {
                case "time.deltatime":     return Time.deltaTime;
                case "time.time":          return Time.time;
                case "time.unscaledtime":  return Time.unscaledTime;
            }

            // Property path? (supports dotted paths e.g., Position.x, Owner.transform.position.y)
            if (ident.IndexOf('.') >= 0)
                return ResolvePropertyPath(ident);

            // Plain FSM variable by case map; fallback to ident if not present
            if (!NameMap.TryGetValue(ident, out var original))
                original = ident;

            var v = Fsm.Variables.FindVariableByName(original);
            if (v == null) return 0.0;

            if (v is BoolVariable b) return b.Value ? 1.0 : 0.0;
            return ConvertNumericOrZero(v.GetValue());
        }

        /// <summary>
        /// Replace only compiled identifiers (plus built-ins) with numeric literals.
        /// Leaves functions intact so the numeric evaluator can process them.
        /// </summary>
        private static string SubstituteVariables(string expr,
                                                  HashSet<string> identsToReplace,
                                                  Func<string, double> resolver)
        {
            var sb = new StringBuilder(expr.Length * 2);
            int i = 0, n = expr.Length;

            static bool IsIdentStart(char c) => char.IsLetter(c) || c == '_';
            static bool IsIdentChar(char c)  => char.IsLetterOrDigit(c) || c == '_' || c == '.';

            while (i < n)
            {
                var c = expr[i];

                if (char.IsWhiteSpace(c)) { sb.Append(c); i++; continue; }

                if (IsIdentStart(c))
                {
                    var start = i; i++;
                    while (i < n && IsIdentChar(expr[i])) i++;
                    var ident = expr.Substring(start, i - start);

                    if (identsToReplace.Contains(ident))
                    {
                        var val = resolver(ident);
                        sb.Append(val.ToString(CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        sb.Append(ident); // function/unknown identifier
                    }
                    continue;
                }

                sb.Append(c);
                i++;
            }

            return sb.ToString();
        }

        // ---------- Property paths (whitelisted, no reflection) ----------

        private double ResolvePropertyPath(string ident)
        {
            // Split path "A.B.C"
            var segments = ident.Split('.');
            if (segments.Length == 0) return 0.0;

            object current = null;

            // Built-ins as first segment (allow Time.*)
            if (segments.Length >= 2 && segments[0].Equals("Time", StringComparison.OrdinalIgnoreCase))
            {
                switch (segments[1].ToLowerInvariant())
                {
                    case "deltatime":     return Time.deltaTime;
                    case "time":          return Time.time;
                    case "unscaledtime":  return Time.unscaledTime;
                }
                return 0.0;
            }

            // Optional: Owner as first segment
            if (segments[0].Equals("Owner", StringComparison.OrdinalIgnoreCase))
            {
                var owner = Fsm?.Owner;
                if (owner == null) return 0.0;
                current = owner; // GameObject
            }
            else
            {
                // FSM variable as first segment
                var head = segments[0];
                if (!NameMap.TryGetValue(head, out var originalHead))
                    originalHead = head;

                var fsmVar = Fsm.Variables.FindVariableByName(originalHead);
                if (fsmVar != null)
                    current = fsmVar.GetValue();
                else
                    return 0.0;
            }

            for (var i = 1; i < segments.Length; i++)
            {
                var seg = segments[i];

                if (current is Vector2 v2)
                {
                    if      (seg.Equals("x", StringComparison.OrdinalIgnoreCase)) { current = (double)v2.x; continue; }
                    else if (seg.Equals("y", StringComparison.OrdinalIgnoreCase)) { current = (double)v2.y; continue; }
                    else if (seg.Equals("magnitude", StringComparison.OrdinalIgnoreCase))   { current = (double)v2.magnitude; continue; }
                    else if (seg.Equals("sqrMagnitude", StringComparison.OrdinalIgnoreCase)){ current = (double)v2.sqrMagnitude; continue; }
                    return 0.0;
                }

                if (current is Vector3 v3)
                {
                    if      (seg.Equals("x", StringComparison.OrdinalIgnoreCase)) { current = (double)v3.x; continue; }
                    else if (seg.Equals("y", StringComparison.OrdinalIgnoreCase)) { current = (double)v3.y; continue; }
                    else if (seg.Equals("z", StringComparison.OrdinalIgnoreCase)) { current = (double)v3.z; continue; }
                    else if (seg.Equals("magnitude", StringComparison.OrdinalIgnoreCase))   { current = (double)v3.magnitude; continue; }
                    else if (seg.Equals("sqrMagnitude", StringComparison.OrdinalIgnoreCase)){ current = (double)v3.sqrMagnitude; continue; }
                    return 0.0;
                }

                if (current is Vector4 v4)
                {
                    if      (seg.Equals("x", StringComparison.OrdinalIgnoreCase)) { current = (double)v4.x; continue; }
                    else if (seg.Equals("y", StringComparison.OrdinalIgnoreCase)) { current = (double)v4.y; continue; }
                    else if (seg.Equals("z", StringComparison.OrdinalIgnoreCase)) { current = (double)v4.z; continue; }
                    else if (seg.Equals("w", StringComparison.OrdinalIgnoreCase)) { current = (double)v4.w; continue; }
                    else if (seg.Equals("magnitude", StringComparison.OrdinalIgnoreCase))   { current = (double)v4.magnitude; continue; }
                    else if (seg.Equals("sqrMagnitude", StringComparison.OrdinalIgnoreCase)){ current = (double)v4.sqrMagnitude; continue; }
                    return 0.0;
                }

                if (current is Color col)
                {
                    if      (seg.Equals("r", StringComparison.OrdinalIgnoreCase)) { current = (double)col.r; continue; }
                    else if (seg.Equals("g", StringComparison.OrdinalIgnoreCase)) { current = (double)col.g; continue; }
                    else if (seg.Equals("b", StringComparison.OrdinalIgnoreCase)) { current = (double)col.b; continue; }
                    else if (seg.Equals("a", StringComparison.OrdinalIgnoreCase)) { current = (double)col.a; continue; }
                    return 0.0;
                }

                if (current is Quaternion q)
                {
                    if      (seg.Equals("x", StringComparison.OrdinalIgnoreCase)) { current = (double)q.x; continue; }
                    else if (seg.Equals("y", StringComparison.OrdinalIgnoreCase)) { current = (double)q.y; continue; }
                    else if (seg.Equals("z", StringComparison.OrdinalIgnoreCase)) { current = (double)q.z; continue; }
                    else if (seg.Equals("w", StringComparison.OrdinalIgnoreCase)) { current = (double)q.w; continue; }
                    else if (seg.Equals("eulerX", StringComparison.OrdinalIgnoreCase)) { current = (double)q.eulerAngles.x; continue; }
                    else if (seg.Equals("eulerY", StringComparison.OrdinalIgnoreCase)) { current = (double)q.eulerAngles.y; continue; }
                    else if (seg.Equals("eulerZ", StringComparison.OrdinalIgnoreCase)) { current = (double)q.eulerAngles.z; continue; }
                    return 0.0;
                }

                if (current is Rect r)
                {
                    if      (seg.Equals("x", StringComparison.OrdinalIgnoreCase)) { current = (double)r.x; continue; }
                    else if (seg.Equals("y", StringComparison.OrdinalIgnoreCase)) { current = (double)r.y; continue; }
                    else if (seg.Equals("width", StringComparison.OrdinalIgnoreCase))  { current = (double)r.width; continue; }
                    else if (seg.Equals("height", StringComparison.OrdinalIgnoreCase)) { current = (double)r.height; continue; }
                    return 0.0;
                }

                if (current is Bounds b)
                {
                    if      (seg.Equals("center", StringComparison.OrdinalIgnoreCase))  { current = b.center; continue; }
                    else if (seg.Equals("size", StringComparison.OrdinalIgnoreCase))    { current = b.size; continue; }
                    else if (seg.Equals("extents", StringComparison.OrdinalIgnoreCase)) { current = b.extents; continue; }
                    // any further path must land on vector components in the next loop
                    return 0.0;
                }

                if (current is Transform t)
                {
                    if      (seg.Equals("position", StringComparison.OrdinalIgnoreCase))        { current = t.position; continue; }
                    else if (seg.Equals("localPosition", StringComparison.OrdinalIgnoreCase))   { current = t.localPosition; continue; }
                    else if (seg.Equals("eulerAngles", StringComparison.OrdinalIgnoreCase))     { current = t.eulerAngles; continue; }
                    else if (seg.Equals("localEulerAngles", StringComparison.OrdinalIgnoreCase)){ current = t.localEulerAngles; continue; }
                    else if (seg.Equals("lossyScale", StringComparison.OrdinalIgnoreCase))      { current = t.lossyScale; continue; }
                    else if (seg.Equals("forward", StringComparison.OrdinalIgnoreCase))         { current = t.forward; continue; }
                    else if (seg.Equals("up", StringComparison.OrdinalIgnoreCase))              { current = t.up; continue; }
                    else if (seg.Equals("right", StringComparison.OrdinalIgnoreCase))           { current = t.right; continue; }
                    else if (seg.Equals("childCount", StringComparison.OrdinalIgnoreCase))      { current = (double)t.childCount; continue; }
                    return 0.0;
                }

                if (current is GameObject go)
                {
                    if (seg.Equals("transform", StringComparison.OrdinalIgnoreCase)) { current = go.transform; continue; }
                    return 0.0;
                }

                // Numeric leaf — if more segments remain, it's invalid
                if (current is int || current is long || current is float || current is double)
                    return 0.0;

                // Bool leaf allowed
                if (current is bool bb)
                {
                    current = bb ? 1.0 : 0.0;
                    if (i < segments.Length - 1) return 0.0; // bool cannot have children
                    continue;
                }

                // Not whitelisted
                return 0.0;
            }

            // Coerce final value to double
            return ConvertNumericOrZero(current);
        }

        private static double ConvertNumericOrZero(object value)
        {
            try
            {
                return value switch
                {
                    null => 0.0,
                    double d => d,
                    float f => f,
                    int i => i,
                    long l => l,
                    bool b => b ? 1.0 : 0.0,
                    Vector2 v2 => v2.magnitude, // sensible fallback if user ended on a vector
                    Vector3 v3 => v3.magnitude,
                    Vector4 v4 => v4.magnitude,
                    Color c => c.grayscale, // fallback for colors
                    _ => 0.0
                };
            }
            catch { return 0.0; }
        }
    }
}
