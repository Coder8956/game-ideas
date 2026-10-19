
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[ActionDescription("Move a GameObject from its current Scene to a new Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.MoveGameObjectToScene.html")]
	public sealed class SceneManagerMoveGameObjectToScene : BaseAction
	{
		
		[Tooltip("GameObject to move.")]
		[SerializeField]
		private GameObjectVar _go;
		
		[Tooltip("Scene to move into.")]
		[SerializeField]
		private SceneRef _scene;
		
		public override bool CanExecute()
		{
			return CheckParameters(_go, _scene);
		}
		
		public override void Execute()
		{
			//UnityEngine.SceneManagement.SceneManager.MoveGameObjectToScene(UnityEngine.GameObject, UnityEngine.SceneManagement.Scene);
			SceneManager.MoveGameObjectToScene(_go.Value, _scene.Value);
		}
		
		public override string GetSummary()
		{
			return "Move {_go} to scene {_scene}";
		}
	}
}
