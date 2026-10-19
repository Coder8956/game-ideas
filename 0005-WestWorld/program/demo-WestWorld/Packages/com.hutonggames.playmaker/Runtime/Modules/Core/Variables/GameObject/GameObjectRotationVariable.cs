using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(GameObjectVariable), typeof(Quaternion), "rotation")]
    public class GameObjectRotationVariable : BaseGameObjectProperty<Quaternion>
    {
        public override string PropertyName => "rotation";
        
#if UNITY_EDITOR
        public override string Description => "The GameObject's rotation.";
#endif

        public override Quaternion Value
        {
            get => GameObject ? GameObject.transform.rotation : Quaternion.identity;
            set
            {
                if (GameObject) GameObject.transform.rotation = value;
            }
        }
    }
}