using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Events
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Events)]
    [ActionDescription("Invoke a Unity Event.")]
    public class InvokeUnityEvent : BaseDelayedEventAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.Update;

        [Tooltip("The event to invoke.")]
        [SerializeField] private UnityEventVar _unityEvent;

        public override bool CanExecute() => _unityEvent is { IsNone: false };

        public override void Execute()
        {
            if(!CheckTimer()) return;
            
            _unityEvent?.Value?.Invoke();
        }
        
        public override string GetSummary() => 
            "Invoke {_unityEvent}" + base.GetSummary();
    }
}
