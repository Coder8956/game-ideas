
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MeshCollider)]
	[ActionDescription("Options used to enable or disable certain features in mesh cooking.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/MeshCollider-cookingOptions.html")]
	public sealed class MeshColliderSetCookingOptions : BaseAction
	{
		
		[Tooltip("The MeshCollider")]
		[SerializeField]
		private MeshColliderVar _meshCollider;
		
		[Tooltip("Set MeshCollider Cooking Options")]
		[SerializeField]
		private MeshColliderCookingOptionsVar _setCookingOptions;
		
		public override bool CanExecute()
		{
			return CheckParameters(_meshCollider, _setCookingOptions);
		}
		
		public override void Execute()
		{
			_meshCollider.Value.cookingOptions = _setCookingOptions.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_meshCollider} Cooking Options to {_setCookingOptions}";
		}
	}
}
