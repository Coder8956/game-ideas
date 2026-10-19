
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision)]
	[ActionDescription("The total impulse applied to this contact pair to resolve the collision.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision-impulse.html")]
	public sealed class CollisionGetImpulse : BaseAction
	{
		
		[Tooltip("The Collision")]
		[SerializeField]
		private CollisionRef _collision;
		
		[Tooltip("Get Collision Impulse")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getImpulse;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision, _getImpulse);
		}
		
		public override void Execute()
		{
			_getImpulse.Value = _collision.Value.impulse;
		}
		
		public override string GetSummary()
		{
			return "Get {_collision} impulse -> {_getImpulse}";
		}
	}
}
