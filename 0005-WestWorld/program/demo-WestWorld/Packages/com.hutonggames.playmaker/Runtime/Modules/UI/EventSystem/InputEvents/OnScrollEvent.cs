using System;
using HutongGames.PlayMaker.UGUIEvents;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions.EventSystems
{
    [Serializable, PublicAPI]
    [ActionDescription("Called when a mouse wheel scrolls. " + SystemEvents.UIEventsNotes)]
    [ActionCategory(Category.InputEvents)]
    public class OnScrollEvent : BasePointerEventAction<OnScrollEventProxyComponent>
    {
    }
}