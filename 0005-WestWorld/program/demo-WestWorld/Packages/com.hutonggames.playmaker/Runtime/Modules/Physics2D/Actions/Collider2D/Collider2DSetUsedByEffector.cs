
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("Whether the collider is used by an attached effector or not.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-usedByEffector.html")]
	public sealed class Collider2DSetUsedByEffector : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Set Collider2D Used By Effector")]
		[SerializeField]
		private BoolVar _setUsedByEffector;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _setUsedByEffector);
		}
		
		public override void Execute()
		{
			_collider2D.Value.usedByEffector = _setUsedByEffector.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider2D} used by effector to {_setUsedByEffector}";
		}
	}
}
