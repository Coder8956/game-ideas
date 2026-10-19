
using JetBrains.Annotations;
using System;
using HutongGames.PlayMaker.Internal;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Should this rigidbody be taken out of physics control?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-useFullKinematicContacts.html")]
	public sealed class Rigidbody2DSetIsKinematic : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Is Kinematic")]
		[SerializeField]
		private BoolVar _setIsKinematic;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setIsKinematic);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.SetIsKinematicShim(_setIsKinematic.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} is kinematic to {_setIsKinematic}";
		}
	}
}


