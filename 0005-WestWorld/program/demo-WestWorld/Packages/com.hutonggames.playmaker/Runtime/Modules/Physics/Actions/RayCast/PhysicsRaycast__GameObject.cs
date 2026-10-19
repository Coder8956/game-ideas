using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [HasSceneGUI]
    [Serializable, PublicAPI]
    [ConvertibleGroup("PhysicsRayCast")]
    [ActionCategory(Category.PhysicsQueries)]
    [ActionDescription("Casts a ray from a GameObject, against all colliders in the Scene.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Physics.Raycast.html")]
    [MovedFrom(true, null, null, "PhysicsRayCast__GameObject")]
    public class PhysicsRaycast__GameObject : BasePhysicsRaycast
    {
        public override Vector3 StartPosition
        {
            get => _origin.Transform.position;
            set => _origin.Transform.position = value;
        }
        
        public override Vector3 DirectionVector
        {
            get => _inSpace.Value == Space.Self ? _origin.Transform.TransformDirection(_direction.Value) : _direction.Value;
            set => _direction.Value = _inSpace.Value == Space.Self ? _origin.Transform.InverseTransformDirection(value) : value;
        }
        
        public override Vector3 EndPosition
        {
            get => StartPosition + DirectionVector;
            set => DirectionVector = value - StartPosition;
        }
        
        public override Quaternion TargetGizmoRotation => 
            _inSpace.Value == Space.World ? Quaternion.identity : OwnerTransform.rotation;

        [OwnerDefaultValue]
        [DisplayOrder(-10)]
        [Tooltip("GameObject to cast the ray from.")]
        [SerializeField]
        private GameObjectVar _origin;
        
        [DisplayOrder(-9)]
        [Tooltip("Direction of the RayCast.")]
        [DefaultValue("Vector3.forward")]
        [SerializeField]
        private Vector3Var _direction;
        
        [DisplayOrder(-8)]
        [Tooltip("<b>Self</b>: direction relative to the transform's local axes." +
                 "<br/><b>World</b>: direction relative to the world coordinate system.")]
        [SerializeField]
        private SpaceVar _inSpace;

        public override bool CanExecute() => CheckParameters(_origin, _direction, _inSpace) && base.CanExecute();
        
        public override string GetSummary() => "Raycast from: {_origin} {_direction} " + base.GetSummary();
    }
}