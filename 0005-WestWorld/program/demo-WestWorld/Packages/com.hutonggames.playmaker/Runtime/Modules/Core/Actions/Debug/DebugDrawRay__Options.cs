
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Debug)]
	[ActionDescription("Draws a line from start to start + dir in world coordinates.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Debug.DrawRay.html")]
	public sealed class DebugDrawRay__Options : BaseAction
	{
		[DefaultValue(typeof(WorldPositionBlock))]
		[Tooltip("Point in world space where the ray should start.")]
		[SerializeReference]
		private BasePositionBlock _start;
		
		[DefaultValue(typeof(VectorDirectionBlock))]
		[Tooltip("Direction and length of the ray.")]
		[SerializeReference]
		private BaseDirectionBlock _direction;
		
		[DefaultValue("Color.white")]
		[Tooltip("Color of the drawn line.")]
		[SerializeField]
		private ColorVar _color;
		
		[DefaultValue(1f)]
		[Tooltip("How long the line should be visible for in seconds.")]
		[SerializeField]
		private FloatVar _duration;
		
		[Tooltip("Should the line be obscured by other objects in the scene?")]
		[SerializeField]
		private BoolVar _depthTest;
		
		public Vector3 StartPosition => _start.GetWorldPosition();

		public Vector3 EndPosition
		{
			get
			{
				if (_direction == null) return StartPosition;
				_direction.SetStartPosition(StartPosition);
				return StartPosition + _direction.GetDirection();
			}
		}

		public Color Color => _color.Value;
		
		public override bool CanExecute() => 
			_start.CanExecute() && _direction.CanExecute() &&
			CheckParameters(_color, _duration, _depthTest);

		public override void Execute()
		{
			// Duration should be zero if updated every frame
			var duration = UpdateMode.HasFlag(UpdateMode.EveryFrame) ? 0 : _duration.Value;
			DoDrawRay(duration);
		}
		
		public override void OnStop()
		{
			// Draw the ray one last time with the full duration
			DoDrawRay(_duration.Value);
		}

		private void DoDrawRay(float duration)
		{
			Debug.DrawRay(_start.GetWorldPosition(), _direction.GetDirection(), _color.Value, duration, _depthTest.Value);
		}
		
		public override string GetSummary() => "Draw Ray:{_color} {_start} dir: {_direction} ";
	}
}
