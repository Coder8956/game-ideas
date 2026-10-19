
using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [DisplayName("Input Get Any Key (Hold)")]
    [ActionCategory(Category.InputButton)]
    [ConvertibleGroup(ConvertibleGroup.InputButton)]
    [Tooltip("Check if any key or mouse button is pressed." + Strings.SupportsBothInputSystems)]
    public class InputGetAnyKey : BaseTrueFalseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        
        protected override bool Test() => InputShim.AnyKey();

        protected override string TrueSummary => "any key";

        protected override string FalseSummary => "no key";
    }
}