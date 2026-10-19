
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision)]
	[ActionDescription("The ArticulationBody of the collider that your GameObject collides with (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision-articulationBody.html")]
	public sealed class CollisionGetArticulationBody : BaseAction
	{
		
		[Tooltip("The Collision")]
		[SerializeField]
		private CollisionRef _collision;
		
		[Tooltip("Get Collision Articulation Body")]
		[SerializeField]
		[WriteOnly]
		private ArticulationBodyRef _getArticulationBody;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision, _getArticulationBody);
		}
		
		public override void Execute()
		{
			_getArticulationBody.Value = _collision.Value.articulationBody;
		}
		
		public override string GetSummary()
		{
			return "Get {_collision} articulationBody -> {_getArticulationBody}";
		}
	}
}
