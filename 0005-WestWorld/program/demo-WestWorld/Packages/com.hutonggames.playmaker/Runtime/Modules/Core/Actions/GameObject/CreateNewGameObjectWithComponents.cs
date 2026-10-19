using System.Linq;
using HutongGames.Extensions;
using HutongGames.Reflection;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Instantiate)]
    [ConvertibleGroup("CreateGameObject")]
    [ActionDescription("Create a new GameObject and add Components.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-ctor.html")]
    public class CreateNewGameObjectWithComponents : BaseAction
    {
        [Tooltip("The name of the new GameObject.")]
        public StringVar Name;
        
        [OptionalField, BaseType(typeof(Component))]
        [ArrayElementLabel("Component Type")]
        public TypeReference[] Components;
        
        [WriteOnly, Tooltip("Store the new GameObject in a variable")]
        public GameObjectRef StoreGameObject;
        
        public override void Execute()
        {
            var go = Components.Length == 0 
                ? new GameObject(Name.Value) 
                : new GameObject(Name.Value, Components.Select(typeReference => typeReference.Type).ToArray());
            
            StoreGameObject.Value = go;
        }
        
        public override string GetSummary()
        {
            var builder = StringBuilderPool.Get();
            builder.Append("Create new GameObject ");
            
            if (!string.IsNullOrEmpty(Name.Value))
            {
                builder.Append("named {Name} ");
            }

            if (Components?.Length > 0)
            {
                builder.Append("with ")
                    .AppendJoin(", ", Components.Select(x => $"<b>{x}</b>"))
                    .AppendPluralize(" Component", Components.Length);
            }
            
            if (StoreGameObject.IsAssigned)
            {
                builder.Append(" -> {StoreGameObject}");
            }

            return StringBuilderPool.ToStringAndRelease(builder);
        }
    }
}