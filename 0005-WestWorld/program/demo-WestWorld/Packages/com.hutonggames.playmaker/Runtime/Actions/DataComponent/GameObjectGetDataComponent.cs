using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.GameObjectData)]
    [ConvertibleGroup("GameObjectData")]
    [ActionDescription("Get a Data Component on a GameObject that matches a DataDefinition.")]
    [HelpURL("actions/data-actions/game-object/game-object-get-data-component/")]
    public sealed class GameObjectGetDataComponent : BaseAction
    {
        [Tooltip("The GameObject to read the Data Component from.")]
        public GameObjectVar GameObject;

        [RequiredField]
        [Tooltip("The DataDefinition to look for.\n" +
                 "Used to find a matching Data Component.")]
        public DataDefinition DataDefinition;

        [ActionHeader("Events")]
        [OptionalField]
        [Tooltip("Event to send if the GameObject, DataDefinition, or matching Data Component was not found.")]
        public EventRef NotFoundEvent;

        [ActionHeader("Output")]
        [OptionalField, WriteOnly]
        [Tooltip("Store the matching Data Component.")]
        public DataRecordComponentRef DataComponent;

        [OptionalField, WriteOnly]
        [Tooltip("True if a matching Data Component was found.")]
        public BoolRef Succeeded;

        public override void Execute()
        {
            if (Succeeded.IsAssigned) Succeeded.Value = false;
            if (DataComponent is { IsAssigned: true }) DataComponent.Value = null;

            var go = GameObject.Value;
            if (go == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            var def = DataDefinition;
            if (def == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            var component = DataRecordComponent.FindMatching(go, def);
            if (component == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            if (DataComponent is { IsAssigned: true }) DataComponent.Value = component;
            if (Succeeded.IsAssigned) Succeeded.Value = true;
        }

        public override string GetSummary()
        {
            return "Get {DataDefinition} Data Component on {GameObject}";
        }
    }
}
