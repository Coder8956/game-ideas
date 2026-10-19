
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("Returns a pixel perfect Rect closest to the Graphic RectTransform.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicGetPixelAdjustedRect : BaseAction
	{
		
		[Tooltip("The Graphic.")]
		[SerializeField]
		private GraphicVar _graphic;
		
		[Tooltip("Store the result in Rect variable.")]
		[SerializeField]
		[WriteOnly]
		private RectRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_graphic, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Graphic.GetPixelAdjustedRect();
			_result.Value = _graphic.Value.GetPixelAdjustedRect();
		}
		
		public override string GetSummary()
		{
			return "Get {_graphic} pixel adjusted rect -> {_result}";
		}
	}
}
