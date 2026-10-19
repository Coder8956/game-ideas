
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[ActionDescription("This will merge the source Scene into the destinationScene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.MergeScenes" +
		".html")]
	public sealed class SceneManagerMergeScenes : BaseAction
	{
		
		[Tooltip("The Scene that will be merged into the destination Scene.")]
		[SerializeField]
		private SceneRef _sourceScene;
		
		[Tooltip("Existing Scene to merge the source Scene into.")]
		[SerializeField]
		private SceneRef _destinationScene;
		
		public override bool CanExecute()
		{
			return CheckParameters(_sourceScene, _destinationScene);
		}
		
		public override void Execute()
		{
			//UnityEngine.SceneManagement.SceneManager.MergeScenes(UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene);
			SceneManager.MergeScenes(_sourceScene.Value, _destinationScene.Value);
		}
		
		public override string GetSummary()
		{
			return "Merge {_sourceScene} into {_destinationScene}";
		}
	}
}
