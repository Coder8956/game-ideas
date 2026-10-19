
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gizmos)]
	[ActionDescription("Draws a ray.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gizmos.DrawRay.html")]
	public sealed class GizmosDrawRay : BaseAction
	{
		
		[Tooltip("Ray.")]
		[SerializeField]
		private RayVar _ray;
		
		public override bool CanExecute() => CheckParameters(_ray);

#if UNITY_EDITOR
		
		public override bool HasGizmos => true;
		
		public override void OnDrawGizmosSelected() => Gizmos.DrawRay(_ray.Value);
#endif
		
		public override string GetSummary() => "Draw Ray: {_ray} ";
	}
}
