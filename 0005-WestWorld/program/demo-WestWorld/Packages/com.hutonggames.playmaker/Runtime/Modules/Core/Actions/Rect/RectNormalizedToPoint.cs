
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("Returns a point inside a rectangle, given normalized coordinates.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect.NormalizedToPoint.html")]
	public sealed class RectNormalizedToPoint : BaseAction
	{
		
		[Tooltip("Rectangle to get a point inside.")]
		[SerializeField]
		private RectVar _rectangle;
		
		[Tooltip("Normalized coordinates to get a point for.")]
		[SerializeField]
		private Vector2Var _normalizedRectCoordinates;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectangle, _normalizedRectCoordinates, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rect.NormalizedToPoint(UnityEngine.Rect, UnityEngine.Vector2);
			_result.Value = Rect.NormalizedToPoint(_rectangle.Value, _normalizedRectCoordinates.Value);
		}
		
		public override string GetSummary()
		{
			return "Rect Normalized To Point: {_rectangle} {_normalizedRectCoordinates} -> {_result}";
		}
	}
}
