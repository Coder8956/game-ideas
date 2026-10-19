using HutongGames.Reflection;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Object)]
    [ConvertibleGroup("FindObjects")]
    [ActionDescription("Finds the first active loaded object that matches the specified type. " +
                       "If no object matches the specified type, returns null.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Object.FindFirstObjectByType.html")]
    public class ObjectFindFirstObjectByType : BaseAction
    {
        [BaseType(typeof(Object))]
        [Tooltip("The Object type to search for.")] 
        public TypeReference ObjectType;
        
        [Tooltip("Include inactive objects in the search.")]
        public FindObjectsInactive IncludeInactive;
        
        [SerializeReference] 
        [WriteOnly, MatchType(nameof(ObjectType))]
        [Tooltip("Store the found Object in a variable.")]
        public IVariableRef StoreResult;
        
        public override void Execute()
        {
#if UNITY_6000_4_OR_NEWER
            StoreResult.SetValue(Object.FindAnyObjectByType(ObjectType.Type, IncludeInactive));
#else
            StoreResult.SetValue(Object.FindFirstObjectByType(ObjectType.Type, IncludeInactive));
#endif
        }
        
        public override string GetSummary() => "Find first object by type {ObjectType} -> {StoreResult}";
    }
}
