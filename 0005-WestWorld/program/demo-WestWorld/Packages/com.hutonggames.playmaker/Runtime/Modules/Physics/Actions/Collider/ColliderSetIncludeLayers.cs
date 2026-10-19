
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider)]
	[ActionDescription("The additional layers that this Collider should include when deciding if the Coll" +
		"ider can contact another Collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider-includeLayers.html")]
	public sealed class ColliderSetIncludeLayers : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Set Collider Include Layers")]
		[SerializeField]
		private LayerMaskVar _setIncludeLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _setIncludeLayers);
		}
		
		public override void Execute()
		{
			_collider.Value.includeLayers = _setIncludeLayers.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider} include layers to {_setIncludeLayers}";
		}
	}
}
