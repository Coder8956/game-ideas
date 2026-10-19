
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[ActionDescription("Get the Scene at index in the SceneManager\'s list of loaded Scenes.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.GetSceneAt.html")]
	public sealed class SceneManagerGetSceneAt : BaseAction
	{
		
		[Tooltip("Index of the Scene to get. Index must be greater than or equal to 0 and less than" +
			" SceneManager.sceneCount.")]
		[SerializeField]
		private IntegerVar _index;
		
		[Tooltip("Store the result in Scene variable.")]
		[SerializeField]
		[WriteOnly]
		private SceneRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_index, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.SceneManagement.SceneManager.GetSceneAt(System.Int32);
			_result.Value = UnityEngine.SceneManagement.SceneManager.GetSceneAt(_index.Value);
		}
		
		public override string GetSummary()
		{
			return "Get scene at {_index} -> {_result}";
		}
	}
}
