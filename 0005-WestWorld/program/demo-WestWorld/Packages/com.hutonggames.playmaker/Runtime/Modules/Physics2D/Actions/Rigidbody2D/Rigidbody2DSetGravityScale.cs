
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
	public sealed class Rigidbody2DSetGravityScale : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Gravity Scale")]
		[SerializeField]
		private FloatVar _setGravityScale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setGravityScale);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.gravityScale = _setGravityScale.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} gravity scale to {_setGravityScale}";
		}
	}
}
