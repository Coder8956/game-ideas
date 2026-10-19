using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Set the name of a GameObject.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Object-name.html")]
    public class GameObjectSetName : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;
        
        [Tooltip("Set the name." +
                 "\n<b>Tip</b>: Enable Use Variable Tokens to insert values with {VariableName}.")]
        public StringVar Name;

        [Tooltip("Resolve {VariableName} and {VariableName.Property} tokens in the name.")]
        [DefaultValue(false)]
        public BoolVar UseVariableTokens;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject)) return;
            GameObject.Value.name = UseVariableTokens.Value
                ? DebugLogTextFormatter.Format(Name.Value, Fsm?.Variables)
                : Name.Value;
        }
        
        public override string GetSummary() => "Set {GameObject} name to {Name}";
    }
}
