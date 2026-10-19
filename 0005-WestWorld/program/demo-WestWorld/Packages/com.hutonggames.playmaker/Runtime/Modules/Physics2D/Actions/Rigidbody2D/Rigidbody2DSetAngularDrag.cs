
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Coefficient of angular drag.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-angularDamping.html")]
	public sealed class Rigidbody2DSetAngularDrag : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Angular Drag")]
		[SerializeField]
		private FloatVar _setAngularDrag;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setAngularDrag);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_rigidbody2D.Value.angularDamping = _setAngularDrag.Value;
#else
			_rigidbody2D.Value.angularDrag = _setAngularDrag.Value;
#endif
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} angular drag to {_setAngularDrag}";
		}
	}
}

