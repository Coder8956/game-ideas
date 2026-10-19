
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider)]
	[ActionDescription("The material used by the collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider-material.html")]
	public sealed class ColliderSetMaterial : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Set Collider Material")]
		[SerializeField, CanBeNullOrEmpty]
		private PhysicMaterialVar _setMaterial;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider);
		}
		
		public override void Execute()
		{
			_collider.Value.material = _setMaterial.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider} material to {_setMaterial}";
		}
	}
}
