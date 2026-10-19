
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("The layers of other Collider2D involved in contacts with this Collider2D that wil" +
		"l be captured.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-contactCaptureLayers.html")]
	public sealed class Collider2DGetContactCaptureLayers : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Get Collider2D Contact Capture Layers")]
		[SerializeField]
		[WriteOnly]
		private LayerMaskRef _getContactCaptureLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _getContactCaptureLayers);
		}
		
		public override void Execute()
		{
			_getContactCaptureLayers.Value = _collider2D.Value.contactCaptureLayers;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} contact capture layers -> {_getContactCaptureLayers}";
		}
	}
}
