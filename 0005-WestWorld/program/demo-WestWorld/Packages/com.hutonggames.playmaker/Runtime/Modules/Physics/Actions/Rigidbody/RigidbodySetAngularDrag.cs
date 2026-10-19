
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
	public sealed class RigidbodySetAngularDrag : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Angular Drag")]
		[SerializeField]
		private FloatVar _setAngularDrag;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setAngularDrag);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_rigidbody.Value.angularDamping = _setAngularDrag.Value;
#else
			_rigidbody.Value.angularDrag = _setAngularDrag.Value;
#endif
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} angular drag to {_setAngularDrag}";
		}
	}
}

