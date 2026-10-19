
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Mask)]
	[ActionDescription("Show the graphic that is associated with the Mask render area.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Mask.html")]
	public sealed class MaskSetShowMaskGraphic : BaseAction
	{
		
		[Tooltip("The Mask")]
		[SerializeField]
		private MaskVar _mask;
		
		[Tooltip("Set Mask Show Mask Graphic")]
		[SerializeField]
		private BoolVar _setShowMaskGraphic;
		
		public override bool CanExecute()
		{
			return CheckParameters(_mask, _setShowMaskGraphic);
		}
		
		public override void Execute()
		{
			_mask.Value.showMaskGraphic = _setShowMaskGraphic.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_mask} show mask graphic to {_setShowMaskGraphic}";
		}
	}
}
