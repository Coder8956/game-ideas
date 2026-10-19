
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("The amount of pressure currently applied by a touch.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetPressure : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Pressure")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getPressure;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getPressure);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getPressure.Value = _pointerEventData.Value.pressure;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} pressure -> {_getPressure}";
		}
	}
}
