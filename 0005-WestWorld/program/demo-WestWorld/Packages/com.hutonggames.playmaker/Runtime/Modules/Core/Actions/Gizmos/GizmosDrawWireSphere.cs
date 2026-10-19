
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gizmos)]
	[ActionDescription("Draws a wireframe sphere with center and radius.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gizmos.DrawWireSphere.html")]
	public sealed class GizmosDrawWireSphere : BaseAction
	{
		
		[Tooltip("Center.")]
		[SerializeField]
		private Vector3Var _center;
		
		[Tooltip("Radius.")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _radius;
		
		public override bool CanExecute() => CheckParameters(_center, _radius);

#if UNITY_EDITOR	
		
		public override bool HasGizmos => true;
		
		public override void OnDrawGizmosSelected() => Gizmos.DrawWireSphere(_center.Value, _radius.Value);
#endif
		
		public override string GetSummary() => "Draw Wire Sphere At {_center} Radius {_radius} ";
	}
}
