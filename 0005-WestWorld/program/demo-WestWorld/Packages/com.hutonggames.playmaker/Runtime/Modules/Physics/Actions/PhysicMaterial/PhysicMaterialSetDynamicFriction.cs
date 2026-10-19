
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicMaterial)]
	[ActionDescription("The friction used when already moving. This value is usually between 0 and 1.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PhysicsMaterial-dynamicFriction.html")]
	public sealed class PhysicMaterialSetDynamicFriction : BaseAction
	{
		
		[Tooltip("The PhysicMaterial")]
		[SerializeField]
		private PhysicMaterialVar _physicMaterial;
		
		[Tooltip("Set PhysicMaterial Dynamic Friction")]
		[SerializeField]
		private FloatVar _setDynamicFriction;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicMaterial, _setDynamicFriction);
		}
		
		public override void Execute()
		{
			_physicMaterial.Value.dynamicFriction = _setDynamicFriction.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_physicMaterial} Dynamic Friction to {_setDynamicFriction}";
		}
	}
}
