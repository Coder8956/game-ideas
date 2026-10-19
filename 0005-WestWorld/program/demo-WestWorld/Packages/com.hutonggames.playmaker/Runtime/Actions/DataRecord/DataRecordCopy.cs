using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.DataRecord)]
    [ActionDescription("Copy values from one DataRecord into another DataRecord.")]
    [HelpURL("actions/data-actions/data-record/data-record-copy/")]
    public sealed class DataRecordCopy : BaseAction
    {
        [Tooltip("The DataRecord to write values to.")]
        public DataRecordRef Target;

        [Tooltip("The DataRecord to copy values from.")]
        public DataRecordRef Source;

        public override bool CanExecute() => CheckParameters(Target, Source);

        public override void Execute()
        {
            var target = Target.Value;
            var source = Source.Value;

            if (target == null || source == null)
                return;

            // Use target schema as authoritative (fast, predictable)
            DataRecordCopyUtility.SetValue(target, source);
        }

        public override string GetSummary() => "Copy {Source} to {Target}";
    }
}