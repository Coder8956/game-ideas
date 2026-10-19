using System;
using HutongGames.PlayMaker.UGUIEvents;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions.EventSystems
{
    [Serializable, PublicAPI]
    [ActionDescription("Called on the selected object each tick. " + SystemEvents.UIEventsNotes)]
    [ActionCategory(Category.InputEvents)]
    public class OnUpdateSelectedEvent : BaseEventAction<OnUpdateSelectedEventProxyComponent>
    {
    }
}