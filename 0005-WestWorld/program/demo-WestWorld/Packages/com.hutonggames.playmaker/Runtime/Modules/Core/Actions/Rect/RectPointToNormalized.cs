
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("Returns the normalized coordinates cooresponding the the point.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect.PointToNormalized.html")]
	public sealed class RectPointToNormalized : BaseAction
	{
		
		[Tooltip("Rectangle to get normalized coordinates inside.")]
		[SerializeField]
		private RectVar _rectangle;
		
		[Tooltip("A point inside the rectangle to get normalized coordinates for.")]
		[SerializeField]
		private Vector2Var _point;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectangle, _point, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rect.PointToNormalized(UnityEngine.Rect, UnityEngine.Vector2);
			_result.Value = Rect.PointToNormalized(_rectangle.Value, _point.Value);
		}
		
		public override string GetSummary()
		{
			return "Rect Point To Normalized: {_rectangle} {_point} -> {_result}";
		}
	}
}
