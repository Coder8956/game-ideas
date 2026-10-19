using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicCollection)]
    [ConvertibleGroup("CheckBoolAll")]
    [ActionDescription("Tests if any of the given Bool Variables are True.")]
    public class CheckBoolAnyTrue : BaseTrueFalseAction
    {
        [Tooltip("The Bool variables to test.")]
        public List<BoolRef> BoolVariables;
        
        protected override bool Test()
        {
            foreach (var b in BoolVariables)
            {
                if (b.Value) return true;
            }

            return false;
        }

        protected override string TrueSummary => "{BoolVariables} are any true";
        protected override string FalseSummary => "{BoolVariables} are all false";
    }
}