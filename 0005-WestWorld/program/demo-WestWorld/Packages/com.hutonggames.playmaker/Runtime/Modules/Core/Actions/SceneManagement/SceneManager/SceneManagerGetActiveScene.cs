
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[ActionDescription("Gets the currently active Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.GetActiveScene.html")]
	public sealed class SceneManagerGetActiveScene : BaseAction
	{
		
		[Tooltip("Store the result in Scene variable.")]
		[SerializeField]
		[WriteOnly]
		private SceneRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_result);
		}
		
		public override void Execute()
		{
			//UnityEngine.SceneManagement.SceneManager.GetActiveScene();
			_result.Value = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
		}
		
		public override string GetSummary()
		{
			return "Get active scene -> {_result}";
		}
	}
}
