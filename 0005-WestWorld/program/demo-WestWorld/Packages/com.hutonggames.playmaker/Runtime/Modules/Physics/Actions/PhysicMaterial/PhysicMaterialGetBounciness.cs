
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicMaterial)]
	[ActionDescription("How bouncy is the surface? A value of 0 will not bounce. A value of 1 will bounce" +
		" without any loss of energy.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PhysicsMaterial-bounciness.html")]
	public sealed class PhysicMaterialGetBounciness : BaseAction
	{
		
		[Tooltip("The PhysicMaterial")]
		[SerializeField]
		private PhysicMaterialVar _physicMaterial;
		
		[Tooltip("Get PhysicMaterial Bounciness")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getBounciness;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicMaterial, _getBounciness);
		}
		
		public override void Execute()
		{
			_getBounciness.Value = _physicMaterial.Value.bounciness;
		}
		
		public override string GetSummary()
		{
			return "Get {_physicMaterial} bounciness -> {_getBounciness}";
		}
	}
}
