using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.InputAxis)]
    [ActionDescription(
        "Resets input axes.\n\n" +
        "With the old Input Manager this calls Input.ResetInputAxes, so all axes return to 0 " +
        "and all buttons return to 0 for one frame. " +
        "With the new Input System this clears PlayMaker's internal axis smoothing, " +
        "but cannot fully reset hardware device state.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Input.ResetInputAxes.html")]
    public sealed class InputResetInputAxes : BaseAction
    {
        public override void Execute() => InputShim.ResetInputAxes();

        public override string GetSummary() => "Reset Input Axes";
    }
}