
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("Is point contained in the bounding box?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds.Contains.html")]
	public sealed class BoundsContains : BaseAction
	{
		
		[Tooltip("The Bounds.")]
		[SerializeField]
		private BoundsRef _bounds;
		
		[Tooltip("Point.")]
		[SerializeField]
		private Vector3Var _point;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _point, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Bounds.Contains(UnityEngine.Vector3);
			_result.Value = _bounds.Value.Contains(_point.Value);
		}
		
		public override string GetSummary()
		{
			return "{_bounds} contains {_point} -> {_result}";
		}
	}
}
