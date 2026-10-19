using System.Collections.Generic;

namespace HutongGames.PlayMaker.UI
{
    internal static class DataFieldBindingUtility
    {
        public static void BuildLookup(
            IReadOnlyList<DataRow.Cell> cells,
            Dictionary<SerializableGuid, IVariableVar> byGuid)
        {
            byGuid.Clear();
            if (cells == null) return;

            for (int i = 0; i < cells.Count; i++)
            {
                var cell = cells[i];
                if (cell == null) continue;

                var guid = cell.FieldGuid;
                if (guid == SerializableGuid.None) continue;

                // First wins
                if (!byGuid.ContainsKey(guid))
                    byGuid.Add(guid, cell.Value);
            }
        }

        public static void ApplyBindings(
            List<DataFieldBinding> bindings,
            Dictionary<SerializableGuid, IVariableVar> byGuid,
            DataDefinition definition)
        {
            if (bindings == null) return;

            for (int i = 0; i < bindings.Count; i++)
            {
                var b = bindings[i];
                if (b == null) continue;

                var guid = b.FieldGuid;
                if (guid == SerializableGuid.None) continue;

                byGuid.TryGetValue(guid, out var value);
                b.Target?.Apply(value, definition, guid);
            }
        }
    }
}