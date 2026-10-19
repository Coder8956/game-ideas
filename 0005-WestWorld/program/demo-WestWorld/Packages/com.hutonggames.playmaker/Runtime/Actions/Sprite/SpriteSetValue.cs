using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Sprite)]
    [ActionDescription("Set the value of a Sprite variable.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Sprite.html")]
    public sealed class SpriteSetValue : BaseAction
    {
        [DefaultName("Sprite")]
        [Tooltip("The Sprite variable to set.")]
        [SerializeField]
        [WriteOnly]
        private SpriteRef _variable;

        [Tooltip("Set Sprite value.")]
        [SerializeField, CanBeNullOrEmpty]
        private SpriteVar _setValue;

        public override bool CanExecute() => !_variable.IsNone;

        public override void Execute() => _variable.Value = _setValue.Value;

        public override string GetSummary() => "Set {_variable} to {_setValue}";
    }
}
