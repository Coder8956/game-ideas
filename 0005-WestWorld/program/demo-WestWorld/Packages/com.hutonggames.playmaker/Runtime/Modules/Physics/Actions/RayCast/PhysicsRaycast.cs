using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [HasSceneGUI]
    [Serializable, PublicAPI]
    [ConvertibleGroup("PhysicsRayCast")]
    [ActionCategory(Category.PhysicsQueries)]
    [ActionDescription("Casts a ray against all colliders in the Scene. Define the ray using an origin and direction.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Physics.Raycast.html")]
    public class PhysicsRaycast : BasePhysicsRaycast
    {
        public override Vector3 StartPosition
        {
            get => _origin.Value;
            set => _origin.Value = value;
        }

        public override Vector3 DirectionVector
        {
            get => _direction.Value;
            set => _direction.Value = value;
        }
        
        public override Vector3 EndPosition
        {
            get => _origin.Value + _direction.Value;
            set => _direction.Value = value - _origin.Value;
        }

        [DisplayOrder(-10)]
        [Tooltip("Start point of the RayCast.")]
        [SerializeField]
        private Vector3Var _origin;
        
        [DisplayOrder(-9)]
        [Tooltip("Direction of the RayCast.")]
        [DefaultValue("Vector3.forward")]
        [SerializeField]
        private Vector3Var _direction;

        public override bool CanExecute() => CheckParameters(_origin, _direction) && base.CanExecute();
        
        public override string GetSummary() => "Raycast: origin {_origin} dir {_direction} " + base.GetSummary();
    }
}