
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
	public sealed class CameraSetOpaqueSortMode : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Opaque Sort Mode")]
		[SerializeField]
		private Rendering.OpaqueSortModeVar _setOpaqueSortMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setOpaqueSortMode);
		}
		
		public override void Execute()
		{
			_camera.Value.opaqueSortMode = _setOpaqueSortMode.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} opaque sort mode to {_setOpaqueSortMode}";
		}
	}
}
