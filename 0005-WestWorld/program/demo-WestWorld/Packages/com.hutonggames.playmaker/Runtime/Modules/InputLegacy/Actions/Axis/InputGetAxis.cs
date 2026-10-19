
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputAxis)]
	[ActionDescription("Returns the value of the virtual axis identified by axisName."
		+ Strings.LimitedAxisSupport)]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input.GetAxis.html")]
	public sealed class InputGetAxis : BaseAction
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

		public override void Execute() => _result.Value = InputShim.GetAxis(_axisName.Value);

		public override string GetSummary() => "Get {_axisName} Axis -> {_result}";
	}
}
