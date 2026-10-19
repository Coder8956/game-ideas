
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("A decision priority assigned to this Collider2D used when there is a conflicting " +
		"decision on whether a contact between itself and another Collision2D should happ" +
		"en or not.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-layerOverridePriority.html")]
	public sealed class Collider2DSetLayerOverridePriority : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Set Collider2D Layer Override Priority")]
		[SerializeField]
		private IntegerVar _setLayerOverridePriority;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _setLayerOverridePriority);
		}
		
		public override void Execute()
		{
			_collider2D.Value.layerOverridePriority = _setLayerOverridePriority.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider2D} layer override priority to {_setLayerOverridePriority}";
		}
	}
}
