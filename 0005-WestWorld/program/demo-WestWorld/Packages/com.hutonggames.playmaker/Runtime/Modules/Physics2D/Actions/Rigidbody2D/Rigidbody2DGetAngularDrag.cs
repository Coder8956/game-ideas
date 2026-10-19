
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
	public sealed class Rigidbody2DGetAngularDrag : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Angular Drag")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getAngularDrag;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getAngularDrag);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getAngularDrag.Value = _rigidbody2D.Value.angularDamping;
#else
			_getAngularDrag.Value = _rigidbody2D.Value.angularDrag;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} angular drag -> {_getAngularDrag}";
		}
	}
}

