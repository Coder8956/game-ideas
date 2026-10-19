using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(GameObjectVariable), typeof(GameObject), "parent")]
    public class GameObjectParentVariable : BaseGameObjectProperty<GameObject>
    {
        public override string PropertyName => "parent";
        
#if UNITY_EDITOR
        public override string Description => "The parent GameObject.";
#endif

        private Transform ParentTransform => GameObject ? GameObject.transform.parent : null;
        
        public override GameObject Value
        {
            get => ParentTransform ? ParentTransform.gameObject : null;
            set
            {
                if (GameObject) GameObject.transform.parent = value ? value.transform : null;
            }
        }
    }
}
