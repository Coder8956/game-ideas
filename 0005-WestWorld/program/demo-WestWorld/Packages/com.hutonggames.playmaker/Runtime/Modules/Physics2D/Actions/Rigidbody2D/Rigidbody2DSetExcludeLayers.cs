
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The additional Layers that all Collider2D attached to this Rigidbody2D should exc" +
		"lude when deciding if a contact with another Collider2D should happen or not.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-excludeLayers.html")]
	public sealed class Rigidbody2DSetExcludeLayers : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Exclude Layers")]
		[SerializeField]
		private LayerMaskVar _setExcludeLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setExcludeLayers);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.excludeLayers = _setExcludeLayers.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} exclude layers to {_setExcludeLayers}";
		}
	}
}
