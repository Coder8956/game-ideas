using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.PauseSystem)]
    [ActionDescription("Request game resume. Sends OnGameResumed when pause ends. See Online Help for details.")]
    public sealed class ResumeGame : BaseAction
    {
        public override void Execute()
        {
            if (PauseManager.TryRemovePauseRequest(GetOwner())) return;
            
            // Fallback for cross-FSM flows where the opener and closer are different owners.
            PauseManager.RemoveAnyPauseRequest();
        }

        private Object GetOwner()
        {
            if (OwnerFsmComponent != null) return OwnerFsmComponent;
            if (OwnerGameObject != null) return OwnerGameObject;
            return Owner;
        }

        public override string GetSummary()
        {
			return "Resume game";
        }
    }
}
