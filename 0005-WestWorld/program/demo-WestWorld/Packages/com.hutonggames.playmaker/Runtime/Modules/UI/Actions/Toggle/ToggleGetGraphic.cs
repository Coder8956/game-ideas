
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Toggle)]
	[ActionDescription("Graphic affected by the toggle.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Toggle.html")]
	public sealed class ToggleGetGraphic : BaseAction
	{
		
		[Tooltip("The Toggle")]
		[SerializeField]
		private ToggleVar _toggle;
		
		[Tooltip("Get Toggle Graphic")]
		[SerializeField]
		[WriteOnly]
		private GraphicRef _getGraphic;
		
		public override bool CanExecute()
		{
			return CheckParameters(_toggle, _getGraphic);
		}
		
		public override void Execute()
		{
			_getGraphic.Value = _toggle.Value.graphic;
		}
		
		public override string GetSummary()
		{
			return "Get {_toggle} graphic -> {_getGraphic}";
		}
	}
}
