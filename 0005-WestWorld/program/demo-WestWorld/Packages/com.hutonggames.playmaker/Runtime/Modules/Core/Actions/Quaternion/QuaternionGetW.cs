
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
	public sealed class QuaternionGetW : BaseAction
	{
		
		[Tooltip("The Quaternion")]
		[SerializeField]
		private QuaternionRef _quaternion;
		
		[Tooltip("Get Quaternion W")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getW;
		
		public override bool CanExecute()
		{
			return CheckParameters(_quaternion, _getW);
		}
		
		public override void Execute()
		{
			_getW.Value = _quaternion.Value.w;
		}
		
		public override string GetSummary()
		{
			return "Get {_quaternion} w -> {_getW}";
		}
	}
}
