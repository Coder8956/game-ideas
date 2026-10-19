using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Controls common to all Tween Actions with a Direction setting.
    /// </summary>
    [Serializable]
    public abstract class BaseDirectionTweenAction<T, TVar> : BaseTweenAction
    {
        [Tooltip("Tween from or to the given value.")]
        [SerializeField]
        protected TweenDirection _direction;
        
        [Tooltip("The value to tween from/to.")]
        [SerializeField]
        [FormerlySerializedAs("_position")]
        [FormerlySerializedAs("_rotation")]
        [FormerlySerializedAs("_scale")]
        protected TVar _value;
        
        [Tooltip("Defines an offset from the current value.")]
        [SerializeField]
        protected BoolVar _relative;
        
        [NonSerialized] protected T FromValue;
        [NonSerialized] protected T ToValue;
        
        public override bool CanExecute() => CheckParameters(_value, _relative) && base.CanExecute();
        
        public override void OnStart()
        {
            base.OnStart();

            if (_direction == TweenDirection.To)
            {
                FromValue = GetCurrentValue();
                ToValue = GetTargetValue();
            }
            else
            {
                FromValue = GetTargetValue();
                ToValue = GetCurrentValue();           
            }
        }

        protected abstract T GetCurrentValue();
        
        protected abstract T GetTargetValue();
    }
}