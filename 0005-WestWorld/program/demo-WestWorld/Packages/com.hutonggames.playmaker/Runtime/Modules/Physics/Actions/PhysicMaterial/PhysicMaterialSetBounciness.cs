
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
	public sealed class PhysicMaterialSetBounciness : BaseAction
	{
		
		[Tooltip("The PhysicMaterial")]
		[SerializeField]
		private PhysicMaterialVar _physicMaterial;
		
		[Tooltip("Set PhysicMaterial Bounciness")]
		[SerializeField]
		private FloatVar _setBounciness;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicMaterial, _setBounciness);
		}
		
		public override void Execute()
		{
			_physicMaterial.Value.bounciness = _setBounciness.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_physicMaterial} Bounciness to {_setBounciness}";
		}
	}
}
