using System;
using HutongGames.PlayMaker.UGUIEvents;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions.EventSystems
{
    [Serializable, PublicAPI]
    [ActionDescription("Called when a drag target is found, can be used to initialize values. " + SystemEvents.UIEventsNotes)]
    [ActionCategory(Category.InputEvents)]
    public class OnInitializePotentialDragEvent : BasePointerEventAction<OnInitializePotentialDragEventProxyComponent>
    {
    }
}