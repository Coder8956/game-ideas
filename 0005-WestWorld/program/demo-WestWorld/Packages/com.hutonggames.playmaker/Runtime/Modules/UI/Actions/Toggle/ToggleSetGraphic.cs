
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Toggle)]
	[ActionDescription("Graphic affected by the toggle.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Toggle.html")]
	public sealed class ToggleSetGraphic : BaseAction
	{
		
		[Tooltip("The Toggle")]
		[SerializeField]
		private ToggleVar _toggle;
		
		[Tooltip("Set Toggle Graphic")]
		[SerializeField, CanBeNullOrEmpty]
		private GraphicVar _setGraphic;
		
		public override bool CanExecute()
		{
			return CheckParameters(_toggle);
		}
		
		public override void Execute()
		{
			_toggle.Value.graphic = _setGraphic.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_toggle} graphic to {_setGraphic}";
		}
	}
}
