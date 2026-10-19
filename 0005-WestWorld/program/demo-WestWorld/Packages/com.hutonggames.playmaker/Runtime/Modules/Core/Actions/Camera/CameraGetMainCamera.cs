using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Camera)]
    [ActionDescription("Get the Camera tagged as the MainCamera." +
                       "<br/>NOTE: You can also use the <b>System > MainCamera</b> variable.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Camera-main.html")]
    public class CameraGetMainCamera : BaseAction
    {
        [WriteOnly]
        [Tooltip("Store the Main Camera in a Camera variable.")]
        public CameraRef MainCamera;

        public override bool CanExecute() => CheckParameters(MainCamera);

        public override void Execute() => MainCamera.Value = Camera.main;

        public override string GetSummary() => "Get MainCamera -> {MainCamera}";
    }
}