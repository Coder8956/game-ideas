using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GameObjectActive")]
    [ActionDescription("Checks if a GameObject has a Component type.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html")]
    public class GameObjectCheckHasComponent : BaseTrueFalseAction
    {
        [Tooltip("The GameObject to check.")]
        public GameObjectVar GameObject;
        
        [Tooltip("The type of Component to check for.\nE.g., 'Rigidbody' or 'Renderer'")]
        [BaseType(typeof(Component))]
        public TypeVar ComponentType;
        
        protected override bool Test() => GameObject.Value != null ? GameObject.Value.GetComponent(ComponentType.Value.Type) : false;
        protected override string TrueSummary => "{GameObject} has {ComponentType} component";
        protected override string FalseSummary => "{GameObject} does not have {ComponentType} component";
    }
}