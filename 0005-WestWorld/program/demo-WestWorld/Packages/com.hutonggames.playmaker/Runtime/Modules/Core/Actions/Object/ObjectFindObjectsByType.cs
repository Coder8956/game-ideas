using HutongGames.Reflection;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Object)]
    [ConvertibleGroup("FindObjects")]
    [ActionDescription("Retrieves a list of all loaded objects of a given Type.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Object.FindObjectsByType.html")]
    public class ObjectFindObjectsByType : BaseAction
    {
        [BaseType(typeof(Object))]
        [Tooltip("The Object type to search for.")] 
        public TypeReference ObjectType;
        
        [Tooltip("Whether to include components attached to inactive GameObjects.")]
        public FindObjectsInactive IncludeInactive;
        
#if !UNITY_6000_4_OR_NEWER
        [Tooltip("Whether and how to sort the returned array. Not sorting the array makes this function run significantly faster.")]
        public FindObjectsSortMode SortMode;
#endif
        
        [SerializeReference]
        [WriteOnly, MatchType(nameof(ObjectType))]
        [Tooltip("Store the found Objects in a list variable.")]
        public IListVariableRef StoreResult;
        
        public override void Execute()
        {
#if UNITY_6000_4_OR_NEWER
            StoreResult.SetValue(Object.FindObjectsByType(ObjectType.Type, IncludeInactive));
#else
            StoreResult.SetValue(Object.FindObjectsByType(ObjectType.Type, IncludeInactive, SortMode));
#endif
        }
        
        public override string GetSummary() => "Find Objects by type {ObjectType} -> {StoreResult}";
    }
}
