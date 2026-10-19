using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Scene)]
	[ActionDescription("Returns all the root game objects in the Scene. Uses an existing list to avoid allocations.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.Scene.GetRootGameObjects.html")]
	public sealed class SceneGetRootGameObjects__NonAlloc : BaseAction
	{
		
		[Tooltip("The Scene.")]
		[SerializeField]
		private SceneRef _scene;
		
		[Tooltip("A list which is used to return the root game objects. " +
		         "Please make sure the list capacity is bigger than Scene.rootCount, then Unity will not allocate memory internally.")]
		[SerializeField]
		private GameObjectListRef _rootGameObjects;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scene, _rootGameObjects);
		}
		
		public override void Execute()
		{
			_scene.Value.GetRootGameObjects(_rootGameObjects.Value);
		}
		
		public override string GetSummary()
		{
			return "Get {_scene} root GameObjects -> {_rootGameObjects}";
		}
	}
}
