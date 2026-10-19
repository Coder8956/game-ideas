using HutongGames.Reflection;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Object)]
    [ConvertibleGroup("FindObjects")]
    [ActionDescription("Finds an arbitrary active loaded object that matches the specified type. " +
                       "If no object matches the specified type, returns null.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Object.FindAnyObjectByType.html")]
    public class ObjectFindAnyObjectByType : BaseAction
    {
        [BaseType(typeof(Object))]
        [Tooltip("The Object type to search for.")] 
        public TypeReference ObjectType;
        
        [Tooltip("Include inactive objects in the search.")]
        public FindObjectsInactive IncludeInactive;
        
        [SerializeReference]
        [WriteOnly, MatchType(nameof(ObjectType))]
        [Tooltip("Store the found Object in a variable. " +
                 "If there is no specific variable type for the Object, " +
                 "it is stores in a base Object variable.")]
        public IVariableRef StoreResult;
        
        public override void Execute()
        {
            StoreResult?.SetValue(Object.FindAnyObjectByType(ObjectType.Type, IncludeInactive));
        }
        
        public override string GetSummary() => "Find any object by type {ObjectType} -> {StoreResult}";
    }
}