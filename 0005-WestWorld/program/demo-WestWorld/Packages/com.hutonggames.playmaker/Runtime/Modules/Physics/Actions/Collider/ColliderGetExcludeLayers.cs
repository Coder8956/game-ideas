
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider)]
	[ActionDescription("The additional layers that this Collider should exclude when deciding if the Coll" +
		"ider can contact another Collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider-excludeLayers.html")]
	public sealed class ColliderGetExcludeLayers : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Get Collider Exclude Layers")]
		[SerializeField]
		[WriteOnly]
		private LayerMaskRef _getExcludeLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _getExcludeLayers);
		}
		
		public override void Execute()
		{
			_getExcludeLayers.Value = _collider.Value.excludeLayers;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider} exclude layers -> {_getExcludeLayers}";
		}
	}
}
