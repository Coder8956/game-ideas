
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Casts a line against Colliders in the Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.LinecastAll.html")]
	public sealed class Physics2DLinecastAll : BaseAction
	{
		
		[Tooltip("The start point of the line in world space.")]
		[SerializeField]
		private Vector2Var _start;
		
		[Tooltip("The end point of the line in world space.")]
		[SerializeField]
		private Vector2Var _end;
		
		[ActionHeader("Filter")]
		
		[Tooltip("Filter to check objects only on specific layers.")]
		[SerializeField]
		[DefaultValue("~Physics2DDefaultRaycastLayers")]
		private LayerMaskVar _layerMask;

		[Tooltip("Only include objects with a Z coordinate (depth) greater than or equal to this value.")]
		[SerializeField]
		[DefaultValue("~FloatNegativeInfinity")]
		private FloatVar _minDepth;
		
		[Tooltip("Only include objects with a Z coordinate (depth) less than or equal to this value.")]
		[SerializeField]
		[DefaultValue("~FloatPositiveInfinity")]
		private FloatVar _maxDepth;
		
		[ActionHeader("Results")]
		
		[Tooltip("Store the result in RaycastHit2D List variable.")]
		[SerializeField]
		[WriteOnly]
		private RaycastHit2DListRef _results;
		
		public override bool CanExecute()
		{
			return CheckParameters(_start, _end, _layerMask, _minDepth, _maxDepth, _results);
		}
		
		public override void Execute()
		{
			_results.Values = Physics2D.LinecastAll(_start.Value, _end.Value, _layerMask.Value, _minDepth.Value, _maxDepth.Value);
		}
		
		public override string GetSummary()
		{
			return "Physics2D LinecastAll: {_start} {_end} {_layerMask} -> {_results}";
		}
	}
}
