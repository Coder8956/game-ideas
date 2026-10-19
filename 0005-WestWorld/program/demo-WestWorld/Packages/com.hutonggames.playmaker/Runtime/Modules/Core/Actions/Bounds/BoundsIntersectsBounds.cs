
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("Does another bounding box intersect with this bounding box?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds.Intersects.html")]
	public sealed class BoundsIntersectsBounds : BaseAction
	{
		
		[Tooltip("The Bounds.")]
		[SerializeField]
		private BoundsRef _bounds;
		
		[Tooltip("Bounds.")]
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
			//UnityEngine.Bounds.Intersects(UnityEngine.Bounds);
			_result.Value = _bounds.Value.Intersects(_other.Value);
		}
		
		public override string GetSummary()
		{
			return "{_bounds} intersects {_other} -> {_result}";
		}
	}
}
