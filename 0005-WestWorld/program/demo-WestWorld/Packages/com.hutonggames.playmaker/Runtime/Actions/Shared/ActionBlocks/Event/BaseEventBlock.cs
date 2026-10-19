using System;

namespace HutongGames.PlayMaker.Actions
{
    // TODO: RandomEventBlock
    // TODO: SendEventByName?
    // EventVariable? So we can have actions like GetEventByName to then send?
    
    /// <summary>
    /// NOTE: Use the same name for equivalent fields in sub-classes.
    /// This allows auto-conversion to keep the value of those fields.
    /// </summary>
    [Serializable]
    public abstract class BaseEventBlock : BaseActionBlock
    {
    }
}