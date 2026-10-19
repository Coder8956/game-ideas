using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataRecord)]
    [ConvertibleGroup("EvaluateExpression")]
    [ActionDescription("Evaluates a mathematical expression using DataRecord fields as variables. " +
                       "Use {FieldName} to reference fields.")]
    [HelpURL("actions/data-actions/data-record/data-record-evaluate-expression-float/")]
    public sealed class DataRecordEvaluateExpression__float : BaseExpressionEvaluatorEvaluate
    {
        [DisplayOrder(-10)]
        [Tooltip("Record providing field values for the expression.")]
        public DataRecordRef Record;

        [Tooltip("Store the result in a float variable.")]
        [SerializeField, WriteOnly]
        private FloatRef _result;

        // Cache: DataDefinition -> (normalized field name -> guid)
        [NonSerialized] private DataDefinition _cachedDef;
        [NonSerialized] private Dictionary<string, SerializableGuid> _nameToGuid;

        public override bool CanExecute() => _result.IsAssigned && Expression.HasValue();

        public override void Execute()
        {
            try
            {
                _ = GetCompiledExpression();

                var ok = TryEvaluate(out var value);
                _result.Value = ok ? (float)value : 0f;
            }
            catch (Exception e)
            {
                Debug.LogError($"[EvaluateRecordExpression__float] Failed: {e.Message}");
                Succeeded.Value = false;
                _result.Value = 0f;
            }
        }

        protected override double ResolveIdentifier(string ident)
        {
            // Try record fields first (by field name -> guid -> cell value)
            if (TryResolveFromRecord(ident, out var v))
                return v;

            // Fallback to base (built-ins, FSM vars, Owner/property paths)
            return base.ResolveIdentifier(ident);
        }

        private bool TryResolveFromRecord(string ident, out double value)
        {
            value = 0.0;

            var record = Record?.Value;
            if (record == null || string.IsNullOrEmpty(ident))
                return false;

            var def = record.DataDefinition;
            if (def == null)
                return false;

            EnsureNameMap(def);

            if (!_nameToGuid.TryGetValue(ident, out var guid) || guid == SerializableGuid.None)
                return false;

            var cell = record.FindCell(guid);
            var vv = cell?.Value;
            if (vv == null)
                return true; // treat missing/empty as 0

            // Fast typed paths (no boxing)
            if (vv is VariableVar<float> fv) { value = fv.Value; return true; }
            if (vv is VariableVar<int> iv)   { value = iv.Value; return true; }
            if (vv is VariableVar<bool> bv)  { value = bv.Value ? 1.0 : 0.0; return true; }
            if (vv is VariableVar<double> dv){ value = dv.Value; return true; }
            if (vv is VariableVar<long> lv)  { value = lv.Value; return true; }

            // Conservative fallback: rely on GetValue() if your IVariableVar supports it.
            // If not, delete this block.
            try
            {
                var obj = vv.GetValue();
                value = obj switch
                {
                    null => 0.0,
                    double d => d,
                    float f => f,
                    int i => i,
                    long l => l,
                    bool b => b ? 1.0 : 0.0,
                    _ => 0.0
                };
            }
            catch
            {
                value = 0.0;
            }

            return true;
        }

        private void EnsureNameMap(DataDefinition def)
        {
            if (ReferenceEquals(_cachedDef, def) && _nameToGuid != null)
                return;

            _cachedDef = def;
            _nameToGuid = new Dictionary<string, SerializableGuid>(StringComparer.OrdinalIgnoreCase);

            // Note: your compiler normalizes spaces to underscores: name.Replace(' ', '_')
            // Mirror that here so {Max Speed} and {Max_Speed} can match consistently.
            foreach (var v in def.Variables.GetVariables())
            {
                if (v is not BaseVariable bv) continue;
                if (bv.Guid == SerializableGuid.None) continue;

                var key = (bv.Name ?? string.Empty).Trim().Replace(' ', '_');
                if (key.Length == 0) continue;

                _nameToGuid[key] = bv.Guid;
            }
        }

        public override string GetSummary() => "Evaluate {Expression} {_result:output}";
    }
}
