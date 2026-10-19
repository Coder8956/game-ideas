
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MeshCollider)]
	[ActionDescription("Options used to enable or disable certain features in mesh cooking.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/MeshCollider-cookingOptions.html")]
	public sealed class MeshColliderGetCookingOptions : BaseAction
	{
		
		[Tooltip("The MeshCollider")]
		[SerializeField]
		private MeshColliderVar _meshCollider;
		
		[Tooltip("Get MeshCollider Cooking Options")]
		[SerializeField]
		[WriteOnly]
		private MeshColliderCookingOptionsRef _getCookingOptions;
		
		public override bool CanExecute()
		{
			return CheckParameters(_meshCollider, _getCookingOptions);
		}
		
		public override void Execute()
		{
			_getCookingOptions.Value = _meshCollider.Value.cookingOptions;
		}
		
		public override string GetSummary()
		{
			return "Get {_meshCollider} cookingOptions -> {_getCookingOptions}";
		}
	}
}
