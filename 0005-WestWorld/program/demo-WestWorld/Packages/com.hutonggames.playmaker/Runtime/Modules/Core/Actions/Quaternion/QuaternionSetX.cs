
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("X component of the Quaternion. Don\'t modify this directly unless you know quatern" +
		"ions inside out.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion-x.html")]
	public sealed class QuaternionSetX : BaseAction
	{
		
		[Tooltip("The Quaternion")]
		[SerializeField]
		private QuaternionRef _quaternion;
		
		[Tooltip("Set Quaternion X")]
		[SerializeField]
		private FloatVar _setX;
		
		public override bool CanExecute()
		{
			return CheckParameters(_quaternion, _setX);
		}
		
		public override void Execute()
		{
			var value = _quaternion.Value;
			value.x = _setX.Value;
			_quaternion.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_quaternion} X to {_setX}";
		}
	}
}
