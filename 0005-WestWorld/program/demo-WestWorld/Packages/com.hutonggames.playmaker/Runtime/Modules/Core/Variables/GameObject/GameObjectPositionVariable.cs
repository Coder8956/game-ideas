using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(GameObjectVariable), typeof(Vector3), "position")]
    public class GameObjectPositionVariable : BaseGameObjectProperty<Vector3>
    {
        public override string PropertyName => "position";
        
#if UNITY_EDITOR
        public override string Description => "The GameObject's position.";
#endif

        public override Vector3 Value
        {
            get => GameObject ? GameObject.transform.position : Vector3.zero;
            set
            {
                if (GameObject) GameObject.transform.position = value;
            }
        }
    }
}