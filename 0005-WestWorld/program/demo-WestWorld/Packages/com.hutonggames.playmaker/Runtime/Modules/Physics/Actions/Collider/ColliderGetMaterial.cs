
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider)]
	[ActionDescription("The material used by the collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider-material.html")]
	public sealed class ColliderGetMaterial : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Get Collider Material")]
		[SerializeField]
		[WriteOnly]
		private PhysicMaterialRef _getMaterial;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _getMaterial);
		}
		
		public override void Execute()
		{
			_getMaterial.Value = _collider.Value.material;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider} material -> {_getMaterial}";
		}
	}
}
