
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("The PhysicsMaterial2D that is applied to this collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-sharedMaterial.html")]
	public sealed class Collider2DGetSharedMaterial : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Get Collider2D Shared Material")]
		[SerializeField]
		[WriteOnly]
		private PhysicsMaterial2DRef _getSharedMaterial;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _getSharedMaterial);
		}
		
		public override void Execute()
		{
			_getSharedMaterial.Value = _collider2D.Value.sharedMaterial;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} shared material -> {_getSharedMaterial}";
		}
	}
}
