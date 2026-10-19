using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ConvertibleGroup("PhysicsRayCast")]
    [ActionCategory(Category.PhysicsQueries)]
    [ActionDescription("Casts a ray from the Mouse Position against all colliders in the Scene.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Physics.Raycast.html")]
    [MovedFrom(true, null, null, "PhysicsRayCast__Mouse")]
    public class PhysicsRaycast__Mouse : BasePhysicsRaycast
    {
        public override Vector3 StartPosition
        {
            get => GetRay().origin;
            set { } // readonly
        }

        public override Vector3 DirectionVector
        {
            get => GetRay().direction;
            set { } // readonly
        }
        
        public override Vector3 EndPosition
        {
            get => StartPosition + DirectionVector * MaxDistance.Value;
            set { } // readonly
        }

        [Tooltip("The Camera to use to cast the ray.")]
        [SerializeField, DefaultValue("~MainCamera")]
        private CameraVar _camera;
        
        private Ray GetRay()
        {
            var mousePosition = InputShim.GetMousePosition();
            return _camera.Value.ScreenPointToRay(mousePosition);
        }

        public override bool CanExecute() => CheckParameters(_camera) && base.CanExecute();
        
        public override string GetSummary() => "Raycast from Mouse " + base.GetSummary();
    }
}