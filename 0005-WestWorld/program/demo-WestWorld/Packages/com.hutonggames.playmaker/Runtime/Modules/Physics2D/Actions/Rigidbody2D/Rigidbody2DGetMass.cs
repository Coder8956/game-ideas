
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Mass of the Rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-mass.html")]
	public sealed class Rigidbody2DGetMass : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Mass")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMass;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getMass);
		}
		
		public override void Execute()
		{
			_getMass.Value = _rigidbody2D.Value.mass;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} mass -> {_getMass}";
		}
	}
}
