
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
	public sealed class RigidbodySetIsKinematic : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Is Kinematic")]
		[SerializeField]
		private BoolVar _setIsKinematic;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setIsKinematic);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.isKinematic = _setIsKinematic.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} is kinematic to {_setIsKinematic}";
		}
	}
}
