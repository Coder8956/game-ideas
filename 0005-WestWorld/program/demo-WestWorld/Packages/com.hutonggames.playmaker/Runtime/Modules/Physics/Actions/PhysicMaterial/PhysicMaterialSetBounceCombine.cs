
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicMaterial)]
	[ActionDescription("Determines how the bounciness is combined.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PhysicsMaterial-bounceCombine.html")]
	public sealed class PhysicMaterialSetBounceCombine : BaseAction
	{
		
		[Tooltip("The PhysicMaterial")]
		[SerializeField]
		private PhysicMaterialVar _physicMaterial;
		
		[Tooltip("Set PhysicMaterial Bounce Combine")]
		[SerializeField]
		private PhysicMaterialCombineVar _setBounceCombine;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicMaterial, _setBounceCombine);
		}
		
		public override void Execute()
		{
			_physicMaterial.Value.bounceCombine = _setBounceCombine.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_physicMaterial} Bounce Combine to {_setBounceCombine}";
		}
	}
}
