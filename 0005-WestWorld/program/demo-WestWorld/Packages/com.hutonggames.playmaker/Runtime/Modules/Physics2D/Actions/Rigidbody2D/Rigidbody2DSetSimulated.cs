
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Indicates whether the rigid body should be simulated or not by the physics system" +
		".")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-simulated.html")]
	public sealed class Rigidbody2DSetSimulated : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Simulated")]
		[SerializeField]
		private BoolVar _setSimulated;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setSimulated);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.simulated = _setSimulated.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} simulated to {_setSimulated}";
		}
	}
}
