
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The PhysicsMaterial2D that is applied to all Collider2D attached to this Rigidbod" +
		"y2D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-sharedMaterial.html")]
	public sealed class Rigidbody2DSetSharedMaterial : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Shared Material")]
		[SerializeField, CanBeNullOrEmpty]
		private PhysicsMaterial2DVar _setSharedMaterial;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.sharedMaterial = _setSharedMaterial.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} shared material to {_setSharedMaterial}";
		}
	}
}
