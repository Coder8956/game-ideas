
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicMaterial)]
	[ActionDescription("Determines how the friction is combined.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PhysicsMaterial-frictionCombine.html")]
	public sealed class PhysicMaterialSetFrictionCombine : BaseAction
	{
		
		[Tooltip("The PhysicMaterial")]
		[SerializeField]
		private PhysicMaterialVar _physicMaterial;
		
		[Tooltip("Set PhysicMaterial Friction Combine")]
		[SerializeField]
		private PhysicMaterialCombineVar _setFrictionCombine;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicMaterial, _setFrictionCombine);
		}
		
		public override void Execute()
		{
			_physicMaterial.Value.frictionCombine = _setFrictionCombine.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_physicMaterial} Friction Combine to {_setFrictionCombine}";
		}
	}
}
