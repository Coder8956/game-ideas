using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.GameObjectData)]
    [ConvertibleGroup("GameObjectData")]
    [ActionDescription("Get all Data Components from a GameObject and its children that match a DataDefinition.")]
    [HelpURL("actions/data-actions/game-object/game-object-get-data-in-children/")]
    [MovedFrom(true, null, null, "GameObjectGetDataInChildren")]
    public sealed class GameObjectGetDataComponentsInChildren : BaseAction
    {
        [Tooltip("The root GameObject to search.")]
        public GameObjectVar GameObject;

        [RequiredField]
        [Tooltip("The DataDefinition to look for.\n" +
                 "Only Data Components with matching DataDefinition are returned.")]
        public DataDefinition DataDefinition;

        [Tooltip("Should the search include inactive GameObjects?")]
        public BoolVar IncludeInactive;

        [ActionHeader("Events")]

        [OptionalField]
        [Tooltip("Event to send if the GameObject, DataDefinition, or matching Data Components were not found.")]
        public EventRef NotFoundEvent;

        [ActionHeader("Output")]

        [OptionalField, WriteOnly, DefaultName("First Data Component")]
        [Tooltip("Store the first matching Data Component found in the hierarchy search.")]
        public DataRecordComponentRef FirstDataComponent;

        [OptionalField, WriteOnly, DefaultName("Data Components")]
        [Tooltip("Store all matching Data Components in a list.")]
        public DataRecordComponentListRef DataComponents;

        [OptionalField, WriteOnly]
        [Tooltip("How many matching Data Components were found.")]
        public IntegerRef MatchCount;

        [OptionalField, WriteOnly]
        [Tooltip("True if one or more matching Data Components were found.")]
        public BoolRef Succeeded;

        public override void Execute()
        {
            if (Succeeded.IsAssigned) Succeeded.Value = false;
            if (MatchCount.IsAssigned) MatchCount.Value = 0;

            var storeFirst = FirstDataComponent is { IsAssigned: true };
            if (storeFirst) FirstDataComponent.Value = null;

            List<DataRecordComponent> results = null;
            if (DataComponents is { IsAssigned: true })
            {
                results = DataComponents.Value;
                if (results == null)
                {
                    results = new List<DataRecordComponent>();
                    DataComponents.Value = results;
                }
                else
                {
                    results.Clear();
                }
            }

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

            var components = go.GetComponentsInChildren<DataRecordComponent>(IncludeInactive.Value);
            var count = 0;

            for (var i = 0; i < components.Length; i++)
            {
                var component = components[i];
                if (component == null) continue;

                var data = component.Data;
                if (data == null || data.DataDefinition != def) continue;

                count++;
                if (storeFirst && FirstDataComponent.Value == null)
                    FirstDataComponent.Value = component;
                results?.Add(component);
            }

            if (MatchCount.IsAssigned) MatchCount.Value = count;
            if (Succeeded.IsAssigned) Succeeded.Value = count > 0;
            if (count <= 0)
                SendEvent(NotFoundEvent);
        }

        public override string GetSummary()
        {
            return "Get {DataDefinition} on {GameObject} and children" +
                   (IncludeInactive.Value ? " (including inactive)" : "") +
                   " {FirstDataComponent:output} {DataComponents:output}";
        }
    }
}
