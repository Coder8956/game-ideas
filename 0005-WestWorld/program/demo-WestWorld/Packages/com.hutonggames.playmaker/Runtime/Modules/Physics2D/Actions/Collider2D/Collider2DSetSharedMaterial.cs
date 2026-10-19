
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("The PhysicsMaterial2D that is applied to this collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-sharedMaterial.html")]
	public sealed class Collider2DSetSharedMaterial : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Set Collider2D Shared Material")]
		[SerializeField, CanBeNullOrEmpty]
		private PhysicsMaterial2DVar _setSharedMaterial;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D);
		}
		
		public override void Execute()
		{
			_collider2D.Value.sharedMaterial = _setSharedMaterial.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider2D} shared material to {_setSharedMaterial}";
		}
	}
}
