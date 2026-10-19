
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider)]
	[ActionDescription("The shared physic material of this collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider-sharedMaterial.html")]
	public sealed class ColliderGetSharedMaterial : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Get Collider Shared Material")]
		[SerializeField]
		[WriteOnly]
		private PhysicMaterialRef _getSharedMaterial;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _getSharedMaterial);
		}
		
		public override void Execute()
		{
			_getSharedMaterial.Value = _collider.Value.sharedMaterial;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider} shared material -> {_getSharedMaterial}";
		}
	}
}
