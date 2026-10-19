
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
	public sealed class Rigidbody2DGetDrag : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Drag")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getDrag;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getDrag);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getDrag.Value = _rigidbody2D.Value.linearDamping;
#else
			_getDrag.Value = _rigidbody2D.Value.drag;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} drag -> {_getDrag}";
		}
	}
}

