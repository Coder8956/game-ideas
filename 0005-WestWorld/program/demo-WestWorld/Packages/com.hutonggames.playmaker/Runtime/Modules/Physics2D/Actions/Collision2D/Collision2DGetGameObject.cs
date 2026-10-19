
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision2D)]
	[ActionDescription("The incoming GameObject involved in the collision.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision2D-gameObject.html")]
	public sealed class Collision2DGetGameObject : BaseAction
	{
		
		[Tooltip("The Collision2D")]
		[SerializeField]
		private Collision2DRef _collision2D;
		
		[Tooltip("Get Collision2D GameObject")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _getGameObject;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision2D, _getGameObject);
		}
		
		public override void Execute()
		{
			_getGameObject.Value = _collision2D.Value.gameObject;
		}
		
		public override string GetSummary()
		{
			return "Get {_collision2D} gameObject -> {_getGameObject}";
		}
	}
}
