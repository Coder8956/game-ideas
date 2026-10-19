/* Add if requested
using System;
using HutongGames.PlayMaker.SaveSystem;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.SaveSystem)]
    [ActionDescription("Save a global variable in the save file. " +
                       "Globals must be marked to save in the Inspector.")]
    public class SaveGlobalVariable : BaseAction
    {
        [Tooltip("The global variable to save.")]
        [SerializeField]
        private GlobalVariableAssetVar _globalVariable;

        public override bool CanExecute() => _globalVariable.Value != null;

        public override void Execute()
        {
            SaveManager.SaveGlobalVariable(_globalVariable.Value, true);
        }
    }
}*/