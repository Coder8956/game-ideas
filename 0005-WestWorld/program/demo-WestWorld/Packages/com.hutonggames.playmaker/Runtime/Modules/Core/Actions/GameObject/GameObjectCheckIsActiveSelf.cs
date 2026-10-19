using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GameObjectActive")]
    [ActionDescription("Checks the local active state of the GameObject.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-activeSelf.html")]
    public class GameObjectCheckIsActiveSelf : BaseTrueFalseAction
    {
        [Tooltip("The GameObject to check.")]
        public GameObjectVar GameObject;
        
        protected override bool Test() => GameObject.Value != null && GameObject.Value.activeSelf;
        protected override string TrueSummary => "{GameObject} is active";
        protected override string FalseSummary => "{GameObject} is not active";
    }
}