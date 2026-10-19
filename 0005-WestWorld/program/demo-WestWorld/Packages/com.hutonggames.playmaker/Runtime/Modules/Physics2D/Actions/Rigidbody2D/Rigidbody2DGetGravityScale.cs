
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The degree to which this object is affected by gravity.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-gravityScale.html")]
	public sealed class Rigidbody2DGetGravityScale : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Gravity Scale")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getGravityScale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getGravityScale);
		}
		
		public override void Execute()
		{
			_getGravityScale.Value = _rigidbody2D.Value.gravityScale;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} gravity scale -> {_getGravityScale}";
		}
	}
}
