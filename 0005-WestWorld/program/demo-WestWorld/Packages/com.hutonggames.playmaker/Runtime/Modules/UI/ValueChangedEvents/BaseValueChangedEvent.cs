using UnityEngine;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    public abstract class BaseValueChangedEvent<TComponent, TValue, TVariable, TEvent> : BaseSystemEvent<TEvent>
        where TComponent : Component
        where TVariable : IVariable, new()
        where TEvent : BaseValueChangedEvent<TComponent, TValue, TVariable, TEvent>, new()
    {
        private BaseFsmComponent _fsmComponent;
        private TComponent _component;
        private bool _initialized;

        public override bool HasData => true;

        protected virtual bool Initialize(Object receiver)
        {
            if (_initialized) return true;

            _fsmComponent = receiver as BaseFsmComponent;
            if (!_fsmComponent) return false;

            _component = _fsmComponent.GameObject.GetComponent<TComponent>();
            if (!_component) return false;

            Data = new TVariable();

            _initialized = true;
            return true;
        }

        public override BaseEvent RuntimeCopy()
        {
            var copy = new TEvent
            {
                Data = Data?.Copy()
            };
            CopyRuntimeStateTo(copy);
            return copy;
        }

        public override void RegisterCallback(Object receiver)
        {
            if (!Initialize(receiver)) return;
            RegisterValueChangedCallback(_component);
        }

        public override void UnregisterCallback(Object receiver)
        {
            if (!_component) return;
            UnregisterValueChangedCallback(_component);
        }

        protected abstract void RegisterValueChangedCallback(TComponent component);
        protected abstract void UnregisterValueChangedCallback(TComponent component);
        protected abstract void SetValue(TValue value);

        protected void OnValueChanged(TValue value)
        {
            SetValue(value);
            _fsmComponent.Fsm.SendEvent(RuntimeCopy());
        }
    }
}
