using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Shared helper base for Data UI action components.
    /// Keeps request-building consistent across Tap/LongPress/Drag/etc.
    /// </summary>
    [Icon(Strings.EditorIconsPath + "DataRowSelectionIcon.png")]
    public abstract class DataItemActionBase : MonoBehaviour
    {
        [SerializeField, Tooltip("Optional identifier for which part of the item this component represents " +
                                 "(e.g. Body, DeleteButton, DragHandle).")]
        private string _identifier;
        
        [HideInInspector]
        [SerializeField, Tooltip("Optional int parameter. Interpretation depends on the widget/host.")]
        private int _customInt;

        [HideInInspector]
        [SerializeField, Tooltip("Optional string parameter. Interpretation depends on the widget/host.")]
        private string _customString;

        protected string Identifier => _identifier;
        protected int CustomInt => _customInt;
        protected string CustomString => _customString;

        /// <summary>
        /// Sends an action request to the nearest IDataUIContext host.
        /// </summary>
        protected bool TryRequest(DataUICommand command, object payload = null)
        {
            if (command == DataUICommand.None)
                return false;

            var ctx = GetComponentInParent<IDataItemContext>();
            if (ctx?.Host == null)
                return false;

            var req = new DataUIActionRequest(
                itemId: ctx.ItemId,
                itemKey: ctx.ItemKey,
                command: command,
                sourceIndex: -1,
                intArg: _customInt,
                stringArg: _customString,
                itemGameObject: ctx.ItemGameObject,
                interactedGameObject: gameObject,
                identifier: _identifier,
                payload: payload,
                sender: this);

            return ctx.Host.TryHandleAction(in req);
        }

#if UNITY_EDITOR
        // Forces Unity to show the component enable checkbox in the Inspector header.
        // Makes it easy to disable this behaviour via the standard toggle.
        private void Update() { }
#endif

        protected bool IsDirectHit(PointerEventData eventData)
        {
            if (eventData == null)
                return false;

            var hit = eventData.pointerPress != null
                ? eventData.pointerPress
                : eventData.pointerCurrentRaycast.gameObject;

            return hit == gameObject;
        }

        protected void SendItemSystemEvent(BaseEvent evt)
        {
            if (evt == null)
                return;

            var ctx = GetComponentInParent<IDataItemContext>();
            var targetGo = ctx?.ItemGameObject ?? gameObject;
            if (targetGo == null)
                return;

            evt.SentBy(new EventSender(this));

            var fsmComponents = targetGo.GetComponents<BaseFsmComponent>();
            for (int i = 0; i < fsmComponents.Length; i++)
            {
                var fsm = fsmComponents[i];
                if (fsm == null) continue;
                fsm.OnEvent(evt.RuntimeCopy());
            }
        }
    }
}
