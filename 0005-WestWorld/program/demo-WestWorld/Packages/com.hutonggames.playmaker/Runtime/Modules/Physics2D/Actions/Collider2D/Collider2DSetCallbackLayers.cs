
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
	public sealed class Collider2DSetCallbackLayers : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Set Collider2D Callback Layers")]
		[SerializeField]
		private LayerMaskVar _setCallbackLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _setCallbackLayers);
		}
		
		public override void Execute()
		{
			_collider2D.Value.callbackLayers = _setCallbackLayers.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider2D} callback layers to {_setCallbackLayers}";
		}
	}
}
