
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
	public sealed class PhysicMaterialGetDynamicFriction : BaseAction
	{
		
		[Tooltip("The PhysicMaterial")]
		[SerializeField]
		private PhysicMaterialVar _physicMaterial;
		
		[Tooltip("Get PhysicMaterial Dynamic Friction")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getDynamicFriction;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicMaterial, _getDynamicFriction);
		}
		
		public override void Execute()
		{
			_getDynamicFriction.Value = _physicMaterial.Value.dynamicFriction;
		}
		
		public override string GetSummary()
		{
			return "Get {_physicMaterial} dynamicFriction -> {_getDynamicFriction}";
		}
	}
}
