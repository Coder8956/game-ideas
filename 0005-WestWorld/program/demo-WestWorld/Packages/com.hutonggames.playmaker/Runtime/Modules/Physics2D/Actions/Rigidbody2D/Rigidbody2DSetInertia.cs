
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The Rigidbody\'s resistance to changes in angular velocity (rotation).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-inertia.html")]
	public sealed class Rigidbody2DSetInertia : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Inertia")]
		[SerializeField]
		private FloatVar _setInertia;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setInertia);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.inertia = _setInertia.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} inertia to {_setInertia}";
		}
	}
}
