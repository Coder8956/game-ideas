
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Z component of the Quaternion. Don\'t modify this directly unless you know quatern" +
		"ions inside out.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion-z.html")]
	public sealed class QuaternionSetZ : BaseAction
	{
		
		[Tooltip("The Quaternion")]
		[SerializeField]
		private QuaternionRef _quaternion;
		
		[Tooltip("Set Quaternion Z")]
		[SerializeField]
		private FloatVar _setZ;
		
		public override bool CanExecute()
		{
			return CheckParameters(_quaternion, _setZ);
		}
		
		public override void Execute()
		{
			var value = _quaternion.Value;
			value.z = _setZ.Value;
			_quaternion.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_quaternion} Z to {_setZ}";
		}
	}
}
