using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [MovedFrom("Actions.Sprite")]
    [ActionCategory(Category.GameplayRenderingSprites)]
    [ActionDescription("Sets GraphicsSettings.transparencySortMode to CustomAxis and GraphicsSettings.transparencySortAxis to (0, 1, 0).")]
    [HelpURL("actions/sprite-actions/sort-sprites-for-top-down-game/")]
    public class SortSpritesForTopDownGame : BaseAction
    {
        public override void Execute()
        {
            GraphicsSettings.transparencySortMode = TransparencySortMode.CustomAxis;
            GraphicsSettings.transparencySortAxis = new Vector3(0, 1, 0);
        }
    }
}
