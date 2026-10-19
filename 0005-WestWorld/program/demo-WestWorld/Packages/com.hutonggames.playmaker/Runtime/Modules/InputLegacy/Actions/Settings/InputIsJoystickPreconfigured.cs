
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSettings)]
	[ActionDescription("Determine whether a particular joystick model has been preconfigured by Unity. (Linux-only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input.IsJoystickPreconfigured.html")]
	public sealed class InputIsJoystickPreconfigured : BaseAction
	{
		
		[Tooltip("The name of the joystick to check (returned by Input.GetJoystickNames).")]
		[SerializeField]
		private StringVar _joystickName;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
#if UNITY_LINUX

		public override bool CanExecute() => CheckParameters(_joystickName, _result);

		public override void Execute() => _result.Value = Input.IsJoystickPreconfigured(_joystickName.Value);

#else
		public override bool CanExecute() => false;
		
#endif

		public override string GetSummary() => "Is Joystick Preconfigured {_joystickName} -> {_result}";
	}
}
