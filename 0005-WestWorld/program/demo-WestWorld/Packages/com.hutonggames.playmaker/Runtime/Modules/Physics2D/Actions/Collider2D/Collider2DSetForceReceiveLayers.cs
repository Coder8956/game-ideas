
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("The Layers that this Collider2D can receive forces from during a Collision contac" +
		"t with another Collider2D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-forceReceiveLayers.html")]
	public sealed class Collider2DSetForceReceiveLayers : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Set Collider2D Force Receive Layers")]
		[SerializeField]
		private LayerMaskVar _setForceReceiveLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _setForceReceiveLayers);
		}
		
		public override void Execute()
		{
			_collider2D.Value.forceReceiveLayers = _setForceReceiveLayers.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider2D} force receive layers to {_setForceReceiveLayers}";
		}
	}
}
