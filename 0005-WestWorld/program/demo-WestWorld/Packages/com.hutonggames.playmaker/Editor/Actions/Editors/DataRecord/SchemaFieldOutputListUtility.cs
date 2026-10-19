using System.Collections.Generic;
using HutongGames.Editor.Extensions;
using UnityEditor;

namespace HutongGames.PlayMaker.Editor
{
    internal static class SchemaFieldOutputListUtility
    {
        public static void SyncToSchema(
            List<DataSchemaUtility.SchemaField> schema,
            SerializedProperty listProp,
            string fieldGuidPropName,
            string storePropName,
            bool createDefaultStoreWhenNull = true)
        {
            var existing = BuildGuidToIndexMap(listProp, fieldGuidPropName);

            for (int i = 0; i < schema.Count; i++)
            {
                var sf = schema[i];
                var guid = new SerializableGuid(sf.GuidA, sf.GuidB);

                var created = false;

                if (!existing.TryGetValue(guid, out var elemIndex))
                {
                    created = true;
                    elemIndex = listProp.arraySize;
                    listProp.arraySize++;
                }

                var elem = listProp.GetArrayElementAtIndex(elemIndex);

                var guidProp = elem.FindPropertyRelative(fieldGuidPropName);
                if (guidProp != null) guidProp.boxedValue = guid;

                var storeProp = elem.FindPropertyRelative(storePropName);
                if (storeProp == null) continue;

                // ✅ Critical: new array entries can be created by copying an existing element,
                // which can copy a SerializeReference instance. Always assign a fresh one on creation.
                if (created)
                {
                    storeProp.managedReferenceValue = CreateDefaultStore(sf);
                    continue;
                }

                if (createDefaultStoreWhenNull && storeProp.managedReferenceValue == null)
                {
                    storeProp.managedReferenceValue = CreateDefaultStore(sf);
                }
            }

            ReorderToSchema(schema, listProp, fieldGuidPropName);
        }

        private static IVariableRef CreateDefaultStore(DataSchemaUtility.SchemaField sf)
        {
            return VariableFactory.CreateVariableRefForDataType(sf.DataType, sf.SubType);
        }

        public static Dictionary<SerializableGuid, int> BuildGuidToIndexMap(
            SerializedProperty listProp,
            string fieldGuidPropName)
        {
            var map = new Dictionary<SerializableGuid, int>();

            for (int i = 0; i < listProp.arraySize; i++)
            {
                var elem = listProp.GetArrayElementAtIndex(i);
                var guidProp = elem.FindPropertyRelative(fieldGuidPropName);

                if (guidProp?.GetTargetObject() is not SerializableGuid guid)
                    continue;

                if (!map.ContainsKey(guid))
                    map.Add(guid, i);
            }

            return map;
        }

        public static HashSet<SerializableGuid> BuildSchemaGuidSet(List<DataSchemaUtility.SchemaField> schema)
        {
            var set = new HashSet<SerializableGuid>();
            for (int i = 0; i < schema.Count; i++)
                set.Add(new SerializableGuid(schema[i].GuidA, schema[i].GuidB));
            return set;
        }

        public static List<int> CollectOrphanIndices(
            SerializedProperty listProp,
            HashSet<SerializableGuid> schemaSet,
            string fieldGuidPropName)
        {
            var result = new List<int>();

            for (int i = 0; i < listProp.arraySize; i++)
            {
                var elem = listProp.GetArrayElementAtIndex(i);
                var guidProp = elem.FindPropertyRelative(fieldGuidPropName);
                if (guidProp?.GetTargetObject() is not SerializableGuid guid) continue;

                if (!schemaSet.Contains(guid))
                    result.Add(i);
            }

            return result;
        }

        public static void RemoveOrphans(
            SerializedProperty listProp,
            HashSet<SerializableGuid> schemaSet,
            string fieldGuidPropName)
        {
            for (int i = listProp.arraySize - 1; i >= 0; i--)
            {
                var elem = listProp.GetArrayElementAtIndex(i);
                var guidProp = elem.FindPropertyRelative(fieldGuidPropName);
                if (guidProp?.GetTargetObject() is not SerializableGuid guid) continue;

                if (!schemaSet.Contains(guid))
                    listProp.DeleteArrayElementAtIndex(i);
            }
        }

        private static void ReorderToSchema(
            List<DataSchemaUtility.SchemaField> schema,
            SerializedProperty listProp,
            string fieldGuidPropName)
        {
            var order = new List<SerializableGuid>(schema.Count);
            for (int i = 0; i < schema.Count; i++)
                order.Add(new SerializableGuid(schema[i].GuidA, schema[i].GuidB));

            var write = 0;
            for (int i = 0; i < order.Count; i++)
            {
                var guid = order[i];
                var current = FindIndexByGuid(listProp, guid, fieldGuidPropName);
                if (current < 0) continue;

                if (current != write)
                    listProp.MoveArrayElement(current, write);

                write++;
            }
        }

        private static int FindIndexByGuid(
            SerializedProperty listProp,
            SerializableGuid guid,
            string fieldGuidPropName)
        {
            for (int i = 0; i < listProp.arraySize; i++)
            {
                var elem = listProp.GetArrayElementAtIndex(i);
                var guidProp = elem.FindPropertyRelative(fieldGuidPropName);
                if (guidProp?.GetTargetObject() is SerializableGuid g && g == guid)
                    return i;
            }
            return -1;
        }
    }
}
