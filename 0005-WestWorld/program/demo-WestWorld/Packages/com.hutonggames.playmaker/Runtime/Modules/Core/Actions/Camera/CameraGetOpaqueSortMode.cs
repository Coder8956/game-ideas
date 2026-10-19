
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Opaque object sorting mode.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-opaqueSortMode.html")]
	public sealed class CameraGetOpaqueSortMode : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Opaque Sort Mode")]
		[SerializeField]
		[WriteOnly]
		private Rendering.OpaqueSortModeRef _getOpaqueSortMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getOpaqueSortMode);
		}
		
		public override void Execute()
		{
			_getOpaqueSortMode.Value = _camera.Value.opaqueSortMode;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} opaque sort mode -> {_getOpaqueSortMode}";
		}
	}
}
