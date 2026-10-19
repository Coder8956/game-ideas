using System;
using HutongGames.PlayMaker.UGUIEvents;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions.EventSystems
{
    [Serializable, PublicAPI]
    [ActionDescription("Called on the drag object when a drag finishes. " + SystemEvents.UIEventsNotes)]
    [ActionCategory(Category.InputEvents)]
    public class OnEndDragEvent : BasePointerEventAction<OnEndDragEventProxyComponent>
    {
    }
}