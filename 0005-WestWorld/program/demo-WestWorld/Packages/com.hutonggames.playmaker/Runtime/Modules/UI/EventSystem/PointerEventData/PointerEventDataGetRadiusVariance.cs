
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("The accuracy of the touch radius.\nRemarks:\nAdd this value to the radius to get the maximum touch radius, subtract it to get the minimum touch radius.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetRadiusVariance : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Radius Variance")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getRadiusVariance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getRadiusVariance);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getRadiusVariance.Value = _pointerEventData.Value.radiusVariance;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} radius variance -> {_getRadiusVariance}";
		}
	}
}
