using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(GameObjectVariable), typeof(Vector2), "position2D")]
    public class GameObjectPosition2DVariable : BaseGameObjectProperty<Vector2>
    {
        public override string PropertyName => "position2D";
        
#if UNITY_EDITOR
        public override string Description => "The GameObject's position as a Vector2.";
#endif

        public override Vector2 Value
        {
            get =>  GameObject ? GameObject.transform.position : Vector2.zero;
            set
            {
                if (GameObject) GameObject.transform.position = value;
            }
        }
    }
}