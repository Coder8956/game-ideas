
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Coefficient of drag.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-linearDamping.html")]
	public sealed class Rigidbody2DSetDrag : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Drag")]
		[SerializeField]
		private FloatVar _setDrag;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setDrag);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_rigidbody2D.Value.linearDamping = _setDrag.Value;
#else
			_rigidbody2D.Value.drag = _setDrag.Value;
#endif
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} drag to {_setDrag}";
		}
	}
}

