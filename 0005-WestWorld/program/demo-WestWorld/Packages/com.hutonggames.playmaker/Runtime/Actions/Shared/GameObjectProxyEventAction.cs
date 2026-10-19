using System;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Base class for actions that target a GameObject and use a proxy event.
    /// <see cref="OnCollisionEnter"/> as an example.
    /// </summary>
    /// <typeparam name="T">The type of the proxy event.</typeparam>
    [Serializable]
    public abstract class GameObjectProxyEventAction<T> : GameObjectAction where T : BaseEvent, new()
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.Update | UpdateMode.OnEventUpdate;
        public override UpdateMode AllowedUpdateModes => UpdateMode.OnEventUpdate;

        [NonSerialized]
        private T _event;
        
        public override void OnStart()
        {
            if (GameObject.HasValue())
            {
                _event ??= new T();
                _event.RegisterCallback(GameObject.Value, OwnerComponent);
            }
        }
        
        public override void OnStop()
        { 
            _event?.UnregisterCallback(OwnerComponent);
        }
        
    }
}