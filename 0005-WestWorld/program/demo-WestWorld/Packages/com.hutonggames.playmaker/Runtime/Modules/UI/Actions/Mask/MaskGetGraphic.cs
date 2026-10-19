
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Mask)]
	[ActionDescription("The graphic associated with the Mask.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Mask.html")]
	public sealed class MaskGetGraphic : BaseAction
	{
		
		[Tooltip("The Mask")]
		[SerializeField]
		private MaskVar _mask;
		
		[Tooltip("Get Mask Graphic")]
		[SerializeField]
		[WriteOnly]
		private GraphicVar _getGraphic;
		
		public override bool CanExecute()
		{
			return CheckParameters(_mask, _getGraphic);
		}
		
		public override void Execute()
		{
			_getGraphic.Value = _mask.Value.graphic;
		}
		
		public override string GetSummary()
		{
			return "Get {_mask} graphic -> {_getGraphic}";
		}
	}
}
