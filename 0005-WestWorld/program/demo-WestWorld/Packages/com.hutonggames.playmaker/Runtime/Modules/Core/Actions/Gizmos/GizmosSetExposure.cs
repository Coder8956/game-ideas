
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gizmos)]
	[ActionDescription("Set a texture that contains the exposure correction for LightProbe gizmos. The va" +
		"lue is sampled from the red channel in the middle of the texture.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gizmos-exposure.html")]
	public sealed class GizmosSetExposure : BaseAction
	{
		
		[Tooltip("Set Gizmos Exposure")]
		[SerializeField, CanBeNullOrEmpty]
		private TextureVar _setExposure;
		
		public override bool CanExecute() => CheckParameters();

#if UNITY_EDITOR
		
		public override bool HasGizmos => true;
		
		public override void OnDrawGizmosSelected() => Gizmos.exposure = _setExposure.Value;
#endif
		
		public override string GetSummary() => "Set Gizmos Exposure to {_setExposure}";
	}
}
