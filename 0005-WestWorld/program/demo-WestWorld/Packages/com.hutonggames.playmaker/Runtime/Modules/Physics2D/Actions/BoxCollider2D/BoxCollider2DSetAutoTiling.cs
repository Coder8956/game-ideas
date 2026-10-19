
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
	public sealed class BoxCollider2DSetAutoTiling : BaseAction
	{
		
		[Tooltip("The BoxCollider2D")]
		[SerializeField]
		private BoxCollider2DVar _boxCollider2D;
		
		[Tooltip("Set BoxCollider2D Auto Tiling")]
		[SerializeField]
		private BoolVar _setAutoTiling;
		
		public override bool CanExecute()
		{
			return CheckParameters(_boxCollider2D, _setAutoTiling);
		}
		
		public override void Execute()
		{
			_boxCollider2D.Value.autoTiling = _setAutoTiling.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_boxCollider2D} Auto Tiling to {_setAutoTiling}";
		}
	}
}
