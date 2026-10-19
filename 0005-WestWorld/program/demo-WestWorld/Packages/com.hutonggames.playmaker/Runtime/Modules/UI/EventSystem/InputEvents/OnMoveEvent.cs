using System;
using HutongGames.PlayMaker.UGUIEvents;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions.EventSystems
{
    [Serializable, PublicAPI]
    [ActionDescription("Called when a move event occurs (left, right, up, down). " + SystemEvents.UIEventsNotes)]
    [ActionCategory(Category.InputEvents)]
    public class OnMoveEvent : BaseAxisEventAction<OnMoveEventProxyComponent>
    {
    }
}