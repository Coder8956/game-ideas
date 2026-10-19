using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Instantiate)]
    [ConvertibleGroup("CreateGameObject")]
    [ActionDescription("Create a new GameObject.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-ctor.html")]
    public class CreateNewGameObject : BaseAction
    {
        [Tooltip("The name of the new GameObject.")]
        public StringVar Name;
        
        [WriteOnly, Tooltip("Store the new GameObject in a variable")]
        public GameObjectRef StoreGameObject;
        
        public override void Execute()
        {
            var go = new GameObject(Name.Value);
            StoreGameObject.Value = go;
        }
        
        public override string GetSummary()
        {
            var text = "Create new GameObject";
            
            if (!string.IsNullOrEmpty(Name.Value))
            {
                text += " \"{Name}\"";
            }
            
            if (StoreGameObject.IsAssigned)
            {
                text += $" -> {StoreGameObject}";
            }

            return text;
        }
    }
}