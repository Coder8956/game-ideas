
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
	public sealed class QuaternionGetZ : BaseAction
	{
		
		[Tooltip("The Quaternion")]
		[SerializeField]
		private QuaternionRef _quaternion;
		
		[Tooltip("Get Quaternion Z")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getZ;
		
		public override bool CanExecute()
		{
			return CheckParameters(_quaternion, _getZ);
		}
		
		public override void Execute()
		{
			_getZ.Value = _quaternion.Value.z;
		}
		
		public override string GetSummary()
		{
			return "Get {_quaternion} z -> {_getZ}";
		}
	}
}
