
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
	public sealed class RigidbodyGetFreezeRotation : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Freeze Rotation")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getFreezeRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getFreezeRotation);
		}
		
		public override void Execute()
		{
			_getFreezeRotation.Value = _rigidbody.Value.freezeRotation;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} freeze rotation -> {_getFreezeRotation}";
		}
	}
}
