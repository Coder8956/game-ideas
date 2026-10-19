using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GameObjectActive")]
    [ActionDescription("Checks if a GameObject is set as Static.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-isStatic.html")]
    public class GameObjectCheckIsStatic : BaseTrueFalseAction
    {
        [Tooltip("The GameObject to check.")]
        public GameObjectVar GameObject;
        
        protected override bool Test() => GameObject.Value != null && GameObject.Value.isStatic;
        protected override string TrueSummary => "{GameObject} is static";
        protected override string FalseSummary => "{GameObject} is not static";
    }
}