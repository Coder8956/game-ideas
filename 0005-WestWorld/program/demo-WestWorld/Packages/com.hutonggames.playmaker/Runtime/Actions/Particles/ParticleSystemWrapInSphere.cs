using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Particles)]
    [ActionDescription("Wraps world-space particles inside a sphere around a center transform. " +
                       "When particles leave the sphere, they are teleported to the opposite side.")]
    [MovedFrom(true, null, null, "WrapParticlesInSphere")]
    [HelpURL("actions/effects-actions/particles/")]
    public sealed class ParticleSystemWrapInSphere : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        
        [Tooltip("Particle System to wrap. Should use World simulation space.")]
        public ParticleSystemVar ParticleSystem;
        
        [Tooltip("Center of the wrapping sphere. Typically the camera or ship.")]
        public TransformVar Center;
        
        [Tooltip("Radius of the wrapping sphere in world units.")]
        [DefaultValue(100f)]
        public FloatVar Radius;
        
        private ParticleSystem.Particle[] _particles;
        private float _radiusSqr;

        public override void Execute()
        {
            DoWrap();
        }

        private void EnsureParticleBuffer(int maxParticles)
        {
            if (maxParticles <= 0)
                return;

            if (_particles == null || _particles.Length < maxParticles)
            {
                _particles = new ParticleSystem.Particle[maxParticles];
            }
        }

        private void DoWrap()
        {
            var center = Center.Value;
            var ps = ParticleSystem.Value;
            if (ps == null || center == null) 
                return;

            var main = ps.main;
            var maxParticles = main.maxParticles;
            if (maxParticles == 0)
                return;

            EnsureParticleBuffer(maxParticles);

            var alive = ps.GetParticles(_particles);
            if (alive == 0)
                return;

            var centerPos = center.position;;
            var radiusValue = Radius.Value;
            _radiusSqr = radiusValue * radiusValue;

            for (int i = 0; i < alive; i++)
            {
                // In World simulation space, positions are world positions.
                var pos = _particles[i].position;
                var offset = pos - centerPos;
                var sqrMag = offset.sqrMagnitude;

                if (sqrMag > _radiusSqr && sqrMag > 1e-6f)
                {
                    // Wrap to the opposite side of the sphere:
                    // keep the direction, mirror through center.
                    var invMag = 1.0f / Mathf.Sqrt(sqrMag);
                    var dir = offset * invMag;

                    var wrappedPos = centerPos - dir * radiusValue;
                    _particles[i].position = wrappedPos;
                }
            }

            ps.SetParticles(_particles, alive);
        }

        public override string ErrorCheck()
        {
            var ps = ParticleSystem.Value;
            if (ps == null) return null;
            
            return ps.main.simulationSpace != ParticleSystemSimulationSpace.World 
                ? "ParticleSystem should use World simulation space." : null;
        }
        
        public override string GetSummary()
        {
            return "Wrap particles in {ParticleSystem} within {Radius} units of {Center}";
        }
    }
}
