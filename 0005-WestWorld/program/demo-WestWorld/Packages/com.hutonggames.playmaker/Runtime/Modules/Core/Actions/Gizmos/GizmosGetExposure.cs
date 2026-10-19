
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gizmos)]
	[ActionDescription("A texture that contains the exposure correction for LightProbe gizmos. The va" +
		"lue is sampled from the red channel in the middle of the texture.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gizmos-exposure.html")]
	public sealed class GizmosGetExposure : BaseAction
	{
		
		[Tooltip("Get Gizmos Exposure")]
		[SerializeField]
		[WriteOnly]
		private TextureRef _getExposure;
		
		public override bool CanExecute() => CheckParameters(_getExposure);

#if UNITY_EDITOR
		
		public override bool HasGizmos => true;
		
		public override void OnDrawGizmosSelected() => _getExposure.Value = Gizmos.exposure;
#endif
		
		public override string GetSummary() => "Get Gizmos Exposure -> {_getExposure} ";
	}
}
