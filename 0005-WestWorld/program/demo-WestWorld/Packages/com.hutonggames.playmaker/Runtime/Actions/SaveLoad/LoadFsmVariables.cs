using System;
using HutongGames.PlayMaker.SaveSystem;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.SaveSystem)]
    [ActionDescription("Load all FSM variables from the current save profile. " +
                       "\nVariables must be marked to save in the Inspector.")]
    public class LoadFsmVariables : BaseAction
    {
        public override void Execute()
        {
            SaveManager.LoadFsmVariables(OwnerFsmComponent, true);
        }
    }
}