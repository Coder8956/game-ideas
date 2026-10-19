
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gizmos)]
	[ActionDescription("Draws a ray starting at from to from + direction.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gizmos.DrawRay.html")]
	public sealed class GizmosDrawRay__From : BaseAction
	{
		
		[Tooltip("From.")]
		[SerializeField]
		private Vector3Var _from;
		
		[Tooltip("Direction.")]
		[SerializeField]
		private Vector3Var _direction;
		
		public override bool CanExecute() => CheckParameters(_from, _direction);

#if UNITY_EDITOR
		
		public override bool HasGizmos => true;
		
		public override void OnDrawGizmosSelected() => Gizmos.DrawRay(_from.Value, _direction.Value);
#endif
		
		public override string GetSummary() => "Draw Ray From: {_from} Dir: {_direction} ";
	}
}
