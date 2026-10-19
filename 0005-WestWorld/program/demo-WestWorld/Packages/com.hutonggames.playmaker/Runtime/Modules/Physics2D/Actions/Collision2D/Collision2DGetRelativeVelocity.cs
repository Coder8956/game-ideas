
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision2D)]
	[ActionDescription("The relative linear velocity of the two colliding objects (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision2D-relativeVelocity.html")]
	public sealed class Collision2DGetRelativeVelocity : BaseAction
	{
		
		[Tooltip("The Collision2D")]
		[SerializeField]
		private Collision2DRef _collision2D;
		
		[Tooltip("Get Collision2D Relative Velocity")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getRelativeVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision2D, _getRelativeVelocity);
		}
		
		public override void Execute()
		{
			_getRelativeVelocity.Value = _collision2D.Value.relativeVelocity;
		}
		
		public override string GetSummary()
		{
			return "Get {_collision2D} relativeVelocity -> {_getRelativeVelocity}";
		}
	}
}
