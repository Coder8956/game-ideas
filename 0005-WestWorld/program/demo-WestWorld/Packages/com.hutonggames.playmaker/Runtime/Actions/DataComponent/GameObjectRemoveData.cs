using System;
using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.GameObjectData)]
    [ConvertibleGroup("GameObjectData")]
    [ActionDescription("Remove a Data Component (DataRecordComponent) from a GameObject.")]
    [HelpURL("actions/data-actions/game-object/game-object-remove-data/")]
    public sealed class GameObjectRemoveData : BaseAction
    {
        public enum RemoveMode
        {
            FirstMatch,
            AllMatches
        }

        [Tooltip("The GameObject to remove the Data Component from.")]
        public GameObjectVar GameObject;

        [OptionalField]
        [Tooltip("Optional DataDefinition to match.\n" +
                 "If set, removes Data Components whose record uses this DataDefinition.\n" +
                 "If None, removes any Data Components on the GameObject.")]
        public DataDefinition DataDefinition;

        [Tooltip("Remove the first matching component (fast), or all matching components.")]
        public RemoveMode Mode = RemoveMode.FirstMatch;

        [ActionHeader("Events")]
        [OptionalField]
        [Tooltip("Event to send if the GameObject or matching Data Component was not found.")]
        public EventRef NotFoundEvent;

        [ActionHeader("Output")]
        [OptionalField, WriteOnly]
        [Tooltip("True if at least one Data Component was removed.")]
        public BoolRef Removed;

        [OptionalField, WriteOnly]
        [Tooltip("Number of Data Components removed.")]
        public IntegerRef RemovedCount;

        public override void Execute()
        {
            if (Removed.IsAssigned) Removed.Value = false;
            if (RemovedCount.IsAssigned) RemovedCount.Value = 0;

            var go = GameObject.Value;
            if (go == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            var def = DataDefinition;

            // Fast path: no filter + FirstMatch => GetComponent
            if (def == null && Mode == RemoveMode.FirstMatch)
            {
                var c = go.GetComponent<DataRecordComponent>();
                if (c == null)
                {
                    SendEvent(NotFoundEvent);
                    return;
                }

                Object.Destroy(c);

                if (Removed.IsAssigned) Removed.Value = true;
                if (RemovedCount.IsAssigned) RemovedCount.Value = 1;
                return;
            }

            // General path
            var comps = go.GetComponents<DataRecordComponent>();
            if (comps == null || comps.Length == 0)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            var removedCount = 0;

            for (int i = 0; i < comps.Length; i++)
            {
                var c = comps[i];
                if (c == null) continue;

                if (def != null)
                {
                    var record = c.Data;
                    if (record == null) continue;
                    if (record.DataDefinition != def) continue;
                }

                Object.Destroy(c);
                removedCount++;

                if (Mode == RemoveMode.FirstMatch)
                    break;
            }

            if (removedCount <= 0)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            if (Removed.IsAssigned) Removed.Value = true;
            if (RemovedCount.IsAssigned) RemovedCount.Value = removedCount;
        }

        public override string GetSummary()
        {
            return "Remove {DataDefinition} from {GameObject}";
        }
    }
}
