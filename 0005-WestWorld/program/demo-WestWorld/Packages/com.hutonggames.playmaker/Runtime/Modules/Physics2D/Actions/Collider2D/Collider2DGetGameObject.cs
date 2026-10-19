
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("The game object this collider is attached to.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Component-gameObject.html")]
	public sealed class Collider2DGetGameObject : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Get Collider2D GameObject")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _getGameObject;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _getGameObject);
		}
		
		public override void Execute()
		{
			_getGameObject.Value = _collider2D.Value.gameObject;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} game object -> {_getGameObject}";
		}
	}
}
