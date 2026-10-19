
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Checks whether any of the collider(s) attached to this rigidbody are touching any" +
		" colliders on the specified layerMask or not.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.IsTouchingLayers.html")]
	public sealed class Rigidbody2DIsTouchingLayers : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
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
			return CheckParameters(_rigidbody2D, _layerMask, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody2D.IsTouchingLayers(System.Int32);
			_result.Value = _rigidbody2D.Value.IsTouchingLayers(_layerMask.Value);
		}
		
		public override string GetSummary()
		{
			return "Check {_rigidbody2D} is touching layers {_layerMask} -> {_result}";
		}
	}
}
