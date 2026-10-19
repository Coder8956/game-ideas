
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("The additional Layers that this Collider2D should include when deciding if a cont" +
		"act with another Collider2D should happen or not.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-includeLayers.html")]
	public sealed class Collider2DSetIncludeLayers : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Set Collider2D Include Layers")]
		[SerializeField]
		private LayerMaskVar _setIncludeLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _setIncludeLayers);
		}
		
		public override void Execute()
		{
			_collider2D.Value.includeLayers = _setIncludeLayers.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider2D} include layers to {_setIncludeLayers}";
		}
	}
}
