using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckDataRecord")]
    [ActionDescription("Check if two DataRecords are equal by comparing their field values.")]
    public sealed class CheckDataRecordEquals : BaseTrueFalseAction
    {
        [Tooltip("The DataRecord to check.")]
        public DataRecordRef Record;

        [Tooltip("The DataRecord to compare against.")]
        [ConvertibleName("Other")]
        public DataRecordRef EqualTo;

        protected override string TrueSummary => "{Record} == {EqualTo}";
        protected override string FalseSummary => "{Record} != {EqualTo}";

        public override bool CanExecute() => CheckParameters(Record, EqualTo);

        protected override bool Test()
        {
            var a = Record.Value;
            var b = EqualTo.Value;

            if (a == null || b == null)
                return a == b; // both null => equal

            // Definitions must match
            if (a.DataDefinition != b.DataDefinition)
                return false;

            var def = a.DataDefinition;
            if (def == null)
                return false;

            var rowA = a.Data;
            var rowB = b.Data;

            if (rowA == null || rowB == null)
                return rowA == rowB;

            // Compare schema-defined fields only
            foreach (var v in def.Variables.GetVariables())
            {
                if (v is not BaseVariable bv)
                    continue;

                var guid = bv.Guid;
                if (guid == SerializableGuid.None)
                    continue;

                var cellA = a.FindCell(guid);
                var cellB = b.FindCell(guid);

                // Missing vs present => not equal
                if (cellA == null || cellB == null)
                {
                    if (cellA != cellB)
                        return false;
                    continue;
                }

                var valA = cellA.Value;
                var valB = cellB.Value;

                if (valA == null || valB == null)
                {
                    if (valA != valB)
                        return false;
                    continue;
                }

                // Compare actual stored values
                var valueA = valA.GetValue();
                var valueB = valB.GetValue();

                if (!Equals(valueA, valueB))
                    return false;
            }

            return true;
        }
    }
}
