
using System;
using HutongGames.PlayMaker.UGUIEvents;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.Actions.EventSystems
{
    [Serializable]
    public abstract class BasePointerButtonEventAction<T> : BasePointerEventAction<T>
        where T : BaseInputProxyComponent
    {
        [Tooltip("Only trigger when this mouse button is used.")] 
        [SerializeField]
        protected PointerButtonFilter _button = PointerButtonFilter.Any;

        protected override bool PassesFilters(PointerEventData e)
        {
            if (!base.PassesFilters(e)) return false;
            if (_button == PointerButtonFilter.Any) return true;

            var wanted = _button switch
            {
                PointerButtonFilter.Left => PointerEventData.InputButton.Left,
                PointerButtonFilter.Right => PointerEventData.InputButton.Right,
                PointerButtonFilter.Middle => PointerEventData.InputButton.Middle,
                _ => PointerEventData.InputButton.Left
            };

            return e.button == wanted;
        }

        public override string GetSummary()
        {
            var s = base.GetSummary();

            if (_button != PointerButtonFilter.Any)
                s += $" ({_button})";

            return s;
        }
    }
}