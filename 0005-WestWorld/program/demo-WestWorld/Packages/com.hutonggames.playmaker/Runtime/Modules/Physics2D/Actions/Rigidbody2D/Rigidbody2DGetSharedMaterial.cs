
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
	public sealed class Rigidbody2DGetSharedMaterial : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Shared Material")]
		[SerializeField]
		[WriteOnly]
		private PhysicsMaterial2DRef _getSharedMaterial;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getSharedMaterial);
		}
		
		public override void Execute()
		{
			_getSharedMaterial.Value = _rigidbody2D.Value.sharedMaterial;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} shared material -> {_getSharedMaterial}";
		}
	}
}
