
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The angular drag of the object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-angularDamping.html")]
	public sealed class RigidbodyGetAngularDrag : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Angular Drag")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getAngularDrag;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getAngularDrag);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getAngularDrag.Value = _rigidbody.Value.angularDamping;
#else
			_getAngularDrag.Value = _rigidbody.Value.angularDrag;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} angular drag -> {_getAngularDrag}";
		}
	}
}

