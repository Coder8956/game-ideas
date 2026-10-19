
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("Does ray intersect this bounding box?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds.IntersectRay.html")]
	public sealed class BoundsIntersectRay : BaseAction
	{
		
		[Tooltip("The Bounds.")]
		[SerializeField]
		private BoundsRef _bounds;
		
		[Tooltip("Ray.")]
		[SerializeField]
		private RayVar _ray;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _ray, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Bounds.IntersectRay(UnityEngine.Ray);
			_result.Value = _bounds.Value.IntersectRay(_ray.Value);
		}
		
		public override string GetSummary()
		{
			return "Doe {_ray} intersect {_bounds} -> {_result}";
		}
	}
}
