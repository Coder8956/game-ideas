
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSettings)]
	[ActionDescription("Retrieves a list of input device names corresponding to the index of an Axis " +
	                   "configured within Input Manager.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input.GetJoystickNames.html")]
	public sealed class InputGetJoystickNames : BaseAction
	{
		
		[Tooltip("Store the result in String List variable.")]
		[SerializeField]
		[WriteOnly]
		private StringListRef _result;
		
		public override bool CanExecute() => CheckParameters(_result);

		public override void Execute() => _result.Values = Input.GetJoystickNames();

		public override string GetSummary() => "Get Joystick Names -> {_result}";
	}
}
