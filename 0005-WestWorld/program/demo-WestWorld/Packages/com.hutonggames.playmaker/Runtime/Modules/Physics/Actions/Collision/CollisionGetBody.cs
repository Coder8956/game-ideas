
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision)]
	[ActionDescription("The Rigidbody or ArticulationBody of the collider that your Component collides wi" +
		"th (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision-body.html")]
	public sealed class CollisionGetBody : BaseAction
	{
		
		[Tooltip("The Collision")]
		[SerializeField]
		private CollisionRef _collision;
		
		[Tooltip("Get Collision Body")]
		[SerializeField]
		[WriteOnly]
		private ComponentRef _getBody;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision, _getBody);
		}
		
		public override void Execute()
		{
			_getBody.Value = _collision.Value.body;
		}
		
		public override string GetSummary()
		{
			return "Get {_collision} body -> {_getBody}";
		}
	}
}
