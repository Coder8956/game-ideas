
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("The rotation of the stylus around its axis, in radians.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetTwist : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Twist")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getTwist;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getTwist);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getTwist.Value = _pointerEventData.Value.twist;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} twist -> {_getTwist}";
		}
	}
}
