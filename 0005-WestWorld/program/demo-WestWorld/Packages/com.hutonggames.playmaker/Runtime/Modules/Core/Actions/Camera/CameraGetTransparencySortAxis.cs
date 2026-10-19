
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("An axis that describes the direction along which the distances of objects are mea" +
		"sured for the purpose of sorting.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-transparencySortAxis.html")]
	public sealed class CameraGetTransparencySortAxis : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Transparency Sort Axis")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getTransparencySortAxis;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getTransparencySortAxis);
		}
		
		public override void Execute()
		{
			_getTransparencySortAxis.Value = _camera.Value.transparencySortAxis;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} transparency sort axis -> {_getTransparencySortAxis}";
		}
	}
}
