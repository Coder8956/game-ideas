using System;
using System.Collections.Generic;
using HutongGames.Extensions;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Random)]
    [ActionDescription("Find a valid random position using a generator block and validator blocks.")]
    public class FindValidRandomPosition : BaseAction
    {
        [SerializeReference]
        [ShowActionBlockTitle]
        [DisplayName("Random Position")]
        [Tooltip("Generates candidate positions to test.")]
        [DefaultValue(typeof(RandomPositionInSphereGeneratorBlock))]
        public SpawnPositionGeneratorBlock Generator;

        [OptionalField]
        [SerializeReference]
        [DisplayName("Modifiers")]
        [Tooltip("Modifiers that can adjust the candidate position before validation.")]
        public List<SpawnPositionModifierBlock> Modifiers;

        [OptionalField]
        [SerializeReference]
        [DisplayName("Validators")]
        [Tooltip("Validators that must all pass for the candidate position to be accepted.")]
        public List<SpawnPositionValidatorBlock> Validators;

        [ActionHeader("Settings")]
        [DefaultValue(10)]
        [Tooltip("Maximum number of attempts before failing.")]
        public IntegerVar MaxAttempts;

        [ActionHeader("Outputs")]
        [WriteOnly]
        [Tooltip("Store the valid world position.")]
        public Vector3Ref StorePosition;

        [OptionalField]
        [WriteOnly]
        [Tooltip("Store the valid world rotation. Identity is stored if the selected generator does not set rotation.")]
        public QuaternionRef StoreRotation;

        [OptionalField]
        [WriteOnly]
        [Tooltip("Store whether a valid position was found.")]
        public BoolRef PositionFound;

        [OptionalField]
        [Tooltip("Event to send if a valid position is found.")]
        public EventRef SuccessEvent;

        [OptionalField]
        [Tooltip("Event to send if no valid position is found.")]
        public EventRef FailureEvent;

        [NonSerialized] public Vector3 CandidatePosition;
        [NonSerialized] public Quaternion CandidateRotation;
        [NonSerialized] public int AttemptIndex;

        public override bool CanExecute() =>
            Generator != null
            && Generator.IsValid
            && Generator.CanExecute()
            && CheckParameters(MaxAttempts, StorePosition)
            && ModifiersCanExecute()
            && ValidatorsCanExecute();

        public override void Execute()
        {
            var maxAttempts = Mathf.Max(1, MaxAttempts.Value);

            if (PositionFound.IsAssigned)
            {
                PositionFound.Value = false;
            }

            for (var i = 0; i < maxAttempts; i++)
            {
                AttemptIndex = i;
                CandidatePosition = Vector3.zero;
                CandidateRotation = Quaternion.identity;

                Generator.Generate(this);
                if (!ApplyModifiers()) continue;

                if (!IsCandidateValid()) continue;

                StorePosition.Value = CandidatePosition;
                if (StoreRotation.IsAssigned)
                {
                    StoreRotation.Value = CandidateRotation;
                }
                if (PositionFound.IsAssigned)
                {
                    PositionFound.Value = true;
                }
                SendEvent(SuccessEvent);
                return;
            }

            SendEvent(FailureEvent);
        }

        private bool ModifiersCanExecute()
        {
            if (Modifiers == null) return true;

            foreach (var modifier in Modifiers)
            {
                if (modifier == null) continue;
                if (!modifier.IsValid || !modifier.CanExecute()) return false;
            }

            return true;
        }

        private bool ValidatorsCanExecute()
        {
            if (Validators == null) return true;

            foreach (var validator in Validators)
            {
                if (validator == null) continue;
                if (!validator.IsValid || !validator.CanExecute()) return false;
            }

            return true;
        }

        private bool ApplyModifiers()
        {
            if (!CandidatePosition.IsFinite()) return false;

            if (Modifiers == null) return true;

            foreach (var modifier in Modifiers)
            {
                if (modifier == null) continue;
                if (!modifier.ModifyCandidate(this)) return false;
                if (!CandidatePosition.IsFinite()) return false;
            }

            return true;
        }

        private bool IsCandidateValid()
        {
            if (!CandidatePosition.IsFinite()) return false;

            if (Validators == null) return true;

            foreach (var validator in Validators)
            {
                if (validator == null) continue;
                if (!validator.IsValidPosition(this)) return false;
            }

            return true;
        }

        public override string GetSummary() =>
            $"Find {{Generator}}{SpawnPositionSummaryUtility.GetBlockListSummary(Modifiers)} -> {{StorePosition}} {{StoreRotation:output}}";
    }
}
