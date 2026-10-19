using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public abstract class InteractEventDataGetterBase : BaseEventDataGetter
    {
        [OptionalField, WriteOnly]
        [Tooltip("The Transform used by the Interactables system to evaluate this event.")]
        public TransformRef ActorTransform = new();

        [OptionalField, WriteOnly]
        [Tooltip("The Interactable component selected by the Interactables system.")]
        public InteractableRef Interactable = new();

        [OptionalField, WriteOnly]
        [Tooltip("The target GameObject resolved by the Interactables system for this event.")]
        public GameObjectRef Target = new();

        [OptionalField, WriteOnly]
        [Tooltip("The reference transform chosen by the Interactables system for this event.")]
        public TransformRef ReferenceTransform = new();

        [OptionalField, WriteOnly]
        [Tooltip("The interaction value from the selected Interactable.")]
        public StringRef Interaction = new();

        [OptionalField, WriteOnly]
        [Tooltip("The activation identifier from the selected Interactable.")]
        public StringRef ActivationId = new();

        [OptionalField, WriteOnly]
        [Tooltip("The approach normal resolved by the Interactables system for the selected Interactable.")]
        public Vector3Ref Normal = new();

        [OptionalField, WriteOnly]
        [Tooltip("The distance measured by the Interactables system from the actor transform to the selected Interactable.")]
        public FloatRef Distance = new();

        protected void SetData(InteractSystemEventBase interactEvent, BaseEvent baseEvent)
        {
            base.GetDataFromEvent(baseEvent);

            if (ActorTransform.IsAssigned)
            {
                ActorTransform.Value = interactEvent.ActorTransform;
            }

            if (Target.IsAssigned)
            {
                Target.Value = interactEvent.Target;
            }

            if (Interactable.IsAssigned)
            {
                Interactable.Value = interactEvent.Interactable;
            }

            if (ReferenceTransform.IsAssigned)
            {
                ReferenceTransform.Value = interactEvent.ReferenceTransform;
            }

            if (Interaction.IsAssigned)
            {
                Interaction.Value = interactEvent.Interaction;
            }

            if (ActivationId.IsAssigned)
            {
                ActivationId.Value = interactEvent.ActivationId;
            }

            if (Normal.IsAssigned)
            {
                Normal.Value = interactEvent.Normal;
            }

            if (Distance.IsAssigned)
            {
                Distance.Value = interactEvent.Distance;
            }
        }
    }

    [Serializable]
    public abstract class InteractTypedEventDataGetter<TEvent> : InteractEventDataGetterBase where TEvent : InteractSystemEventBase
    {
        public override void GetDataFromEvent(BaseEvent baseEvent)
        {
            if (baseEvent is not TEvent interactEvent)
            {
                Debug.LogWarning($"{baseEvent.Name} Event is not {typeof(TEvent).Name}!");
                return;
            }

            SetData(interactEvent, baseEvent);
        }
    }

    [Serializable]
    [EventData(typeof(OnInteractEvent))]
    public sealed class InteractEventDataGetter : InteractTypedEventDataGetter<OnInteractEvent>
    {
    }

    [Serializable]
    [EventData(typeof(OnInteractFocusEvent))]
    public sealed class InteractFocusEventDataGetter : InteractTypedEventDataGetter<OnInteractFocusEvent>
    {
    }

    [Serializable]
    [EventData(typeof(OnInteractLostFocusEvent))]
    public sealed class InteractLostFocusEventDataGetter : InteractTypedEventDataGetter<OnInteractLostFocusEvent>
    {
    }

    [Serializable]
    [EventData(typeof(OnInteractAvailableEvent))]
    public sealed class InteractAvailableEventDataGetter : InteractTypedEventDataGetter<OnInteractAvailableEvent>
    {
    }

    [Serializable]
    [EventData(typeof(OnInteractUnavailableEvent))]
    public sealed class InteractUnavailableEventDataGetter : InteractTypedEventDataGetter<OnInteractUnavailableEvent>
    {
    }

    [Serializable]
    public abstract class InteractSystemEventBase : BaseSystemEvent
    {
        public Transform ActorTransform { get; protected set; }
        public Interactable Interactable { get; protected set; }
        public GameObject Target { get; protected set; }
        public Transform ReferenceTransform { get; protected set; }
        public string Interaction { get; protected set; }
        public string ActivationId { get; protected set; }
        public Vector3 Normal { get; protected set; }
        public float Distance { get; protected set; }

        protected void CopyRuntimeValuesTo(InteractSystemEventBase copy)
        {
            copy.ActorTransform = ActorTransform;
            copy.Interactable = Interactable;
            copy.Target = Target;
            copy.ReferenceTransform = ReferenceTransform;
            copy.Interaction = Interaction;
            copy.ActivationId = ActivationId;
            copy.Normal = Normal;
            copy.Distance = Distance;
            CopyRuntimeStateTo(copy);
        }

        protected void SetContext(Transform actorTransform,
                                  Interactable interactable,
                                  GameObject target,
                                  Transform referenceTransform,
                                  string interaction,
                                  string activationId,
                                  Vector3 normal,
                                  float distance)
        {
            ActorTransform = actorTransform;
            Interactable = interactable;
            Target = target;
            ReferenceTransform = referenceTransform;
            Interaction = interaction;
            ActivationId = activationId;
            Normal = normal;
            Distance = distance;
        }
    }

    [Serializable]
    [SystemEvent(SystemEvents.InteractablesRoot)]
    [Tooltip("Sent to FSMs on the interactable target GameObject and the actor GameObject when the Interactable is activated.")]
