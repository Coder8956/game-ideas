
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Mouse)]
	[ActionDescription("The current mouse position projected into world space." +
	                   "\n\nThis is equivalent to using Get Mouse Position and Camera Screen To World Point."
	                   + Strings.SupportsBothInputSystems)]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-mousePosition.html")]
	public sealed class InputGetMousePositionInWorld : BaseAction
	{
        [Tooltip("The Camera used to project mouse position into world space.")]
        [DefaultValue("~MainCamera")]
        [SerializeField]
        private CameraVar _camera;

        [DefaultValue(1f)]
        [Tooltip("Z depth or distance from camera. " +
                 "The resulting world position will be on a plane at this distance from the camera.")]
        [SerializeField]
        private FloatVar _zDepth;
		
		[Tooltip("Get Input Mouse Position")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getMousePosition;
		
		public override bool CanExecute() => CheckParameters(_camera, _zDepth, _getMousePosition);

		public override void Execute()
		{
			var mousePos = (Vector3) InputShim.GetMousePosition();
			mousePos.z = _zDepth.Value;
			_getMousePosition.Value = _camera.Value.ScreenToWorldPoint(mousePos);
		}

		public override string GetSummary() => "Get Mouse World Position at Z: {_zDepth} -> {_getMousePosition} ";
	}
}
