using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    public abstract class GameObjectTweenAction : BaseTweenAction
    {
        public override Transform TargetTransform => GameObject.Value != null ? GameObject.Value.transform : null;
        
        [OwnerDefaultValue]
        [DisplayOrder(-100)]
        [ActionTarget]
        [Tooltip("The GameObject to tween.")]
        public GameObjectVar GameObject;

        public override bool CanExecute() => base.CanExecute() && GameObject.HasValue();
    }
}