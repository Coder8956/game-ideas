using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public class GameObjectVarBlock : BaseActionBlock
    {
        public override bool IsValid => GameObject.HasValue();

        [HideLabel]
        [Tooltip("Select a GameObject")]
        public GameObjectVar GameObject;
    }
}