
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Scene)]
	[ActionDescription("Whether this is a valid Scene. A Scene may be invalid if, for example, you tried " +
		"to open a Scene that does not exist. In this case, the Scene returned from Edito" +
		"rSceneManager.OpenScene would return False for IsValid.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.Scene.IsValid.html")]
	public sealed class SceneIsValid : BaseAction
	{
		
		[Tooltip("The Scene.")]
		[SerializeField]
		private SceneRef _scene;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scene, _result);
		}
		
		public override void Execute()
		{
			_result.Value = _scene.Value.IsValid();
		}
		
		public override string GetSummary()
		{
			return "Check {_scene} is valid -> {_result}";
		}
	}
}
