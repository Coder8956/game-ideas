// NOTE: The new Input System and legacy Input Manager can both be enabled in a project.
// "New-only" means: Input System is enabled AND installed, and legacy is not enabled.
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM && !ENABLE_LEGACY_INPUT_MANAGER
#define NEW_INPUT_SYSTEM_ONLY
#endif

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    public abstract class BaseLegacyInputAction : BaseAction
    {
        public override bool CanExecute()
        {
#if NEW_INPUT_SYSTEM_ONLY
            return false;
#else
            return true;
#endif
        }
    }
}
