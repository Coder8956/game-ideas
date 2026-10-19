using System;
using HutongGames.PlayMaker.SaveSystem;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.SaveSystem)]
    [ActionDescription("Save all FSM variables to the current save profile. " +
                       "\nVariables must be marked to save in the Inspector.")]
    public class SaveFsmVariables : BaseAction
    {
        public override void Execute()
        {
            SaveManager.SaveFsmVariables(OwnerFsmComponent, true);
        }
    }
}