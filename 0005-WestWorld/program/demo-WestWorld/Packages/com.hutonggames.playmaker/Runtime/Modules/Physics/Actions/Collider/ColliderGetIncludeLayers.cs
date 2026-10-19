
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
	public sealed class ColliderGetIncludeLayers : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Get Collider Include Layers")]
		[SerializeField]
		[WriteOnly]
		private LayerMaskRef _getIncludeLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _getIncludeLayers);
		}
		
		public override void Execute()
		{
			_getIncludeLayers.Value = _collider.Value.includeLayers;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider} include layers -> {_getIncludeLayers}";
		}
	}
}
