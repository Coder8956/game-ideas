using System.Collections.Generic;
using HutongGames.Editor.Extensions;
using UnityEditor;

namespace HutongGames.PlayMaker.Editor
{
    internal static class SchemaFieldValueListUtility
    {
        public static void SyncToSchema(
            List<DataSchemaUtility.SchemaField> schema,
            SerializedProperty listProp,
            string fieldGuidPropName = "FieldGuid",
            string valuePropName = "Value",
            bool createDefaultValueWhenNull = true)
        {
            var existing = BuildGuidToIndexMap(listProp, fieldGuidPropName);

            for (var i = 0; i < schema.Count; i++)
            {
                var schemaField = schema[i];
                var guid = new SerializableGuid(schemaField.GuidA, schemaField.GuidB);

                var created = false;

                if (!existing.TryGetValue(guid, out var elementIndex))
                {
                    created = true;
                    elementIndex = listProp.arraySize;
                    listProp.arraySize++;
                }

                var element = listProp.GetArrayElementAtIndex(elementIndex);

                var guidProp = element.FindPropertyRelative(fieldGuidPropName);
                if (guidProp != null) guidProp.boxedValue = guid;

                var valueProp = element.FindPropertyRelative(valuePropName);
                if (valueProp == null) continue;

                // ✅ Critical: if Unity created this element by copying, it may have copied a managed reference.
                // If the element is newly created, always assign a fresh instance so entries don't share.
                if (created)
                {
                    valueProp.managedReferenceValue = CreateDefaultVar(schemaField);
                    continue;
                }

                // Existing element: only create default if null (same behavior as before)
                if (createDefaultValueWhenNull && valueProp.managedReferenceValue == null)
                {
                    valueProp.managedReferenceValue = CreateDefaultVar(schemaField);
                }
            }

            ReorderToSchema(schema, listProp, fieldGuidPropName);
            DeduplicateManagedReferences(schema, listProp, fieldGuidPropName, valuePropName);
        }

        private static IVariableVar CreateDefaultVar(DataSchemaUtility.SchemaField schemaField)
        {
            return VariableFactory.CreateVariableVarForDataType(schemaField.DataType, schemaField.SubType);
        }

        public static Dictionary<SerializableGuid, int> BuildGuidToIndexMap(
            SerializedProperty listProp,
            string fieldGuidPropName = "FieldGuid")
        {
            var map = new Dictionary<SerializableGuid, int>();

            for (var i = 0; i < listProp.arraySize; i++)
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
            for (var i = 0; i < schema.Count; i++)
                set.Add(new SerializableGuid(schema[i].GuidA, schema[i].GuidB));
            return set;
        }

        public static List<int> CollectOrphanIndices(
            SerializedProperty listProp,
            HashSet<SerializableGuid> schemaSet,
            string fieldGuidPropName = "FieldGuid")
        {
            var result = new List<int>();

            for (var i = 0; i < listProp.arraySize; i++)
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
            string fieldGuidPropName = "FieldGuid")
        {
            for (var i = listProp.arraySize - 1; i >= 0; i--)
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
            for (var i = 0; i < schema.Count; i++)
                order.Add(new SerializableGuid(schema[i].GuidA, schema[i].GuidB));

            var write = 0;
            for (var i = 0; i < order.Count; i++)
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
            for (var i = 0; i < listProp.arraySize; i++)
            {
                var elem = listProp.GetArrayElementAtIndex(i);
                var guidProp = elem.FindPropertyRelative(fieldGuidPropName);
                if (guidProp?.GetTargetObject() is SerializableGuid g && g == guid)
                    return i;
            }
            return -1;
        }
        
        private static void DeduplicateManagedReferences(
            List<DataSchemaUtility.SchemaField> schema,
            SerializedProperty listProp,
            string fieldGuidPropName,
            string valuePropName)
        {
            // Track identity of SerializeReference instances we’ve seen.
            var seen = new HashSet<object>();

            for (var i = 0; i < listProp.arraySize; i++)
            {
                var elem = listProp.GetArrayElementAtIndex(i);

                var guidProp = elem.FindPropertyRelative(fieldGuidPropName);
                if (guidProp?.boxedValue is not SerializableGuid guid)
                    continue;

                var valueProp = elem.FindPropertyRelative(valuePropName);
                var obj = valueProp?.managedReferenceValue;
                if (obj == null) continue;

                // If we've already seen this object instance, Unity copied it.
                if (!seen.Add(obj))
                {
                    // Find schema field to recreate the right default type.
                    if (!TryGetSchemaField(schema, guid, out var sf))
                        continue;

                    // Break the shared reference explicitly, then assign a fresh instance.
                    valueProp.managedReferenceValue = null;
                    valueProp.managedReferenceValue = CreateDefaultVar(sf);
                }
            }
        }

        private static bool TryGetSchemaField(
            List<DataSchemaUtility.SchemaField> schema,
            SerializableGuid guid,
            out DataSchemaUtility.SchemaField schemaField)
        {
            for (var i = 0; i < schema.Count; i++)
            {
                var sf = schema[i];
                if (guid == new SerializableGuid(sf.GuidA, sf.GuidB))
                {
                    schemaField = sf;
                    return true;
                }
            }

            schemaField = default;
            return false;
        }
    }
}
