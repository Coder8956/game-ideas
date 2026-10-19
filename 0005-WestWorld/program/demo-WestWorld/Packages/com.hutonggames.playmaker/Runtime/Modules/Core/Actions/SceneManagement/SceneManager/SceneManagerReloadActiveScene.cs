using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[ActionDescription("Reloads the active scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html")]
	public sealed class SceneManagerReloadActiveScene : BaseAction
	{
		public override void Execute()
		{
			var currentSceneName = SceneManager.GetActiveScene().name;
			
			#if UNITY_EDITOR

			// Try to keep selection across reload (to keep debugging the FSM)
			var component = State.Fsm.Component as BaseComponent;
			var guid = component ? component.Guid : SerializableGuid.None;
			EditorApplication.delayCall += () =>
			{
				if (BaseComponent.TryGetByGuid(guid, out var component))
				{
					Selection.activeGameObject = component.gameObject;
				}
			};
			
			#endif
			
			SceneManager.LoadScene(currentSceneName);
		}
		
		public override string GetSummary() => "Reload active scene";
	}
}
