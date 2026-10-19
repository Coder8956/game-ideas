using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the name of the previously active state in the current region.")]
    public class GetPreviousStateName : BaseAction
    {
        [Tooltip("Store the name in a String Variable.")]
        [SerializeField, WriteOnly]
        private StringRef _storeName;

        public override bool CanExecute() => _storeName != null;

        public override void Execute()
        {
            _storeName.Value = State?.Region?.PreviousActiveState?.Name;
        }

        public override string GetSummary() => "Previous state name -> {_storeName}";
    }
}
