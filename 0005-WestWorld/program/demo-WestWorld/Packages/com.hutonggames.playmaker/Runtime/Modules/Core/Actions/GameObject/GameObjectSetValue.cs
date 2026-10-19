using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Set a GameObject variable's value.")]
    [HelpURL("actions/gameobject-actions/lifecycle/game-object-set-value/")]
    public class GameObjectSetValue : BaseAction
    {
        [DefaultName("GameObject")]
        [FormerlySerializedAs("GameObject")]
        [WriteOnly]
        [Tooltip("The GameObject.")]
        public GameObjectRef Variable;
        
        [Tooltip("Set the GameObject variable's value.")]
        [CanBeNullOrEmpty]
        public GameObjectVar Value;

        public override bool CanExecute() => !Variable.IsNone;

        public override void Execute() => Variable.Value = Value.Value;

        public override string GetSummary() => "Set {Variable} to {Value}";
    }
}