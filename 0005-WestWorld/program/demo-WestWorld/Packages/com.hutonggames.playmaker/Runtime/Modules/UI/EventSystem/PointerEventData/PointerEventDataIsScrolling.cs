
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("Is scroll being used on the input device.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataIsScrolling : BaseAction
	{
		
		[Tooltip("The PointerEventData.")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _result);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			//UnityEngine.EventSystems.PointerEventData.IsScrolling();
			_result.Value = _pointerEventData.Value.IsScrolling();
		}
		
		public override string GetSummary()
		{
			return "Check {_pointerEventData} scrolling -> {_result}";
		}
	}
}
