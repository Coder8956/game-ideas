/* Add if requested
using System;
using HutongGames.PlayMaker.SaveSystem;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.SaveSystem)]
    [ActionDescription("Load a global variable from the save file. " +
                       "Globals must be marked to save in the Inspector.")]
    public class LoadGlobalVariable : BaseAction
    {
        [Tooltip("The global variable to load.")]
        [SerializeField]
        private GlobalVariableAssetRef _globalVariable;

        public override bool CanExecute() => _globalVariable.Value != null;

        public override void Execute()
        {
            SaveManager.LoadGlobalVariable(_globalVariable.Value, true);
        }
    }
}*/