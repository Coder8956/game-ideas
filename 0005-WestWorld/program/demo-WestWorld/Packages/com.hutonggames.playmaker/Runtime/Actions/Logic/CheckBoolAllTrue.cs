using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicCollection)]
    [ConvertibleGroup("CheckBoolAll")]
    [ActionDescription("Tests if all the given Bool Variables are True.")]
    public class CheckBoolAllTrue : BaseTrueFalseAction
    {
        [Tooltip("The Bool variables to test.")]
        public List<BoolRef> BoolVariables;
        
        protected override bool Test()
        {
            foreach (var b in BoolVariables)
            {
                if (!b.Value) return false;
            }

            return true;
        }

        protected override string TrueSummary => "{BoolVariables} are all true";
        protected override string FalseSummary => "{BoolVariables} are not all true";
    }
}