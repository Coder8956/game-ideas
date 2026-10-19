using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Get the number of Components on a GameObject.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.GetComponentCount.html")]
    public class GameObjectGetComponentCount : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;
        
        [Tooltip("Store the result in an Integer variable")]
        public IntegerRef StoreResult;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject)) return;
            
#if UNITY_2022_3_20_OR_NEWER
            StoreResult.Value = GameObject.Value.GetComponentCount();
#else
            StoreResult.Value = GameObject.Value.GetComponents<Component>().Length;
#endif
        }
        
        public override string GetSummary() => "Get {GameObject} component count -> {StoreResult}";
    }
}
