using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GameObjectActive")]
    [ActionDescription("Checks if a GameObject is active in the hierarchy.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-activeInHierarchy.html")]
    public class GameObjectCheckIsActiveInHierarchy : BaseTrueFalseAction
    {
        [Tooltip("The GameObject to check.")]
        public GameObjectVar GameObject;
        
        protected override bool Test() => GameObject.Value != null && GameObject.Value.activeInHierarchy;
        protected override string TrueSummary => "{GameObject} is active in hierarchy";
        protected override string FalseSummary => "{GameObject} is not active in hierarchy";
    }
}