
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("The Layers that this Collider2D is allowed to send forces to during a Collision c" +
		"ontact with another Collider2D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-forceSendLayers.html")]
	public sealed class Collider2DSetForceSendLayers : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Set Collider2D Force Send Layers")]
		[SerializeField]
		private LayerMaskVar _setForceSendLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _setForceSendLayers);
		}
		
		public override void Execute()
		{
			_collider2D.Value.forceSendLayers = _setForceSendLayers.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider2D} force send layers to {_setForceSendLayers}";
		}
	}
}
