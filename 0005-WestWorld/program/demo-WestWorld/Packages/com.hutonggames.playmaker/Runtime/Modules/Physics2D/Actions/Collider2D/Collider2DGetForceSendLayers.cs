
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
	public sealed class Collider2DGetForceSendLayers : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Get Collider2D Force Send Layers")]
		[SerializeField]
		[WriteOnly]
		private LayerMaskRef _getForceSendLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _getForceSendLayers);
		}
		
		public override void Execute()
		{
			_getForceSendLayers.Value = _collider2D.Value.forceSendLayers;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} force send layers -> {_getForceSendLayers}";
		}
	}
}