#if UNITY_6000_5_OR_NEWER
    [Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
#endif
    public sealed class OnInteractEvent : InteractSystemEventBase
    {
        public const string InstancePropertyName = nameof(Instance);
        public static OnInteractEvent Instance => _instance ??= new OnInteractEvent();

        private static OnInteractEvent _instance;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void ResetStatics() => _instance = null;

        public static OnInteractEvent Get(Transform actorTransform,
                                          Interactable interactable,
                                          GameObject target,
                                          Transform referenceTransform,
                                          string interaction,
                                          string activationId,
                                          Vector3 normal,
                                          float distance)
        {
            return new OnInteractEvent
            {
                ActorTransform = actorTransform,
                Interactable = interactable,
                Target = target,
                ReferenceTransform = referenceTransform,
                Interaction = interaction,
                ActivationId = activationId,
                Normal = normal,
                Distance = distance
            };
        }

        public override BaseEventDataGetter GetEventDataGetter() => new InteractEventDataGetter();

        public override BaseEvent RuntimeCopy()
        {
            var copy = new OnInteractEvent();
            CopyRuntimeValuesTo(copy);
            return copy;
        }
    }

    [Serializable]
    [SystemEvent(SystemEvents.InteractablesRoot)]
    [Tooltip("Sent to FSMs on the interactable target GameObject and the actor GameObject when the Interactable becomes the current target for interaction.")]
#if UNITY_6000_5_OR_NEWER
    [Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
#endif
    public sealed class OnInteractFocusEvent : InteractSystemEventBase
    {
        public const string InstancePropertyName = nameof(Instance);
        public static OnInteractFocusEvent Instance => _instance ??= new OnInteractFocusEvent();

        private static OnInteractFocusEvent _instance;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void ResetStatics() => _instance = null;

        public static OnInteractFocusEvent Get(Transform actorTransform,
                                               Interactable interactable,
                                               GameObject target,
                                               Transform referenceTransform,
                                               string interaction,
                                               string activationId,
                                               Vector3 normal,
                                               float distance)
        {
            return new OnInteractFocusEvent
            {
                ActorTransform = actorTransform,
                Interactable = interactable,
                Target = target,
                ReferenceTransform = referenceTransform,
                Interaction = interaction,
                ActivationId = activationId,
                Normal = normal,
                Distance = distance
            };
        }

        public override BaseEventDataGetter GetEventDataGetter() => new InteractFocusEventDataGetter();

        public override BaseEvent RuntimeCopy()
        {
            var copy = new OnInteractFocusEvent();
            CopyRuntimeValuesTo(copy);
            return copy;
        }
    }

    [Serializable]
    [SystemEvent(SystemEvents.InteractablesRoot)]
    [Tooltip("Sent to FSMs on the interactable target GameObject and the actor GameObject when the Interactable is no longer the current target for interaction.")]
#if UNITY_6000_5_OR_NEWER
    [Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
#endif
    public sealed class OnInteractLostFocusEvent : InteractSystemEventBase
    {
        public const string InstancePropertyName = nameof(Instance);
        public static OnInteractLostFocusEvent Instance => _instance ??= new OnInteractLostFocusEvent();

        private static OnInteractLostFocusEvent _instance;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void ResetStatics() => _instance = null;

        public static OnInteractLostFocusEvent Get(Transform actorTransform,
                                                   Interactable interactable,
                                                   GameObject target,
                                                   Transform referenceTransform,
                                                   string interaction,
                                                   string activationId,
                                                   Vector3 normal,
                                                   float distance)
        {
            return new OnInteractLostFocusEvent
            {
                ActorTransform = actorTransform,
                Interactable = interactable,
                Target = target,
                ReferenceTransform = referenceTransform,
                Interaction = interaction,
                ActivationId = activationId,
                Normal = normal,
                Distance = distance
            };
        }

        public override BaseEventDataGetter GetEventDataGetter() => new InteractLostFocusEventDataGetter();

        public override BaseEvent RuntimeCopy()
        {
            var copy = new OnInteractLostFocusEvent();
            CopyRuntimeValuesTo(copy);
            return copy;
        }
    }

    [Serializable]
    [SystemEvent(SystemEvents.InteractablesRoot)]
    [Tooltip("Sent to FSMs on the interactable target GameObject and the actor GameObject when the Interactable becomes available to interact with.")]
#if UNITY_6000_5_OR_NEWER
    [Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
#endif
    public sealed class OnInteractAvailableEvent : InteractSystemEventBase
    {
        public const string InstancePropertyName = nameof(Instance);
        public static OnInteractAvailableEvent Instance => _instance ??= new OnInteractAvailableEvent();

        private static OnInteractAvailableEvent _instance;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void ResetStatics() => _instance = null;

        public static OnInteractAvailableEvent Get(Transform actorTransform,
                                                   Interactable interactable,
                                                   GameObject target,
                                                   Transform referenceTransform,
                                                   string interaction,
                                                   string activationId,
                                                   Vector3 normal,
                                                   float distance)
        {
            return new OnInteractAvailableEvent
            {
                ActorTransform = actorTransform,
                Interactable = interactable,
                Target = target,
                ReferenceTransform = referenceTransform,
                Interaction = interaction,
                ActivationId = activationId,
                Normal = normal,
                Distance = distance
            };
        }

        public override BaseEventDataGetter GetEventDataGetter() => new InteractAvailableEventDataGetter();

        public override BaseEvent RuntimeCopy()
        {
            var copy = new OnInteractAvailableEvent();
            CopyRuntimeValuesTo(copy);
            return copy;
        }
    }

    [Serializable]
    [SystemEvent(SystemEvents.InteractablesRoot)]
    [Tooltip("Sent to FSMs on the interactable target GameObject and the actor GameObject when the Interactable is no longer available to interact with.")]
#if UNITY_6000_5_OR_NEWER
    [Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
#endif
    public sealed class OnInteractUnavailableEvent : InteractSystemEventBase
    {
        public const string InstancePropertyName = nameof(Instance);
        public static OnInteractUnavailableEvent Instance => _instance ??= new OnInteractUnavailableEvent();

        private static OnInteractUnavailableEvent _instance;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void ResetStatics() => _instance = null;

        public static OnInteractUnavailableEvent Get(Transform actorTransform,
                                                     Interactable interactable,
                                                     GameObject target,
                                                     Transform referenceTransform,
                                                     string interaction,
                                                     string activationId,
                                                     Vector3 normal,
                                                     float distance)
        {
            return new OnInteractUnavailableEvent
            {
                ActorTransform = actorTransform,
                Interactable = interactable,
                Target = target,
                ReferenceTransform = referenceTransform,
                Interaction = interaction,
                ActivationId = activationId,
                Normal = normal,
                Distance = distance
            };
        }

        public override BaseEventDataGetter GetEventDataGetter() => new InteractUnavailableEventDataGetter();

        public override BaseEvent RuntimeCopy()
        {
            var copy = new OnInteractUnavailableEvent();
            CopyRuntimeValuesTo(copy);
            return copy;
        }
    }
}
