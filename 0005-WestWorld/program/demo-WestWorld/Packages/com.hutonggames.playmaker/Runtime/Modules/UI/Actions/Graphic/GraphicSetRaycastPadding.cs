
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("Padding to be applied to the masking X = Left Y = Bottom Z = Right W = Top")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicSetRaycastPadding : BaseAction
	{
		
		[Tooltip("The Graphic")]
		[SerializeField]
		private GraphicVar _graphic;
		
		[Tooltip("Set Graphic Raycast Padding")]
		[SerializeField]
		private Vector4Var _setRaycastPadding;
		
		public override bool CanExecute()
		{
			return CheckParameters(_graphic, _setRaycastPadding);
		}
		
		public override void Execute()
		{
			_graphic.Value.raycastPadding = _setRaycastPadding.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_graphic} raycast padding to {_setRaycastPadding}";
		}
	}
}
