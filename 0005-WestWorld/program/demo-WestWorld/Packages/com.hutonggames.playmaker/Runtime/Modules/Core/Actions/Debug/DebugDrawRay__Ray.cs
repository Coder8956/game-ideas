
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Debug)]
	[ActionDescription("Debug a Ray variable by drawing it.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Debug.DrawRay.html")]
	public sealed class DebugDrawRay__Ray : BaseAction
	{
		[Tooltip("The Ray to draw.")]
		[SerializeField] 
		private RayRef _ray;

		[Tooltip("The length of the ray. Note, Rays have infinite length, this is just for debugging.")]
		[SerializeField, DefaultValue(100f)]
		private FloatVar _length;
		
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

		public Color Color => _color.Value;
		
		public override bool CanExecute() => CheckParameters(_ray, _color, _duration, _depthTest);
		
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
			Debug.DrawRay(_ray.Value.origin, _ray.Value.direction * _length.Value , _color.Value, duration, _depthTest.Value);
		}
		
		public override string GetSummary() => "Draw Ray:{_color} {_ray} Length: {_length}";
	}
}
