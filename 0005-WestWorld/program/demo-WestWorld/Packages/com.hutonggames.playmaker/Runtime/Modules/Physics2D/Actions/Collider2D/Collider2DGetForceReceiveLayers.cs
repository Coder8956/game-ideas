
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
	public sealed class Collider2DGetForceReceiveLayers : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Get Collider2D Force Receive Layers")]
		[SerializeField]
		[WriteOnly]
		private LayerMaskRef _getForceReceiveLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _getForceReceiveLayers);
		}
		
		public override void Execute()
		{
			_getForceReceiveLayers.Value = _collider2D.Value.forceReceiveLayers;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} force receive layers -> {_getForceReceiveLayers}";
		}
	}
}
