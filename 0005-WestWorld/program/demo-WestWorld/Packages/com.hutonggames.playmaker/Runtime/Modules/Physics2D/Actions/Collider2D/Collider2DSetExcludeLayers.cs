
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("The additional Layers that this Collider2D should exclude when deciding if a cont" +
		"act with another Collider2D should happen or not.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-excludeLayers.html")]
	public sealed class Collider2DSetExcludeLayers : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Set Collider2D Exclude Layers")]
		[SerializeField]
		private LayerMaskVar _setExcludeLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _setExcludeLayers);
		}
		
		public override void Execute()
		{
			_collider2D.Value.excludeLayers = _setExcludeLayers.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider2D} exclude layers to {_setExcludeLayers}";
		}
	}
}
