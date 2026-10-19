
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("Is this collider configured as a trigger?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-isTrigger.html")]
	public sealed class Collider2DGetIsTrigger : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Get Collider2D Is Trigger")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsTrigger;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _getIsTrigger);
		}
		
		public override void Execute()
		{
			_getIsTrigger.Value = _collider2D.Value.isTrigger;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} is trigger -> {_getIsTrigger}";
		}
	}
}
