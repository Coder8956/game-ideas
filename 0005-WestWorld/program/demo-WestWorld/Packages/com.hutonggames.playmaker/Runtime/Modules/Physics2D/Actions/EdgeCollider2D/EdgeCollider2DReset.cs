
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EdgeCollider2D)]
	[ActionDescription("Reset to a single edge consisting of two points.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EdgeCollider2D.Reset.html")]
	public sealed class EdgeCollider2DReset : BaseAction
	{
		
		[Tooltip("The EdgeCollider2D.")]
		[SerializeField]
		private EdgeCollider2DVar _edgeCollider2D;
		
		public override bool CanExecute()
		{
			return CheckParameters(_edgeCollider2D);
		}
		
		public override void Execute()
		{
			//UnityEngine.EdgeCollider2D.Reset();
			_edgeCollider2D.Value.Reset();
		}
		
		public override string GetSummary()
		{
			return "Reset {_edgeCollider2D} ";
		}
	}
}
