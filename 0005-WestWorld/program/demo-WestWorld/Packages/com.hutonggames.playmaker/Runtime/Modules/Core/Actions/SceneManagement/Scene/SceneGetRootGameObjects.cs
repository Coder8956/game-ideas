
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Scene)]
	[ActionDescription("Returns all the root game objects in the Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.Scene.GetRootGameObjects" +
		".html")]
	public sealed class SceneGetRootGameObjects : BaseAction
	{
		
		[Tooltip("The Scene.")]
		[SerializeField]
		private SceneRef _scene;
		
		[Tooltip("Store the result in GameObject List variable.")]
		[SerializeField]
		[WriteOnly]
		private GameObjectListRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scene, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.SceneManagement.Scene.GetRootGameObjects();
			_result.Values = _scene.Value.GetRootGameObjects();
		}
		
		public override string GetSummary()
		{
			return "Get {_scene} root GameObjects -> {_result}";
		}
	}
}
