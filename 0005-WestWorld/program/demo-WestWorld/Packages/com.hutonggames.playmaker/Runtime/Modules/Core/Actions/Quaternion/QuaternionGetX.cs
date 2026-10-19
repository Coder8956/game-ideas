
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
	public sealed class QuaternionGetX : BaseAction
	{
		
		[Tooltip("The Quaternion")]
		[SerializeField]
		private QuaternionRef _quaternion;
		
		[Tooltip("Get Quaternion X")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getX;
		
		public override bool CanExecute()
		{
			return CheckParameters(_quaternion, _getX);
		}
		
		public override void Execute()
		{
			_getX.Value = _quaternion.Value.x;
		}
		
		public override string GetSummary()
		{
			return "Get {_quaternion} x -> {_getX}";
		}
	}
}
