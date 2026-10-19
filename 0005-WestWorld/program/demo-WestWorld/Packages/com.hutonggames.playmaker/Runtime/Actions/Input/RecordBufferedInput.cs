using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.BufferedInput)]
    [ActionDescription("Manually record a BufferedInput press. Useful for AI, testing, or simulating input.")]
    [HelpURL("actions/input-actions/buffered-input/")]
    public sealed class RecordBufferedInput : BaseAction
    {
        [Tooltip("The BufferedInput to record.")]
        public BufferedInputRef BufferedInput;

        public override bool CanExecute() => CheckParameters(BufferedInput);

        public override void Execute()
        {
            var value = BufferedInput.Value;

            // Record the press (sets timestamp + unconsumed)
            value.Record();
            BufferedInput.Value = value;
        }

        public override string GetSummary() => "Record {BufferedInput}";
    }
}