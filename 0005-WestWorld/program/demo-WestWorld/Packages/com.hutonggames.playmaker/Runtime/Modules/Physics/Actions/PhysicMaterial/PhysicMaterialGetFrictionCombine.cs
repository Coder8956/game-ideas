
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicMaterial)]
	[ActionDescription("Determines how the friction is combined.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PhysicsMaterial-frictionCombine.html")]
	public sealed class PhysicMaterialGetFrictionCombine : BaseAction
	{
		
		[Tooltip("The PhysicMaterial")]
		[SerializeField]
		private PhysicMaterialVar _physicMaterial;
		
		[Tooltip("Get PhysicMaterial Friction Combine")]
		[SerializeField]
		[WriteOnly]
		private PhysicMaterialCombineRef _getFrictionCombine;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicMaterial, _getFrictionCombine);
		}
		
		public override void Execute()
		{
			_getFrictionCombine.Value = _physicMaterial.Value.frictionCombine;
		}
		
		public override string GetSummary()
		{
			return "Get {_physicMaterial} frictionCombine -> {_getFrictionCombine}";
		}
	}
}
