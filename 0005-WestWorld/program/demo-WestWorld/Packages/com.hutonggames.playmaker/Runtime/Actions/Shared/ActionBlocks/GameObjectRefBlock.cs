using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public class GameObjectRefBlock : BaseActionBlock
    {
        [HideLabel]
        [Tooltip("Select a GameObject variable.")]
        public GameObjectRef GameObject;
    }
}