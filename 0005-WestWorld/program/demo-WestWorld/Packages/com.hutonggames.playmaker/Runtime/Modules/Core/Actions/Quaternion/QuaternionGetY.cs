
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
	public sealed class QuaternionGetY : BaseAction
	{
		
		[Tooltip("The Quaternion")]
		[SerializeField]
		private QuaternionRef _quaternion;
		
		[Tooltip("Get Quaternion Y")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getY;
		
		public override bool CanExecute()
		{
			return CheckParameters(_quaternion, _getY);
		}
		
		public override void Execute()
		{
			_getY.Value = _quaternion.Value.y;
		}
		
		public override string GetSummary()
		{
			return "Get {_quaternion} y -> {_getY}";
		}
	}
}
