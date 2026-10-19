using System;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.RandomFromList)]
    public class SendRandomEvent : BaseAction
    {
        [HideLabel]
        [Tooltip("A list of events to pick from. The weight determines how likely an item is to be chosen.")]
        public WeightedEventRefList Events;
        
        [Tooltip("Don't send the same event twice in a row." +
                 "\nNOTE: Does not apply across scene loading/unloading.")]
        public BoolVar NoRepeat;

        private BaseEvent _lastEvent;

        public override bool CanExecute() => CheckParameters(Events, NoRepeat);

        public override void Execute()
        {
            EventRef randomEvent = null;
            var maxAttempts = Mathf.Max(1, Events.Count * 4);

            for (var i = 0; i < maxAttempts; i++)
            {
                var candidate = Events.GetRandomItem();
                if (!NoRepeat.Value || _lastEvent == null || candidate == null || !candidate.Matches(_lastEvent))
                {
                    randomEvent = candidate;
                    break;
                }
            }

            randomEvent ??= Events.GetRandomItem();
            SendEvent(randomEvent);
            _lastEvent = randomEvent?.Event;
        }
        
        public override string GetSummary() => "Send Random Event from {Events}";
    }
}
