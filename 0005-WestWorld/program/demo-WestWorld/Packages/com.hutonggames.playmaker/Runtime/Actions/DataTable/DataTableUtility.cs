namespace HutongGames.PlayMaker
{
    public enum DataTableMissingValueBehavior
    {
        KeepExisting,
        ResetValue,
        UseDataDefinitionDefaults
    }

    public enum DataTableMissingRecordBehavior
    {
        KeepExisting,
        ResetRecord,
        UseDataDefinitionDefaults
    }

    internal static class DataTableUtility
    {
#if UNITY_6000_5_OR_NEWER
        [Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
#endif
        internal static readonly SerializableGuid RowKeyGuid = SerializableGuid.FromParts(ulong.MaxValue, ulong.MaxValue);

        internal static void ApplyMissingValueBehavior(
            DataDefinition definition,
            DataFieldStore fieldStore,
            IVariableVar explicitDefaultValue,
            DataTableMissingValueBehavior behavior)
        {
            var store = fieldStore?.Store;
            if (store == null)
                return;

            if (explicitDefaultValue is { IsAssigned: true })
            {
                store.CopyValueFrom(explicitDefaultValue);
                return;
            }

            switch (behavior)
            {
                case DataTableMissingValueBehavior.ResetValue:
                    store.Reset();
                    break;

                case DataTableMissingValueBehavior.UseDataDefinitionDefaults:
                {
                    var defaultValue = CreateDefaultValue(definition, fieldStore.FieldGuid);
                    if (defaultValue != null)
                    {
                        store.CopyValueFrom(defaultValue);
                    }
                    else
                    {
                        store.Reset();
                    }

                    break;
                }

                case DataTableMissingValueBehavior.KeepExisting:
                default:
                    break;
            }
        }

        internal static void ApplyMissingRecordBehavior(
            DataDefinition definition,
            DataRecord targetRecord,
            DataTableMissingRecordBehavior behavior)
        {
            if (targetRecord == null)
                return;

            switch (behavior)
            {
                case DataTableMissingRecordBehavior.ResetRecord:
                    targetRecord.Reset();
                    break;

                case DataTableMissingRecordBehavior.UseDataDefinitionDefaults:
                    if (definition != null)
                    {
                        targetRecord.Reset(definition);
                    }
                    else
                    {
                        targetRecord.Reset();
                    }

                    break;

                case DataTableMissingRecordBehavior.KeepExisting:
                default:
                    break;
            }
        }

        internal static DataRecord EnsureRecordExists(DataRecordRef recordRef, DataDefinition definition = null)
        {
            if (recordRef == null || !recordRef.IsAssigned)
                return null;

            var record = recordRef.Value;
            if (record != null)
                return record;

            record = new DataRecord();
            if (definition != null)
                record.Reset(definition);

            recordRef.Value = record;
            return record;
        }

        internal static IVariableVar CreateDefaultValue(DataDefinition definition, SerializableGuid fieldGuid)
        {
            if (definition == null || fieldGuid == SerializableGuid.None)
                return null;

            foreach (var definitionVar in definition.Variables.GetVariables())
            {
                if (definitionVar is not BaseVariable baseVariable || baseVariable.Guid != fieldGuid)
                    continue;

                var value = VariableFactory.CreateVariableVarForDataType(definitionVar.DataType, definitionVar.SubType);
                if (value == null)
                    return null;

                value.SetValue(definitionVar.GetValue());
                return value;
            }

            return null;
        }
    }
}
