using System;
using HutongGames.PlayMaker.SaveSystem;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.SaveSystem)]
    [ActionDescription("Load all global variables in the save file. " +
                       "Globals must be marked to save in the Inspector.")]
    public class LoadAllGlobalVariables : BaseAction
    {
        public override void Execute()
        {
            SaveManager.LoadAllGlobalVariables(true);
        }
    }
}