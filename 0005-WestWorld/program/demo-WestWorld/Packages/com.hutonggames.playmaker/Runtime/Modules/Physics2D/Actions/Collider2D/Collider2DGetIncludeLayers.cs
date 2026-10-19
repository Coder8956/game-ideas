
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
	public sealed class Collider2DGetIncludeLayers : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Get Collider2D Include Layers")]
		[SerializeField]
		[WriteOnly]
		private LayerMaskRef _getIncludeLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _getIncludeLayers);
		}
		
		public override void Execute()
		{
			_getIncludeLayers.Value = _collider2D.Value.includeLayers;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} include layers -> {_getIncludeLayers}";
		}
	}
}
