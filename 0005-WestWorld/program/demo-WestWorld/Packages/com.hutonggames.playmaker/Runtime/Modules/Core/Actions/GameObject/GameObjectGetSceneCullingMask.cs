
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameObject)]
	[ActionDescription("Scene culling mask Unity uses to determine which scene to render the GameObject in.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-sceneCullingMask.html")]
	public sealed class GameObjectGetSceneCullingMask : BaseAction
	{
		
		[Tooltip("The GameObject")]
		[SerializeField]
		private GameObjectVar _gameObject;
		
		[Tooltip("Get GameObject Scene Culling Mask")]
		[SerializeField]
		[WriteOnly]
		private ULongRef _getSceneCullingMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_gameObject, _getSceneCullingMask);
		}
		
		public override void Execute()
		{
			_getSceneCullingMask.Value = _gameObject.Value.sceneCullingMask;
		}
		
		public override string GetSummary()
		{
			return "Get {_gameObject} scene culling mask -> {_getSceneCullingMask}";
		}
	}
}
