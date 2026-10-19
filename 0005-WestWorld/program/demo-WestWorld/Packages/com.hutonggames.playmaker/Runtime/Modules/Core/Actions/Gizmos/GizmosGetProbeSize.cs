
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gizmos)]
	[ActionDescription("A scale for Light Probe gizmos. This scale will be used to render the spheric" +
		"al harmonic preview spheres.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gizmos-probeSize.html")]
	public sealed class GizmosGetProbeSize : BaseAction
	{
		
		[Tooltip("Get Gizmos Probe Size")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getProbeSize;
		
		public override bool CanExecute() => CheckParameters(_getProbeSize);

#if UNITY_EDITOR
		
		public override bool HasGizmos => true;
		
		public override void OnDrawGizmosSelected() => _getProbeSize.Value = Gizmos.probeSize;
#endif
		
		public override string GetSummary() => "Get Gizmos Probe Size -> {_getProbeSize} ";
	}
}
