
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicMaterial)]
	[ActionDescription("Determines how the bounciness is combined.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PhysicsMaterial-bounceCombine.html")]
	public sealed class PhysicMaterialGetBounceCombine : BaseAction
	{
		
		[Tooltip("The PhysicMaterial")]
		[SerializeField]
		private PhysicMaterialVar _physicMaterial;
		
		[Tooltip("Get PhysicMaterial Bounce Combine")]
		[SerializeField]
		[WriteOnly]
		private PhysicMaterialCombineRef _getBounceCombine;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicMaterial, _getBounceCombine);
		}
		
		public override void Execute()
		{
			_getBounceCombine.Value = _physicMaterial.Value.bounceCombine;
		}
		
		public override string GetSummary()
		{
			return "Get {_physicMaterial} bounceCombine -> {_getBounceCombine}";
		}
	}
}
