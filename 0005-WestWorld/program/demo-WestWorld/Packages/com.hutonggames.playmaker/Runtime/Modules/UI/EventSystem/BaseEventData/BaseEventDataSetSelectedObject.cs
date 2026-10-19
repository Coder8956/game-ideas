
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.BaseEventData)]
	[ActionDescription("The object currently considered selected by the EventSystem.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.EventSystems.BaseEventData.html")]
	public sealed class BaseEventDataSetSelectedObject : BaseAction
	{
		
		[Tooltip("The BaseEventData")]
		[SerializeField]
		private BaseEventDataRef _baseEventData;
		
		[Tooltip("Set BaseEventData Selected Object")]
		[SerializeField, CanBeNullOrEmpty]
		private GameObjectVar _setSelectedObject;
		
		public override bool CanExecute()
		{
			return CheckParameters(_baseEventData);
		}
		
		public override void Execute()
		{
			_baseEventData.Value.selectedObject = _setSelectedObject.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_baseEventData} selected object to {_setSelectedObject}";
		}
	}
}
