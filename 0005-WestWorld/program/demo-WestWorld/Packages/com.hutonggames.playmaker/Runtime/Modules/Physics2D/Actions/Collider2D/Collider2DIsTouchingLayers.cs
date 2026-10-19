
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("Checks whether this collider is touching any colliders on the specified layerMask" +
		" or not.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D.IsTouchingLayers.html")]
	public sealed class Collider2DIsTouchingLayers : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate;
		
		[Tooltip("The Collider2D.")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Any colliders on any of these layers count as touching.")]
		[SerializeField]
		[DefaultValue(Physics2D.AllLayers)]
		private LayerMaskVar _layerMask;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _layerMask, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Collider2D.IsTouchingLayers(System.Int32);
			_result.Value = _collider2D.Value.IsTouchingLayers(_layerMask.Value);
		}
		
		public override string GetSummary()
		{
			return "Check {_collider2D} is touching layers {_layerMask} -> {_result}";
		}
	}
}
