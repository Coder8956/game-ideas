using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ConvertibleGroup("PhysicsRayCast")]
    [ActionCategory(Category.PhysicsQueries)]
    [ActionDescription("Casts a ray against all colliders in the Scene, using a Ray variable.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Physics.Raycast.html")]
    [MovedFrom(true, null, null, "PhysicsRayCast__Ray")]
    public class PhysicsRaycast__Ray : BasePhysicsRaycast
    {
        public override Vector3 StartPosition
        {
            get => _ray.Value.origin;
            set { } // readonly
        }

        public override Vector3 DirectionVector
        {
            get => _ray.Value.direction;
            set { } // readonly
        }
        
        public override Vector3 EndPosition
        {
            get => StartPosition + DirectionVector * MaxDistance.Value;
            set { } // readonly
        }

        [DisplayOrder(-10)]
        [Tooltip("Ray to use for the Raycast.")]
        [SerializeField]
        private RayRef _ray;

        public override bool CanExecute() => CheckParameters(_ray) && base.CanExecute();

        public override string GetSummary() => "Raycast {_ray} " + base.GetSummary();
    }
}