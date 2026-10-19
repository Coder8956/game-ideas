
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("The local offset of the collider geometry.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-offset.html")]
	public sealed class Collider2DSetOffset : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Set Collider2D Offset")]
		[SerializeField]
		private Vector2Var _setOffset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _setOffset);
		}
		
		public override void Execute()
		{
			_collider2D.Value.offset = _setOffset.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider2D} offset to {_setOffset}";
		}
	}
}
