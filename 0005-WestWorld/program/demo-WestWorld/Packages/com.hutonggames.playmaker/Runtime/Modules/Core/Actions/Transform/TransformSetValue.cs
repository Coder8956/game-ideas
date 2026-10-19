using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Set a Transform variable's value.")]
    [HelpURL("actions/transform-actions/transform-value-actions/")]
    public class TransformSetValue : BaseAction
    {
        [FormerlySerializedAs("Transform")]
        [DefaultName("Transform")]
        [WriteOnly]
        [Tooltip("The Transform variable.")]
        public TransformRef Variable;
        
        [Tooltip("Set the Transform variable's value.")]
        public TransformVar Value;

        public override bool CanExecute() => !Variable.IsNone;

        public override void Execute() => Variable.Value = Value.Value;

        public override string GetSummary() => "Set {Variable} to {Value}";
    }
}
