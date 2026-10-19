// (c) Copyright HutongGames, LLC 2022. All rights reserved.

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    
    [System.Serializable]
    [PublicAPI]
    [DisplayName("Input Get Button (Hold)")]
    [ActionCategory(Category.InputButton)]
    [ConvertibleGroup(ConvertibleGroup.InputButton)]
    [ActionDescription("Returns true while the virtual button identified by buttonName is held down."
                       + Strings.LimitedButtonSupport)]
    public class InputGetButton : BaseTrueFalseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        
        [Tooltip("The name of the button such as Jump.")]
        [SerializeField, DefaultValue("Fire1")]
        private StringVar _buttonName;

        protected override bool Test() => InputShim.GetButton(_buttonName.Value);

        protected override string TrueSummary => "{_buttonName} pressed";

        protected override string FalseSummary => "{_buttonName} not pressed";
    }
}
