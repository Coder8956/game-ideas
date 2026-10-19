
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider)]
	[ActionDescription("A decision priority assigned to this Collider used when there is a conflicting de" +
		"cision on whether a Collider can contact another Collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider-layerOverridePriority.html")]
	public sealed class ColliderGetLayerOverridePriority : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Get Collider Layer Override Priority")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getLayerOverridePriority;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _getLayerOverridePriority);
		}
		
		public override void Execute()
		{
			_getLayerOverridePriority.Value = _collider.Value.layerOverridePriority;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider} layer override priority -> {_getLayerOverridePriority}";
		}
	}
}
