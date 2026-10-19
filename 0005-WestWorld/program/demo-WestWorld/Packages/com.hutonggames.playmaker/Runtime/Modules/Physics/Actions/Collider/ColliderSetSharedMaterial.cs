
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider)]
	[ActionDescription("The shared physic material of this collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider-sharedMaterial.html")]
	public sealed class ColliderSetSharedMaterial : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Set Collider Shared Material")]
		[SerializeField, CanBeNullOrEmpty]
		private PhysicMaterialVar _setSharedMaterial;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider);
		}
		
		public override void Execute()
		{
			_collider.Value.sharedMaterial = _setSharedMaterial.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider} shared material to {_setSharedMaterial}";
		}
	}
}
