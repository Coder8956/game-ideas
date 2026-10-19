using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputAxis)]
	[ActionDescription("Returns the value of the virtual axis identified by axisName with no smoothing filtering applied."
		+ Strings.LimitedAxisSupport)]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input.GetAxisRaw.html")]
	public sealed class InputGetAxisRaw : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("Axis Name.")]
		[SerializeField]
		private StringVar _axisName;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute() => CheckParameters(_axisName, _result);
		
		public override void Execute() => _result.Value = InputShim.GetAxisRaw(_axisName.Value);

		public override string GetSummary() => "Get {_axisName} Axis Raw -> {_result}";
	}
}
