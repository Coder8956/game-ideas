
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Debug)]
	[ActionDescription("Draws a rect in world space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Debug.DrawLine.html")]
	public sealed class DebugDrawRect : BaseAction
	{
		[Tooltip("Rect in world space.")]
		[SerializeField]
		private RectVar _rect;
		
		[DefaultValue("Color.white")]
		[Tooltip("Color of the line.")]
		[SerializeField]
		private ColorVar _color;

		[Tooltip("Draw lines across the corners.")]
		[SerializeField]
		private BoolVar _drawCross;
		
		[DefaultValue(1f)]
		[Tooltip("How long the line should be visible for in seconds.")]
		[SerializeField]
		private FloatVar _duration;
		
		[DefaultValue(true)]
		[Tooltip("Should the line be obscured by other objects in the scene?")]
		[SerializeField]
		private BoolVar _depthTest;
		
		public Color Color => _color.Value;
		
		public override bool CanExecute() => CheckParameters(_rect, _color, _duration, _depthTest);

		public override void Execute()
		{
			// Duration should be zero if updated every frame
			var duration = UpdateMode.HasFlag(UpdateMode.EveryFrame) ? 0 : _duration.Value;
			DoDrawRect(duration);
		} 
			
		public override void OnStop()
		{
			// Draw the line one last time with the full duration
			DoDrawRect(_duration.Value);
		}

		private void DoDrawRect(float duration)
		{
			var rect = _rect.Value;
			Debug.DrawLine(rect.min, new Vector2(rect.xMax, rect.yMin), Color, duration, _depthTest.Value);
			Debug.DrawLine(new Vector2(rect.xMax, rect.yMin), rect.max, Color, duration, _depthTest.Value);
			Debug.DrawLine(rect.max, new Vector2(rect.xMin, rect.yMax), Color, duration, _depthTest.Value);
			Debug.DrawLine(new Vector2(rect.xMin, rect.yMax), rect.min, Color, duration, _depthTest.Value);
			
			if (_drawCross.Value)
			{
				Debug.DrawLine(rect.min, rect.max, Color, duration, _depthTest.Value);
				Debug.DrawLine(new Vector2(rect.xMin, rect.yMax), new Vector2(rect.xMax, rect.yMin), Color, duration, _depthTest.Value);
			}
			
		}

		public override string GetSummary() => "Draw {_color} {_rect}";
	}
}
