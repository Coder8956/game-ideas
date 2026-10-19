
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The drag of the object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-linearDamping.html")]
	public sealed class RigidbodyGetDrag : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Drag")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getDrag;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getDrag);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getDrag.Value = _rigidbody.Value.linearDamping;
#else
			_getDrag.Value = _rigidbody.Value.drag;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} drag -> {_getDrag}";
		}
	}
}

