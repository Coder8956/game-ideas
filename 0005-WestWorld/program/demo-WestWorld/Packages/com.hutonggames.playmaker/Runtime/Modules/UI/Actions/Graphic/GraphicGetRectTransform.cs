
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("The RectTransform component used by the Graphic.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicGetRectTransform : BaseAction
	{
		
		[Tooltip("The Graphic")]
		[SerializeField]
		private GraphicVar _graphic;
		
		[Tooltip("Get Graphic Rect Transform")]
		[SerializeField]
		[WriteOnly]
		private RectTransformVar _getRectTransform;
		
		public override bool CanExecute()
		{
			return CheckParameters(_graphic, _getRectTransform);
		}
		
		public override void Execute()
		{
			_getRectTransform.Value = _graphic.Value.rectTransform;
		}
		
		public override string GetSummary()
		{
			return "Get {_graphic} rect transform -> {_getRectTransform}";
		}
	}
}
