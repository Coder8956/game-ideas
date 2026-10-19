
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Controls whether physics affects the rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-isKinematic.html")]
	public sealed class RigidbodyGetIsKinematic : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Is Kinematic")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsKinematic;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getIsKinematic);
		}
		
		public override void Execute()
		{
			_getIsKinematic.Value = _rigidbody.Value.isKinematic;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} is kinematic -> {_getIsKinematic}";
		}
	}
}
