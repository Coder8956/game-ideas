
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Checks whether the Collider is touching any Colliders on the specified layerMask " +
		"or not.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.IsTouchingLayers.html")]
	public sealed class Physics2DIsTouchingLayers : BaseAction
	{
		
		[Tooltip("Collider.")]
		[SerializeField]
		private Collider2DVar _collider;
		
		[Tooltip("Any Colliders on any of these layers count as touching.")]
		[SerializeField]
		[DefaultValue(Physics.AllLayers)]
		private LayerMaskVar _layerMask;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _layerMask, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Physics2D.IsTouchingLayers(UnityEngine.Collider2D, System.Int32);
			_result.Value = Physics2D.IsTouchingLayers(_collider.Value, _layerMask.Value);
		}
		
		public override string GetSummary()
		{
			return "Physics2D Is Touching Layers: {_collider} {_layerMask} -> {_result}";
		}
	}
}
