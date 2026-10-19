using System;
using HutongGames.PlayMaker.SaveSystem;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.SaveSystem)]
    [ActionDescription("Save all global variables in the current save profile. " +
                       "Globals must be marked to save in the Inspector.")]
    public class SaveAllGlobalVariables : BaseAction
    {
        public override void Execute()
        {
            SaveManager.SaveAllGlobalVariables(true);
        }
    }
}