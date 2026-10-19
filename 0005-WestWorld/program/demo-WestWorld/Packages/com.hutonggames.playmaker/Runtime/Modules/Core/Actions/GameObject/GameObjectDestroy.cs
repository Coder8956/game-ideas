using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Destroy a GameObject.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Object.Destroy.html")]
    [MovedFrom( true,null,null,"GameObject_Destroy")]   
    public class GameObjectDestroy : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The GameObject to destroy.")]
        public GameObjectVar GameObject;
        
        [Tooltip("An optional number of seconds to delay before destroying the object.")]
        public FloatVar Delay;

        public override bool CanExecute() => GameObject.HasValue();

        public override void Execute()
        {
            if (GameObject.Value == null) return;
            Object.Destroy(GameObject.Value, Delay.Value);
        }

        public override string GetSummary() => 
            "Destroy {GameObject} " + (Delay.IsNotDefault() ? "after {Delay:seconds}" : "");
    }
}