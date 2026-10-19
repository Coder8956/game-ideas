
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The rotation of the rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-rotation.html")]
	public sealed class Rigidbody2DSetRotation : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Rotation")]
		[SerializeField]
		private FloatVar _setRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setRotation);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.rotation = _setRotation.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} rotation to {_setRotation}";
		}
	}
}
