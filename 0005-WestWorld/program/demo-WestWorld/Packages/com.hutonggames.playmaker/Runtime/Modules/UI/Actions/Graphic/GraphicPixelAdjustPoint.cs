
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("Adjusts the given pixel to be pixel perfect.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicPixelAdjustPoint : BaseAction
	{
		
		[Tooltip("The Graphic.")]
		[SerializeField]
		private GraphicVar _graphic;
		
		[Tooltip("Local space point.")]
		[SerializeField]
		private Vector2Var _point;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_graphic, _point, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Graphic.PixelAdjustPoint(UnityEngine.Vector2);
			_result.Value = _graphic.Value.PixelAdjustPoint(_point.Value);
		}
		
		public override string GetSummary()
		{
			return "Get {_graphic} pixel adjust point {_point} -> {_result}";
		}
	}
}
