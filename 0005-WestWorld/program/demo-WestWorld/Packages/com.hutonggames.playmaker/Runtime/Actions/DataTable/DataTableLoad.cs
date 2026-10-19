using System;
using JetBrains.Annotations;
using HutongGames.PlayMaker.SaveSystem;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Load DataTables from the current save profile.")]
    [HelpURL("actions/data-actions/data-table/data-table-load/")]
    public sealed class DataTableLoad : BaseAction
    {
        [Tooltip("The DataTable to load.")]
        public DataTableSource DataTable;

        [OptionalField]
        [Tooltip("Optional profile id. If empty, uses the current profile.")]
        public string ProfileId;

        public override void Execute()
        {
            var table = DataTable.ResolveData();
            if (table == null)
            {
                LogError($"DataTableLoad failed: {DataTable.GetSummary()} could not be resolved.");
                Finish();
                return;
            }

            try
            {
                SaveManager.LoadDataTables(ProfileId);
            }
            catch (Exception e)
            {
                LogError(e.Message);
            }
            finally
            {
                Finish();
            }
        }

        public override string GetSummary()
        {
            var profile = string.IsNullOrWhiteSpace(ProfileId) ? "Current Profile" : ProfileId;
            return $"Load {DataTable.GetSummary()} ({profile})";
        }

#if UNITY_EDITOR
        public override string ErrorCheck()
        {
            // Only warn when the table is statically known at edit time.
            if (!DataTable.CanResolveInEditor())
                return null;

            var asset = DataTable.Source switch
            {
                DataTableSource.TableSource.DataTableAsset => DataTable.TableAsset?.Value,
                DataTableSource.TableSource.DataTable => DataTable.Table?.Variable?.Owner as DataTableAsset,
                _ => null
            };

            if (asset == null)
                return null;

            if (asset.SaveMode == SaveMode.Never)
                return "@DataTable: Save Mode set to Never and will not be loaded.";

            return null;
        }
#endif
    }
}
