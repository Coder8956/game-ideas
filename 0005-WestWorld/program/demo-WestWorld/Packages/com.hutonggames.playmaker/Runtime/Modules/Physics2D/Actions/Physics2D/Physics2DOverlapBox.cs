
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Checks if a Collider falls within a box area.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.OverlapBox.html")]
	public sealed class Physics2DOverlapBox : BaseAction
	{
		
		[Tooltip("The center of the box.")]
		[SerializeField]
		private Vector2Var _point;
		
		[Tooltip("The size of the box.")]
		[SerializeField]
		private Vector2Var _size;
		
		[Tooltip("The angle of the box.")]
		[SerializeField]
		private FloatVar _angle;
		
		[ActionHeader("Filters")]
		
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
		
		[ActionHeader("Result")]
		
		[Tooltip("Store the result in Collider2D variable.")]
		[SerializeField]
		[WriteOnly]
		private Collider2DRef _result;
		
		public override bool CanExecute() => 
			CheckParameters(_point, _size, _angle, _layerMask, _minDepth, _maxDepth, _result);

		public override void Execute()
		{
			_result.Value = Physics2D.OverlapBox(
				_point.Value, _size.Value, _angle.Value, _layerMask.Value, _minDepth.Value, _maxDepth.Value);
		}
		
		public override string GetSummary() => 
			"Physics2D Overlap Box: {_point} {_size} {_angle} -> {_result}";
	}
}
