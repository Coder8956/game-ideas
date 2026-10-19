
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("The Layers that this Collider2D will report collision or trigger callbacks for du" +
		"ring a contact with another Collider2D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-callbackLayers.html")]
	public sealed class Collider2DGetCallbackLayers : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Get Collider2D Callback Layers")]
		[SerializeField]
		[WriteOnly]
		private LayerMaskRef _getCallbackLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _getCallbackLayers);
		}
		
		public override void Execute()
		{
			_getCallbackLayers.Value = _collider2D.Value.callbackLayers;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} callback layers -> {_getCallbackLayers}";
		}
	}
}
