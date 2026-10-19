
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Noise)]
	[ActionDescription("Sample 1D Perlin noise at an X coordinate. Perlin noise is deterministic: the same X value returns the same result. Nearby X values return smoothly changing values, usually between 0 and 1. " +
	                   "\n\nNOTE: This samples the 2D Perlin noise plane at Y=0, which can produce flat sections; use Mathf Perlin Noise with a non-zero Y value for smoother 1D curves.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.PerlinNoise1D.html")]
	public sealed class MathfPerlinNoise1D : BaseAction
	{
		
		[Tooltip("X-coordinate of the sample point. Change this value over time to move through the noise pattern.")]
		[SerializeField]
		private FloatVar _x;
		
		[Tooltip("Store the sampled noise value. Results are usually between 0 and 1.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_x, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.PerlinNoise1D(System.Single);
			_result.Value = Mathf.PerlinNoise1D(_x.Value);
		}
		
		public override string GetSummary()
		{
			return "Sample Perlin noise at ({_x}, 0) -> {_result}";
		}
	}
}
