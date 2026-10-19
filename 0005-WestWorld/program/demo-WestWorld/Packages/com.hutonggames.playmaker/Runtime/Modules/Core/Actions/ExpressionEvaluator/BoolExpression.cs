using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;

namespace HutongGames.PlayMaker
{
#if UNITY_6000_5_OR_NEWER
    [Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
#endif
    public static class BoolExpression
    {
        private const double Eps = 1e-9;
        private static readonly ISet<string> EmptyIdSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private static readonly string[] Builtins = { "Time.deltaTime", "Time.time", "Time.unscaledTime" };

        // =============================================================
        // Public API
        // =============================================================

        public static bool EvaluateWithPlaceholders(
            string rawExpr,
            Func<string, double> numResolver,
            Func<string, string> strResolver = null,
            bool stringEqualsIgnoreCase = true)
        {
            string compiled = CompilePlaceholders(rawExpr, out var identsToReplace);
            return Evaluate(compiled, numResolver, identsToReplace, strResolver, stringEqualsIgnoreCase);
        }

        private static bool Evaluate(
            string expr,
            Func<string, double> numResolver,
            ISet<string> identsToReplace,
            Func<string, string> strResolver = null,
            bool stringEqualsIgnoreCase = true)
        {
            var tokens = Tokenize(expr);
            int i = 0;
            bool val = ParseOr(ref i, tokens, numResolver, identsToReplace ?? EmptyIdSet, strResolver,
                stringEqualsIgnoreCase);
            if (i != tokens.Count) throw new ArgumentException("Unexpected tokens at end of expression.");
            return val;
        }

        // =============================================================
        // Recursive descent parser
        // =============================================================

        // Logical OR: left-associative fold of AND groups separated by ||
        //
        // Example:  a || b || c  →  ((a || b) || c)
        // Always parses and consumes the RHS operand even if LHS is already true,
        // so we never leave unconsumed tokens (which would trigger
        // "Unexpected tokens at end of expression").
        private static bool ParseOr(ref int i, List<string> t,
            Func<string, double> num, ISet<string> ids, Func<string, string> str, bool ci)
        {
            bool left = ParseAnd(ref i, t, num, ids, str, ci);

            while (i < t.Count && t[i] == "||")
            {
                i++; // consume '||'
                bool right = ParseAnd(ref i, t, num, ids, str, ci);
                left = left || right;
            }

            return left;
        }

        // Logical AND: left-associative fold of NOT/comparison groups separated by &&
        //
        // Example:  a && b && c  →  ((a && b) && c)
        // This version always parses the RHS even if LHS is false,
        // ensuring we consume all tokens and keeping i == tokens.Count at the end.
        private static bool ParseAnd(ref int i, List<string> t,
            Func<string, double> num, ISet<string> ids, Func<string, string> str, bool ci)
        {
            bool left = ParseNot(ref i, t, num, ids, str, ci);

            while (i < t.Count && t[i] == "&&")
            {
                i++; // consume '&&'
                bool right = ParseNot(ref i, t, num, ids, str, ci);
                left = left && right;
            }

            return left;
        }


        private static bool ParseNot(ref int i, List<string> t,
            Func<string, double> num, ISet<string> ids, Func<string, string> str, bool ci)
        {
            bool neg = false;
            while (i < t.Count && t[i] == "!")
            {
                neg = !neg;
                i++;
            }

            bool v = ParseComparison(ref i, t, num, ids, str, ci);
            return neg ? !v : v;
        }

        private struct Value
        {
            public bool IsString;
            public string Str;
            public double Num;
            public bool NumOk;
        }


        // Comparison or literal truth evaluation.
        //
        // Handles parentheses, numeric and string comparisons, and bare literals.
        // Returns true/false but *never* returns early when the next token
        // is a logical operator (&& or ||) — that’s handled by the caller.
        //
        // Example:
        //   "1 < 2"   → true
        //   "0"       → false (numeric zero is false)
        //   "\"abc\"" → true  (non-empty string is true)
        private static bool ParseComparison(ref int i, List<string> t,
            Func<string, double> num, ISet<string> ids, Func<string, string> str, bool ci)
        {
            // Handle subexpressions in parentheses: ( ... )
            if (i < t.Count && t[i] == "(")
            {
                i++; // consume '('
                bool inner = ParseOr(ref i, t, num, ids, str, ci);
                Expect(t, ref i, ")"); // must find closing ')'
                return inner;
            }

            // Read left operand (identifier, number, or literal)
            string leftExpr = ReadOperand(ref i, t);

            // If next token starts a logical expression or we hit end/closing parenthesis,
            // interpret the leftExpr directly as a truthy/falsy value.
            if (i >= t.Count || IsLogical(t[i]) || t[i] == ")")
            {
                var L = EvalValue(leftExpr, num, ids, str);
                if (L.IsString) return !string.IsNullOrEmpty(L.Str);
                return L.NumOk && Math.Abs(L.Num) > Eps;
            }

            // Otherwise, read comparator and RHS operand.
            string op = t[i++];
            string rightExpr = ReadOperand(ref i, t);

            var A = EvalValue(leftExpr, num, ids, str);
            var B = EvalValue(rightExpr, num, ids, str);

            // String comparison path (==, !=, ===, !==, etc.)
            if (A.IsString || B.IsString || IsQuoted(leftExpr) || IsQuoted(rightExpr))
                return EvaluateStringComparison(op, A, B, ci);

            // Numeric comparison path.
            if (!A.NumOk || !B.NumOk) return false;

            return op switch
            {
                ">"  => A.Num >  B.Num,
                "<"  => A.Num <  B.Num,
                ">=" => A.Num >= B.Num,
                "<=" => A.Num <= B.Num,
                "==" => Math.Abs(A.Num - B.Num) < Eps,
                "!=" => Math.Abs(A.Num - B.Num) >= Eps,
                "===" => Math.Abs(A.Num - B.Num) < Eps,
                "!==" => Math.Abs(A.Num - B.Num) >= Eps,
                _ => false
            };
        }

        // =============================================================
        // String comparison operators
        // =============================================================

        private static bool EvaluateStringComparison(string op, Value A, Value B, bool defaultIgnoreCase)
        {
            string LS = A.IsString ? (A.Str ?? "")
                : A.NumOk ? A.Num.ToString(CultureInfo.InvariantCulture)
                : "";
            string RS = B.IsString ? (B.Str ?? "")
                : B.NumOk ? B.Num.ToString(CultureInfo.InvariantCulture)
                : "";

            bool caseInsensitive = defaultIgnoreCase;
            var cmp = caseInsensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

            return op switch
            {
                "==" => string.Equals(LS, RS, cmp),
                "!=" => !string.Equals(LS, RS, cmp),
                "===" => string.Equals(LS, RS, StringComparison.Ordinal),
                "!==" => !string.Equals(LS, RS, StringComparison.Ordinal),
                "~" => LS.IndexOf(RS, cmp) >= 0,
                "^=" => LS.StartsWith(RS, cmp),
                "$=" => LS.EndsWith(RS, cmp),
                _ => false
            };
        }

        // =============================================================
        // Value evaluation
        // =============================================================

        private static Value EvalValue(string expr,
            Func<string, double> numResolver, ISet<string> ids, Func<string, string> strResolver)
        {
            expr = expr.Trim();

            if (IsQuoted(expr))
                return new Value { IsString = true, Str = Unquote(expr) };

            if (IsSimpleIdentifier(expr) && ids.Contains(expr) && strResolver != null)
            {
                string s = strResolver(expr);
                if (s != null) return new Value { IsString = true, Str = s };
            }

            return EvalNumeric(expr, numResolver, ids);
        }

        private static Value EvalNumeric(string expr, Func<string, double> resolver, ISet<string> ids)
        {
            var substituted = SubstituteVariables(expr, ids, resolver);
            return !MathExpressionUtility.TryEvaluate(substituted, out double num) 
                ? new Value { NumOk = false, Num = double.NaN } 
                : new Value { NumOk = true, Num = num };
        }

        // =============================================================
        // Helper methods
        // =============================================================

        private static bool IsComparator(string s)
            => s is ">" or "<" or ">=" or "<=" or "==" or "!=" or "===" or "!==" or "~" or "^=" or "$=";

        private static bool IsLogical(string s) => s is "&&" or "||";

        private static void Expect(List<string> t, ref int i, string expected)
        {
            if (i >= t.Count || t[i] != expected) throw new ArgumentException($"Expected '{expected}'.");
            i++;
        }

        private static string ReadOperand(ref int i, List<string> t)
        {
            if (i < t.Count && t[i] == "(")
            {
                int start = i, depth = 0;
                do
                {
                    if (t[i] == "(") depth++;
                    else if (t[i] == ")") depth--;
                    i++;
                } while (i < t.Count && depth > 0);

                return string.Join(" ", t.GetRange(start, i - start));
            }

            int j = i;
            int depth2 = 0;
            while (j < t.Count)
            {
                if (t[j] == "(")
                {
                    depth2++;
                    j++;
                    continue;
                }

                if (t[j] == ")")
                {
                    if (depth2 == 0) break;
                    depth2--;
                    j++;
                    continue;
                }

                if (depth2 == 0 && (IsComparator(t[j]) || IsLogical(t[j])))
                {
                    break;
                }

                j++;
            }

            string s = string.Join(" ", t.GetRange(i, j - i));
            i = j;
            return s;
        }

        private static bool IsQuoted(string s)
            => s.Length >= 2 && ((s[0] == '"' && s[^1] == '"') || (s[0] == '\'' && s[^1] == '\''));

        private static string Unquote(string s)
        {
            char q = s[0];
            var inner = s.Substring(1, s.Length - 2);
            return inner
                .Replace(@"\" + q, q.ToString())
                .Replace(@"\\", @"\")
                .Replace(@"\n", "\n")
                .Replace(@"\t", "\t")
                .Replace(@"\r", "\r");
        }

        private static bool IsSimpleIdentifier(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            if (!(char.IsLetter(s[0]) || s[0] == '_')) return false;
            for (int i = 1; i < s.Length; i++)
            {
                char c = s[i];
                if (!(char.IsLetterOrDigit(c) || c == '_' || c == '.')) return false;
            }

            return true;
        }

        // =============================================================
        // Tokenizer
        // =============================================================

        private static List<string> Tokenize(string expr)
        {
            var tokens = new List<string>();
            var ops3 = new HashSet<string> { "===", "!==" };
            var ops2 = new HashSet<string> { ">=", "<=", "==", "!=", "^=", "$=" };
            var ops1 = new HashSet<char> { '>', '<', '(', ')', '!', '+', '-', '*', '/', '%', '^', ',', '~' };

            int i = 0;
            while (i < expr.Length)
            {
                char c = expr[i];
                if (char.IsWhiteSpace(c))
                {
                    i++;
                    continue;
                }

                // quoted string literal
                if (c == '"' || c == '\'')
                {
                    char q = c;
                    i++;
                    var sb = new StringBuilder().Append(q);
                    bool esc = false;
                    while (i < expr.Length)
                    {
                        char d = expr[i++];
                        sb.Append(d);
                        if (esc)
                        {
                            esc = false;
                            continue;
                        }

                        if (d == '\\')
                        {
                            esc = true;
                            continue;
                        }

                        if (d == q) break;
                    }

                    tokens.Add(sb.ToString());
                    continue;
                }

                if (i + 2 < expr.Length)
                {
                    string three = $"{expr[i]}{expr[i + 1]}{expr[i + 2]}";
                    if (ops3.Contains(three))
                    {
                        tokens.Add(three);
                        i += 3;
                        continue;
                    }
                }

                if (i + 1 < expr.Length)
                {
                    string two = $"{expr[i]}{expr[i + 1]}";
                    if (ops2.Contains(two))
                    {
                        tokens.Add(two);
                        i += 2;
                        continue;
                    }
                }

                if (ops1.Contains(c))
                {
                    tokens.Add(c.ToString());
                    i++;
                    continue;
                }

                var sbId = new StringBuilder();
                while (i < expr.Length)
                {
                    char k = expr[i];
                    string two = i + 1 < expr.Length ? $"{k}{expr[i + 1]}" : "";
                    string three = i + 2 < expr.Length ? $"{k}{expr[i + 1]}{expr[i + 2]}" : "";
                    if (char.IsWhiteSpace(k) || ops1.Contains(k) || ops2.Contains(two) || ops3.Contains(three) ||
                        k == '"' || k == '\'') break;
                    sbId.Append(k);
                    i++;
                }

                tokens.Add(sbId.ToString());
            }

            return tokens;
        }

        // =============================================================
        // {Var} placeholder compilation and substitution
        // =============================================================

        private static string CompilePlaceholders(string raw, out HashSet<string> idents)
        {
            if (raw == null) raw = string.Empty;
            var sb = new StringBuilder(raw.Length);
            idents = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            int i = 0;
            while (i < raw.Length)
            {
                int open = raw.IndexOf('{', i);
                if (open < 0)
                {
                    sb.Append(raw, i, raw.Length - i);
                    break;
                }

                sb.Append(raw, i, open - i);
                int close = raw.IndexOf('}', open + 1);
                if (close < 0) throw new ArgumentException($"Unmatched '{{' at index {open} in: \"{raw}\"");

                var name = raw.Substring(open + 1, close - open - 1).Trim();
                if (name.Length == 0) throw new ArgumentException($"Empty variable name at index {open}.");
                var ident = name.Replace(' ', '_');
                idents.Add(ident);
                sb.Append(ident);
                i = close + 1;
            }

            foreach (var bi in Builtins) idents.Add(bi);
            return sb.ToString();
        }

        private static string SubstituteVariables(string expr, ISet<string> identsToReplace,
            Func<string, double> resolver)
        {
            var sb = new StringBuilder(expr.Length * 2);
            int i = 0, n = expr.Length;

            static bool IsStart(char c) => char.IsLetter(c) || c == '_';
            static bool IsId(char c) => char.IsLetterOrDigit(c) || c == '_' || c == '.';

            while (i < n)
            {
                char c = expr[i];

                if (char.IsWhiteSpace(c))
                {
                    sb.Append(c);
                    i++;
                    continue;
                }

                // quoted string copy
                if (c == '"' || c == '\'')
                {
                    char q = c;
                    i++;
                    sb.Append(q);
                    bool esc = false;
                    while (i < n)
                    {
                        char d = expr[i++];
                        sb.Append(d);
                        if (esc)
                        {
                            esc = false;
                            continue;
                        }

                        if (d == '\\')
                        {
                            esc = true;
                            continue;
                        }

                        if (d == q) break;
                    }

                    continue;
                }

                if (IsStart(c))
                {
                    int s = i;
                    i++;
                    while (i < n && IsId(expr[i])) i++;
                    string ident = expr.Substring(s, i - s);
                    if (identsToReplace.Contains(ident))
                    {
                        double v = resolver(ident);
                        sb.Append(v.ToString(CultureInfo.InvariantCulture));
                    }
                    else sb.Append(ident);

                    continue;
                }

                sb.Append(c);
                i++;
            }

            return sb.ToString();
        }
    }
}
