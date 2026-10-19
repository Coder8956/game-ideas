
using JetBrains.Annotations;
using System;
using HutongGames.PlayMaker.Internal;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Should this rigidbody be taken out of physics control?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.html")]
	public sealed class Rigidbody2DGetIsKinematic : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Is Kinematic")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsKinematic;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getIsKinematic);
		}
		
		public override void Execute()
		{
			_getIsKinematic.Value = _rigidbody2D.Value.GetIsKinematicShim();
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} is kinematic -> {_getIsKinematic}";
		}
	}
}


