
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("Is this collider configured as a trigger?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-isTrigger.html")]
	public sealed class Collider2DSetIsTrigger : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Set Collider2D Is Trigger")]
		[SerializeField]
		private BoolVar _setIsTrigger;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _setIsTrigger);
		}
		
		public override void Execute()
		{
			_collider2D.Value.isTrigger = _setIsTrigger.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider2D} is trigger to {_setIsTrigger}";
		}
	}
}
