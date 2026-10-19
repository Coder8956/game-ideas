
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gizmos)]
	[ActionDescription("Draws a line.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gizmos.DrawLine.html")]
	public sealed class GizmosDrawLine : BaseAction
	{
		
		[Tooltip("From.")]
		[SerializeField]
		private Vector3Var _from;
		
		[Tooltip("To.")]
		[SerializeField]
		private Vector3Var _to;
		
		public override bool CanExecute() => CheckParameters(_from, _to);

#if UNITY_EDITOR	
		
		public override bool HasGizmos => true;
		
		public override void OnDrawGizmosSelected() => Gizmos.DrawLine(_from.Value, _to.Value);
#endif
		
		public override string GetSummary() => "Draw Line From: {_from} To: {_to} ";
	}
}
