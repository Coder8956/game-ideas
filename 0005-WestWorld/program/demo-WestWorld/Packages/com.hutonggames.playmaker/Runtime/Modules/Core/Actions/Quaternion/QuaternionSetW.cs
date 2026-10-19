
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("W component of the Quaternion. Do not directly modify quaternions.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion-w.html")]
	public sealed class QuaternionSetW : BaseAction
	{
		
		[Tooltip("The Quaternion")]
		[SerializeField]
		private QuaternionRef _quaternion;
		
		[Tooltip("Set Quaternion W")]
		[SerializeField]
		private FloatVar _setW;
		
		public override bool CanExecute()
		{
			return CheckParameters(_quaternion, _setW);
		}
		
		public override void Execute()
		{
			var value = _quaternion.Value;
			value.w = _setW.Value;
			_quaternion.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_quaternion} W to {_setW}";
		}
	}
}
