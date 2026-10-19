
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
	public sealed class PhysicMaterialSetStaticFriction : BaseAction
	{
		
		[Tooltip("The PhysicMaterial")]
		[SerializeField]
		private PhysicMaterialVar _physicMaterial;
		
		[Tooltip("Set PhysicMaterial Static Friction")]
		[SerializeField]
		private FloatVar _setStaticFriction;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicMaterial, _setStaticFriction);
		}
		
		public override void Execute()
		{
			_physicMaterial.Value.staticFriction = _setStaticFriction.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_physicMaterial} Static Friction to {_setStaticFriction}";
		}
	}
}
