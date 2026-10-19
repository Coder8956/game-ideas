
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Controls whether physics will change the rotation of the object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-freezeRotation.html")]
	public sealed class Rigidbody2DSetFreezeRotation : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Freeze Rotation")]
		[SerializeField]
		private BoolVar _setFreezeRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setFreezeRotation);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.freezeRotation = _setFreezeRotation.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} freeze rotation to {_setFreezeRotation}";
		}
	}
}
