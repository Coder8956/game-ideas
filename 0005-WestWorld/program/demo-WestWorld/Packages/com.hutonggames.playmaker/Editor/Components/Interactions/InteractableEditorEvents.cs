using System;

namespace HutongGames.PlayMaker.Editor
{
    public static class InteractableEditorEvents
    {
        public static event Action Changed;

        public static void RaiseChanged()
        {
            Changed?.Invoke();
        }
    }
}
