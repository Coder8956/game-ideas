using System;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{
    internal static class DataTableRowComparer
    {
        private sealed class Comparer : IComparer<DataRow>
        {
            private readonly SerializableGuid _field;
            private readonly Type _type;
            private readonly int _dir;

            public Comparer(SerializableGuid field, Type type, bool desc)
            {
                _field = field;
                _type = type;
                _dir = desc ? -1 : 1;
            }

            public int Compare(DataRow a, DataRow b)
            {
                var aHas = TryGetCellValue(a, _field, out var av);
                var bHas = TryGetCellValue(b, _field, out var bv);

                if (aHas != bHas)
                    return aHas ? -1 : 1;

                if (!aHas) return 0;

                if (_type == typeof(string))
                {
                    return _dir * string.Compare(av as string, bv as string, StringComparison.Ordinal);
                }

                if (_type == typeof(int))
                    return _dir * ((av is int ai ? ai : 0).CompareTo(bv is int bi ? bi : 0));

                if (_type == typeof(float))
                    return _dir * ((av is float af ? af : 0f).CompareTo(bv is float bf ? bf : 0f));

                if (av is IComparable ca && bv is IComparable cb)
                    return _dir * ca.CompareTo(cb);

                return 0;
            }

            private static bool TryGetCellValue(DataRow row, SerializableGuid fieldGuid, out object value)
            {
                value = null;
                var cells = row?.Cells;
                if (cells == null) return false;

                for (int i = 0; i < cells.Count; i++)
                {
                    var c = cells[i];
                    if (c == null || c.FieldGuid != fieldGuid)
                        continue;

                    var vv = c.Value;
                    if (vv == null) return false;

                    value = vv.GetValue();
                    return value != null;
                }

                return false;
            }
        }
        
        private sealed class FloatFieldComparer : IComparer<DataRow>
        {
            private readonly SerializableGuid _field;
            private readonly int _dir;

            public FloatFieldComparer(SerializableGuid field, bool desc)
            {
                _field = field;
                _dir = desc ? -1 : 1;
            }

            public int Compare(DataRow a, DataRow b)
            {
                var av = a.GetFloatOrDefault(_field);
                var bv = b.GetFloatOrDefault(_field);
                return _dir * av.CompareTo(bv);
            }
        }
        
        private sealed class IntFieldComparer : IComparer<DataRow>
        {
            private readonly SerializableGuid _field;
            private readonly int _dir;

            public IntFieldComparer(SerializableGuid field, bool desc)
            {
                _field = field;
                _dir = desc ? -1 : 1;
            }

            public int Compare(DataRow a, DataRow b)
            {
                var av = a.GetIntOrDefault(_field);
                var bv = b.GetIntOrDefault(_field);
                return _dir * av.CompareTo(bv);
            }
        }
        
        private sealed class RowKeyComparer : IComparer<DataRow>
        {
            private readonly DataTable _table;
            private readonly int _dir;
            public RowKeyComparer(DataTable table, bool desc)
            {
                _table = table;
                _dir = desc ? -1 : 1;
            }

            public int Compare(DataRow a, DataRow b)
            {
                var sa = _table?.GetRowKey(a) ?? a?.Key ?? string.Empty;
                var sb = _table?.GetRowKey(b) ?? b?.Key ?? string.Empty;
                return _dir * string.Compare(sa, sb, StringComparison.Ordinal);
            }
        }

        public static IComparer<DataRow> GetRowKey(DataTable table, bool desc) => new RowKeyComparer(table, desc);
        public static IComparer<DataRow> GetField(SerializableGuid field, Type type, bool desc) => 
            new Comparer(field, type, desc);
        
        public static IComparer<DataRow> GetFloatField(SerializableGuid field, bool desc) =>
            new FloatFieldComparer(field, desc);
        
        public static IComparer<DataRow> GetIntField(SerializableGuid field, bool desc) =>
            new IntFieldComparer(field, desc);

    }
}
