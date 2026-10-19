
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PolygonCollider2D)]
	[ActionDescription("Determines whether the PolygonCollider2D\'s shape is automatically updated based o" +
		"n a SpriteRenderer\'s tiling properties.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PolygonCollider2D-autoTiling.html")]
	public sealed class PolygonCollider2DSetAutoTiling : BaseAction
	{
		
		[Tooltip("The PolygonCollider2D")]
		[SerializeField]
		private PolygonCollider2DVar _polygonCollider2D;
		
		[Tooltip("Set PolygonCollider2D Auto Tiling")]
		[SerializeField]
		private BoolVar _setAutoTiling;
		
		public override bool CanExecute()
		{
			return CheckParameters(_polygonCollider2D, _setAutoTiling);
		}
		
		public override void Execute()
		{
			_polygonCollider2D.Value.autoTiling = _setAutoTiling.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_polygonCollider2D} Auto Tiling to {_setAutoTiling}";
		}
	}
}
