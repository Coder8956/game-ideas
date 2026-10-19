
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
	public sealed class CameraSetTransparencySortAxis : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Transparency Sort Axis")]
		[SerializeField]
		private Vector3Var _setTransparencySortAxis;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setTransparencySortAxis);
		}
		
		public override void Execute()
		{
			_camera.Value.transparencySortAxis = _setTransparencySortAxis.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} transparency sort axis to {_setTransparencySortAxis}";
		}
	}
}
