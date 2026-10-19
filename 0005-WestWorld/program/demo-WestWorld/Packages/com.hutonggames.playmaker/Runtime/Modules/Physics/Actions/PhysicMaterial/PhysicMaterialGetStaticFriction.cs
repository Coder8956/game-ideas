
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicMaterial)]
	[ActionDescription("The friction coefficient used when an object is lying on a surface.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PhysicsMaterial-staticFriction.html")]
	public sealed class PhysicMaterialGetStaticFriction : BaseAction
	{
		
		[Tooltip("The PhysicMaterial")]
		[SerializeField]
		private PhysicMaterialVar _physicMaterial;
		
		[Tooltip("Get PhysicMaterial Static Friction")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getStaticFriction;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicMaterial, _getStaticFriction);
		}
		
		public override void Execute()
		{
			_getStaticFriction.Value = _physicMaterial.Value.staticFriction;
		}
		
		public override string GetSummary()
		{
			return "Get {_physicMaterial} staticFriction -> {_getStaticFriction}";
		}
	}
}
