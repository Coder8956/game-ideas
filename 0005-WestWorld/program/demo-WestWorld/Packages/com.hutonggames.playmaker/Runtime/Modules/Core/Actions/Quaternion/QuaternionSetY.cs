
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Y component of the Quaternion. Don\'t modify this directly unless you know quatern" +
		"ions inside out.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion-y.html")]
	public sealed class QuaternionSetY : BaseAction
	{
		
		[Tooltip("The Quaternion")]
		[SerializeField]
		private QuaternionRef _quaternion;
		
		[Tooltip("Set Quaternion Y")]
		[SerializeField]
		private FloatVar _setY;
		
		public override bool CanExecute()
		{
			return CheckParameters(_quaternion, _setY);
		}
		
		public override void Execute()
		{
			var value = _quaternion.Value;
			value.y = _setY.Value;
			_quaternion.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_quaternion} Y to {_setY}";
		}
	}
}
