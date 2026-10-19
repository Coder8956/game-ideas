
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
	public sealed class RigidbodySetDrag : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Drag")]
		[SerializeField]
		private FloatVar _setDrag;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setDrag);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_rigidbody.Value.linearDamping = _setDrag.Value;
#else
			_rigidbody.Value.drag = _setDrag.Value;
#endif
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} drag to {_setDrag}";
		}
	}
}

