
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Controls whether physics will change the rotation of the object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-freezeRotation.html")]
	public sealed class RigidbodySetFreezeRotation : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Freeze Rotation")]
		[SerializeField]
		private BoolVar _setFreezeRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setFreezeRotation);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.freezeRotation = _setFreezeRotation.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} freeze rotation to {_setFreezeRotation}";
		}
	}
}
