
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[ActionDescription("Searches through the Scenes loaded for a Scene with the given name.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.GetSceneByName.html")]
	public sealed class SceneManagerGetSceneByName : BaseAction
	{
		
		[Tooltip("Name of Scene to find.")]
		[SerializeField]
		private StringVar _name;
		
		[Tooltip("Store the result in Scene variable.")]
		[SerializeField]
		[WriteOnly]
		private SceneRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_name, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.SceneManagement.SceneManager.GetSceneByName(System.String);
			_result.Value = UnityEngine.SceneManagement.SceneManager.GetSceneByName(_name.Value);
		}
		
		public override string GetSummary()
		{
			return "Get scene by name {_name} -> {_result}";
		}
	}
}
