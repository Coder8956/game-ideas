
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.BaseEventData)]
	[ActionDescription("The object currently considered selected by the EventSystem.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.EventSystems.BaseEventData.html")]
	public sealed class BaseEventDataGetSelectedObject : BaseAction
	{
		
		[Tooltip("The BaseEventData")]
		[SerializeField]
		private BaseEventDataRef _baseEventData;
		
		[Tooltip("Get BaseEventData Selected Object")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _getSelectedObject;
		
		public override bool CanExecute()
		{
			return CheckParameters(_baseEventData, _getSelectedObject);
		}
		
		public override void Execute()
		{
			_getSelectedObject.Value = _baseEventData.Value.selectedObject;
		}
		
		public override string GetSummary()
		{
			return "Get {_baseEventData} selected object -> {_getSelectedObject}";
		}
	}
}
