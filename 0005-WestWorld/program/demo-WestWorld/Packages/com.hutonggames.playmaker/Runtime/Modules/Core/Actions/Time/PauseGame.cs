using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.PauseSystem)]
    [ActionDescription("Request game pause. Sends OnGamePaused when pause starts. See Online Help for details.")]
    public sealed class PauseGame : BaseAction
    {
        public override void Execute()
        {
            PauseManager.RequestPause(GetOwner());
        }

        private Object GetOwner()
        {
            if (OwnerFsmComponent != null) return OwnerFsmComponent;
            if (OwnerGameObject != null) return OwnerGameObject;
            return Owner;
        }

        public override string GetSummary()
        {
			return "Pause game";
        }
    }
}
