
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("Whether the collider is used by an attached effector or not.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-usedByEffector.html")]
	public sealed class Collider2DGetUsedByEffector : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Get Collider2D Used By Effector")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUsedByEffector;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _getUsedByEffector);
		}
		
		public override void Execute()
		{
			_getUsedByEffector.Value = _collider2D.Value.usedByEffector;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} used by effector -> {_getUsedByEffector}";
		}
	}
}
