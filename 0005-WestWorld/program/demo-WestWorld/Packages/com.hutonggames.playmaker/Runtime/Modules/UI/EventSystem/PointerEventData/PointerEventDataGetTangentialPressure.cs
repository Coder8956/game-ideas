
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("The pressure applied to an additional pressure-sensitive control on the stylus.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetTangentialPressure : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Tangential Pressure")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getTangentialPressure;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getTangentialPressure);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getTangentialPressure.Value = _pointerEventData.Value.tangentialPressure;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} tangential pressure -> {_getTangentialPressure}";
		}
	}
}
