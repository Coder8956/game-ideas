using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GetComponent")]
    [ActionDescription("Get a Component on a GameObject at an index. NOTE: If you don't know the type of the component store the result in a base Component variable.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.GetComponentAtIndex.html")]
    public class GameObjectGetComponentAtIndex : BaseAction
    {
        [Tooltip("The GameObject to check.")]
        public GameObjectVar GameObject;

        [Tooltip("The index of the Component to get.")]
        public IntegerVar AtIndex;
        
        [WriteOnly, BaseType(typeof(Component))]
        [Tooltip("Store the result in a Component variable")]
        public ComponentRef StoreResult;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject)) return;
            StoreResult.Value = GameObject.Value.GetComponentAtIndex(AtIndex.Value);
        }
        
        public override string GetSummary() => "Get {GameObject} component at index {AtIndex} -> {StoreResult}";
    }
}
