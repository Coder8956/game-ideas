
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Sets the euler angle representation of the rotation in degrees.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion-eulerAngles.html")]
	public sealed class QuaternionSetEulerAngles : BaseAction
	{
		
		[Tooltip("The Quaternion")]
		[SerializeField]
		private QuaternionRef _quaternion;
		
		[Tooltip("Set Quaternion Euler Angles")]
		[SerializeField]
		private Vector3Var _setEulerAngles;
		
		public override bool CanExecute()
		{
			return CheckParameters(_quaternion, _setEulerAngles);
		}
		
		public override void Execute()
		{
			var value = _quaternion.Value;
			value.eulerAngles = _setEulerAngles.Value;
			_quaternion.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_quaternion} Euler Angles to {_setEulerAngles}";
		}
	}
}
