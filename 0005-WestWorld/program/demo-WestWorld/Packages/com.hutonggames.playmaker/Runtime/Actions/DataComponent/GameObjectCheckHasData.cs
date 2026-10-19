using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObjectData)]
    [ConvertibleGroup("GameObjectData")]
    [ActionDescription("Check if a Data Component exists on a GameObject.")]
    [HelpURL("actions/data-actions/game-object/game-object-check-has-data/")]
    public class GameObjectCheckHasData : BaseTrueFalseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;

        [OptionalField]
        [Tooltip("Optional DataDefinition to filter by. Useful if the GameObject has multiple Data Components.")]
        public DataDefinition DataDefinition;
        
        protected override bool Test()
        {
            var data = DataRecordComponent.FindMatching(GameObject.Value, DataDefinition);
            return data != null;
        }

        protected override string TrueSummary => "Has {DataDefinition}";
        protected override string FalseSummary => "Does not have {DataDefinition}";
    }
}