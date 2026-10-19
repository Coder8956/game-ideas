
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("Get if two Bounds are equal.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds.html")]
	public sealed class BoundsEquals : BaseAction
	{
		
		[Tooltip("The Bounds.")]
		[SerializeField]
		private BoundsRef _bounds;
		
		[Tooltip("Other.")]
		[SerializeField]
		private BoundsVar _other;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _other, _result);
		}
		
		public override void Execute()
		{
			_result.Value = BoundsApproximatelyEqual(_bounds.Value, _other.Value);
		}
		
		private static bool BoundsApproximatelyEqual(Bounds a, Bounds b, float epsilon = 1e-5f)
		{
			// Compare center and size with tolerance.
			var dc = a.center - b.center;
			var ds = a.size - b.size;
			var e2 = epsilon * epsilon;
			return dc.sqrMagnitude <= e2 && ds.sqrMagnitude <= e2;
		}

		
		public override string GetSummary()
		{
			return "{_bounds} equals {_other} -> {_result}";
		}
	}
}
