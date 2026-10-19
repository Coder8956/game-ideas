
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CustomCollider2D)]
	[ActionDescription("The total number of custom PhysicsShape2D assigned to the Collider. (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CustomCollider2D-customShapeCount.html")]
	public sealed class CustomCollider2DGetCustomShapeCount : BaseAction
	{
		
		[Tooltip("The CustomCollider2D")]
		[SerializeField]
		private CustomCollider2DVar _customCollider2D;
		
		[Tooltip("Get CustomCollider2D Custom Shape Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getCustomShapeCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_customCollider2D, _getCustomShapeCount);
		}
		
		public override void Execute()
		{
			_getCustomShapeCount.Value = _customCollider2D.Value.customShapeCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_customCollider2D} customShapeCount -> {_getCustomShapeCount}";
		}
	}
}
