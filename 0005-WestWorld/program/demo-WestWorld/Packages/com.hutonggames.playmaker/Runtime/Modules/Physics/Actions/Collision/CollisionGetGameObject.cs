
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision)]
	[ActionDescription("The GameObject whose collider you are colliding with. (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision-gameObject.html")]
	public sealed class CollisionGetGameObject : BaseAction
	{
		
		[Tooltip("The Collision")]
		[SerializeField]
		private CollisionRef _collision;
		
		[Tooltip("Get Collision GameObject")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _getGameObject;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision, _getGameObject);
		}
		
		public override void Execute()
		{
			_getGameObject.Value = _collision.Value.gameObject;
		}
		
		public override string GetSummary()
		{
			return "Get {_collision} gameObject -> {_getGameObject}";
		}
	}
}
