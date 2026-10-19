
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("An estimate of the radius of a touch.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetRadius : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Radius")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getRadius;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getRadius);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getRadius.Value = _pointerEventData.Value.radius;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} radius -> {_getRadius}";
		}
	}
}
