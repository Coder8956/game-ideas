
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.BoxCollider2D)]
	[ActionDescription("Determines whether the BoxCollider2D\'s shape is automatically updated based on a " +
		"SpriteRenderer\'s tiling properties.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/BoxCollider2D-autoTiling.html")]
	public sealed class BoxCollider2DGetAutoTiling : BaseAction
	{
		
		[Tooltip("The BoxCollider2D")]
		[SerializeField]
		private BoxCollider2DVar _boxCollider2D;
		
		[Tooltip("Get BoxCollider2D Auto Tiling")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getAutoTiling;
		
		public override bool CanExecute()
		{
			return CheckParameters(_boxCollider2D, _getAutoTiling);
		}
		
		public override void Execute()
		{
			_getAutoTiling.Value = _boxCollider2D.Value.autoTiling;
		}
		
		public override string GetSummary()
		{
			return "Get {_boxCollider2D} autoTiling -> {_getAutoTiling}";
		}
	}
}
