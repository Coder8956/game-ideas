
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
	public sealed class ColliderSetExcludeLayers : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Set Collider Exclude Layers")]
		[SerializeField]
		private LayerMaskVar _setExcludeLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _setExcludeLayers);
		}
		
		public override void Execute()
		{
			_collider.Value.excludeLayers = _setExcludeLayers.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider} exclude layers to {_setExcludeLayers}";
		}
	}
}
