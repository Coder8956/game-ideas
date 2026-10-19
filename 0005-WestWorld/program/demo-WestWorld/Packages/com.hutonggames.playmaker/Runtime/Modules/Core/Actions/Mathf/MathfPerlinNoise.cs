
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Noise)]
	[ActionDescription("Sample 2D Perlin noise at X,Y coordinates. Perlin noise is deterministic: the same X,Y values return the same result. Nearby coordinates return smoothly changing values, usually between 0 and 1.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.PerlinNoise.html")]
	public sealed class MathfPerlinNoise : BaseAction
	{
		
		[Tooltip("X-coordinate of the sample point. Change this value over time to move through the noise pattern.")]
		[SerializeField]
		private FloatVar _x;
		
		[Tooltip("Y-coordinate of the sample point. Use this as a second dimension, or as an offset to get a different noise line.")]
		[SerializeField]
		private FloatVar _y;
		
		[Tooltip("Store the sampled noise value. Results are usually between 0 and 1.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_x, _y, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.PerlinNoise(System.Single, System.Single);
			_result.Value = Mathf.PerlinNoise(_x.Value, _y.Value);
		}
		
		public override string GetSummary()
		{
			return "Sample Perlin noise at ({_x}, {_y}) -> {_result}";
		}
	}
}
