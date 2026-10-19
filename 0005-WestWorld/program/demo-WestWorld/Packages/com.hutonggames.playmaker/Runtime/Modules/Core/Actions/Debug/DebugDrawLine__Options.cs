
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Debug)]
	[ActionDescription("Draws a line between specified start and end points.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Debug.DrawLine.html")]
	public sealed class DebugDrawLine__Options : BaseAction
	{
		[DefaultValue(typeof(WorldPositionBlock))]
		[Tooltip("Point in world space where the line should start.")]
		[SerializeReference]
		private BasePositionBlock _start;
		
		[DefaultValue(typeof(WorldPositionBlock))]
		[Tooltip("Point in world space where the line should end.")]
		[SerializeReference]
		private BasePositionBlock _end;
		
		[DefaultValue("Color.white")]
		[Tooltip("Color of the line.")]
		[SerializeField]
		private ColorVar _color;
		
		[DefaultValue(1f)]
		[Tooltip("How long the line should be visible for in seconds.")]
		[SerializeField]
		private FloatVar _duration;
		
		[DefaultValue(true)]
		[Tooltip("Should the line be obscured by other objects in the scene?")]
		[SerializeField]
		private BoolVar _depthTest;
		
		public Vector3 StartPosition => _start.GetWorldPosition();
		public Vector3 EndPosition => _end.GetWorldPosition();
		public Color Color => _color.Value;
		
		public override bool CanExecute() => 
			_start.CanExecute() && _end.CanExecute() && 
			CheckParameters(_color, _duration, _depthTest);

		public override void Execute()
		{
			// Duration should be zero if updated every frame
			var duration = UpdateMode.HasFlag(UpdateMode.EveryFrame) ? 0 : _duration.Value;
			DoDrawLine(duration);
		} 
			
		public override void OnStop()
		{
			// Draw the ray one last time with the full duration
			DoDrawLine(_duration.Value);
		}

		private void DoDrawLine(float duration) => 
			Debug.DrawLine(_start.GetWorldPosition(), _end.GetWorldPosition(), _color.Value, duration, _depthTest.Value);
		
		public override string GetSummary() => "Draw {_color} line from {_start} to {_end}";
	}
}
