
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Returns the number of Collider2D attached to this Rigidbody2D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-attachedColliderCount.html")]
	public sealed class Rigidbody2DGetAttachedColliderCount : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Attached Collider Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getAttachedColliderCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getAttachedColliderCount);
		}
		
		public override void Execute()
		{
			_getAttachedColliderCount.Value = _rigidbody2D.Value.attachedColliderCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} attached collider count -> {_getAttachedColliderCount}";
		}
	}
}
