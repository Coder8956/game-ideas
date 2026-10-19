
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
	public sealed class Collider2DSetContactCaptureLayers : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Set Collider2D Contact Capture Layers")]
		[SerializeField]
		private LayerMaskVar _setContactCaptureLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _setContactCaptureLayers);
		}
		
		public override void Execute()
		{
			_collider2D.Value.contactCaptureLayers = _setContactCaptureLayers.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider2D} contact capture layers to {_setContactCaptureLayers}";
		}
	}
}
