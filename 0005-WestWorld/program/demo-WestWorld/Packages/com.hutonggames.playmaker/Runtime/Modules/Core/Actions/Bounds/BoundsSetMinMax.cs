
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("Sets the bounds to the min and max value of the box.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds.SetMinMax.html")]
	public sealed class BoundsSetMinMax : BaseAction
	{
		
		[Tooltip("The Bounds.")]
		[SerializeField]
		private BoundsRef _bounds;
		
		[Tooltip("Min.")]
		[SerializeField]
		private Vector3Var _min;
		
		[Tooltip("Max.")]
		[SerializeField]
		private Vector3Var _max;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _min, _max);
		}
		
		public override void Execute()
		{
			//UnityEngine.Bounds.SetMinMax(UnityEngine.Vector3, UnityEngine.Vector3);
			_bounds.Value.SetMinMax(_min.Value, _max.Value);
		}
		
		public override string GetSummary()
		{
			return "{_bounds} set min {_min} max {_max} ";
		}
	}
}
