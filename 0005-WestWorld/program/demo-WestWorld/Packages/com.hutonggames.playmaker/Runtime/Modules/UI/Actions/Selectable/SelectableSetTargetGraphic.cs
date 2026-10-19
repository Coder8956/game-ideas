
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Selectable)]
	[ActionDescription("Graphic that will be transitioned upon.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Selectable.html")]
	public sealed class SelectableSetTargetGraphic : BaseAction
	{
		
		[Tooltip("The Selectable")]
		[SerializeField]
		private SelectableVar _selectable;
		
		[Tooltip("Set Selectable Target Graphic")]
		[SerializeField, CanBeNullOrEmpty]
		private GraphicVar _setTargetGraphic;
		
		public override bool CanExecute()
		{
			return CheckParameters(_selectable);
		}
		
		public override void Execute()
		{
			_selectable.Value.targetGraphic = _setTargetGraphic.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_selectable} target graphic to {_setTargetGraphic}";
		}
	}
}
