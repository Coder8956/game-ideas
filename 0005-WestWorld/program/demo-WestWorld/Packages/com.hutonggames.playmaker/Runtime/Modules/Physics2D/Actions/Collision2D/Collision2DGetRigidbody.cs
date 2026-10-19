
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision2D)]
	[ActionDescription("The incoming Rigidbody2D involved in the collision with the otherRigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision2D-rigidbody.html")]
	public sealed class Collision2DGetRigidbody : BaseAction
	{
		
		[Tooltip("The Collision2D")]
		[SerializeField]
		private Collision2DRef _collision2D;
		
		[Tooltip("Get Collision2D Rigidbody")]
		[SerializeField]
		[WriteOnly]
		private Rigidbody2DVar _getRigidbody;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision2D, _getRigidbody);
		}
		
		public override void Execute()
		{
			_getRigidbody.Value = _collision2D.Value.rigidbody;
		}
		
		public override string GetSummary()
		{
			return "Get {_collision2D} rigidbody -> {_getRigidbody}";
		}
	}
}
