
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameObject)]
	[ActionDescription("Defines whether the GameObject is active in the Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-activeInHierarchy.html")]
	public sealed class GameObjectGetActiveInHierarchy : BaseAction
	{
		
		[Tooltip("The GameObject")]
		[SerializeField]
		private GameObjectVar _gameObject;
		
		[Tooltip("Get GameObject Active In Hierarchy")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getActiveInHierarchy;
		
		public override bool CanExecute()
		{
			return CheckParameters(_gameObject, _getActiveInHierarchy);
		}
		
		public override void Execute()
		{
			_getActiveInHierarchy.Value = _gameObject.Value.activeInHierarchy;
		}
		
		public override string GetSummary()
		{
			return "Get {_gameObject} active in hierarchy -> {_getActiveInHierarchy}";
		}
	}
}
