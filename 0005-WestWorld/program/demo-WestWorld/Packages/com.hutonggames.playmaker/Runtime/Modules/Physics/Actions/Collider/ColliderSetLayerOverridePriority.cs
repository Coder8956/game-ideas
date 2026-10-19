
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
	public sealed class ColliderSetLayerOverridePriority : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Set Collider Layer Override Priority")]
		[SerializeField]
		private IntegerVar _setLayerOverridePriority;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _setLayerOverridePriority);
		}
		
		public override void Execute()
		{
			_collider.Value.layerOverridePriority = _setLayerOverridePriority.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider} layer override priority to {_setLayerOverridePriority}";
		}
	}
}
