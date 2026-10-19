using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Timer)]
    [ActionDescription("Get state and timing info from a Timer.")]
    public sealed class TimerGetInfo : BaseTimerAction
    {
        [ActionHeader("Output")]

        [OptionalField, WriteOnly]
        [Tooltip("Store the remaining time in seconds.")]
        public FloatRef RemainingTime;

        [OptionalField, WriteOnly]
        [Tooltip("Store the elapsed time in seconds.")]
        public FloatRef ElapsedTime;

        [OptionalField, WriteOnly]
        [Tooltip("Store normalized progress from 0 to 1.")]
        public FloatRef StoreProgress;

        [OptionalField, WriteOnly]
        [Tooltip("Store whether the timer has started.")]
        public BoolRef HasStarted;

        [OptionalField, WriteOnly]
        [Tooltip("Store whether the timer is currently running.")]
        public BoolRef IsRunning;

        [OptionalField, WriteOnly]
        [Tooltip("Store whether the timer is paused.")]
        public BoolRef IsPaused;

        [OptionalField, WriteOnly]
        [Tooltip("Store whether the timer is done.")]
        public BoolRef IsDone;

        public override void Execute()
        {
            var timer = GetTimer();

            var remaining = timer?.RemainingTime ?? 0f;
            var elapsed = timer?.ElapsedTime ?? 0f;
            var progress = timer?.Progress ?? 0f;
            var hasStarted = timer?.HasStarted ?? false;
            var isRunning = timer?.IsRunning ?? false;
            var isPaused = timer?.IsPaused ?? false;
            var isDone = timer?.IsDone ?? false;

            if (!RemainingTime.IsNone) RemainingTime.Value = remaining;
            if (!ElapsedTime.IsNone) ElapsedTime.Value = elapsed;
            if (!StoreProgress.IsNone) StoreProgress.Value = progress;
            if (!HasStarted.IsNone) HasStarted.Value = hasStarted;
            if (!IsRunning.IsNone) IsRunning.Value = isRunning;
            if (!IsPaused.IsNone) IsPaused.Value = isPaused;
            if (!IsDone.IsNone) IsDone.Value = isDone;
        }

        public override string GetSummary() =>
            "Get {Timer} info {RemainingTime:output} {ElapsedTime:output} {StoreProgress:output} " +
            "{HasStarted:output} {IsRunning:output} {IsPaused:output} {IsDone:output}";
    }
}
