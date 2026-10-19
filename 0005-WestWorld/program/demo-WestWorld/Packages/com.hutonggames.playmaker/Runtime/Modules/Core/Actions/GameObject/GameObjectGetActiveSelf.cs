
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameObject)]
	[ActionDescription("The local active state of this GameObject. (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-activeSelf.html")]
	public sealed class GameObjectGetActiveSelf : BaseAction
	{
		
		[Tooltip("The GameObject")]
		[SerializeField]
		private GameObjectVar _gameObject;
		
		[Tooltip("Get GameObject Active Self")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getActiveSelf;
		
		public override bool CanExecute()
		{
			return CheckParameters(_gameObject, _getActiveSelf);
		}
		
		public override void Execute()
		{
			_getActiveSelf.Value = _gameObject.Value.activeSelf;
		}
		
		public override string GetSummary()
		{
			return "Get {_gameObject} active self -> {_getActiveSelf}";
		}
	}
}
