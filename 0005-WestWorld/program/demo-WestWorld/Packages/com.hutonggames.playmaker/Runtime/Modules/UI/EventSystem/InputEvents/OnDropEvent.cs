using System;
using HutongGames.PlayMaker.UGUIEvents;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions.EventSystems
{
    [Serializable, PublicAPI]
    [ActionDescription("Called on the object where a drag finishes. " + SystemEvents.UIEventsNotes)]
    [ActionCategory(Category.InputEvents)]
    public class OnDropEvent : BasePointerEventAction<OnDropEventProxyComponent>
    {
    }
}