using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Creates a primitive GameObject.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.CreatePrimitive.html")]
    public class GameObjectCreatePrimitive : BaseAction
    {
        [Tooltip("The type of primitive to create.")]
        public PrimitiveTypeVar PrimitiveType;
        
        [OptionalField, WriteOnly, Tooltip("Store the result in a GameObject variable")]
        public GameObjectRef StoreCreatedPrimitive;
        
        public override void Execute()
        {
            if (!RuntimeCheck(PrimitiveType, StoreCreatedPrimitive)) return;
            StoreCreatedPrimitive.Value = GameObject.CreatePrimitive(PrimitiveType.Value);
        }
        
        public override string GetSummary() => 
            "Create {PrimitiveType}" + (StoreCreatedPrimitive.HasValue() ? " -> {StoreCreatedPrimitive}" : "");
    }
}