
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
	public sealed class Rigidbody2DGetSimulated : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Simulated")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getSimulated;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getSimulated);
		}
		
		public override void Execute()
		{
			_getSimulated.Value = _rigidbody2D.Value.simulated;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} simulated -> {_getSimulated}";
		}
	}
}
