using UnityEngine;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Keyboard)]
    [DisplayName("Input Get Key (Hold)")]
    [ConvertibleGroup(ConvertibleGroup.InputButton)]
    [ActionDescription("Returns true while the user holds down the specified KeyCode." 
                       + Strings.SupportsBothInputSystems)]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Input.GetKey.html")]
    public sealed class InputGetKey : BaseTrueFalseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        
        [Tooltip("The key to detect.")]
        [SerializeField]
        private KeyCodeVar _key;

        public override bool CanExecute() => CheckParameters(_key);

        protected override bool Test() => InputShim.GetKey(_key.Value);

        protected override string TrueSummary => "{_key} pressed";

        protected override string FalseSummary => "{_key} not pressed";
    }
}
