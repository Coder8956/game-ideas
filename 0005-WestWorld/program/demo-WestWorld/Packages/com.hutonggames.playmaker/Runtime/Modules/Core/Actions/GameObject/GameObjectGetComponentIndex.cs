using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Get the index of a Component on a GameObject.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.GetComponentIndex.html")]
    public class GameObjectGetComponentIndex : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;
        
        [Tooltip("The Component to search for.")]
        public ComponentVar Component;
        
        [WriteOnly, Tooltip("Store the result in an Integer variable")]
        public IntegerRef GetIndex;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject)) return;
            GetIndex.Value = GameObject.Value.GetComponentIndex(Component.Value);
        }
        
        public override string GetSummary() => "Get index of {Component} component in {GameObject} -> {GetIndex}";
    }
}
