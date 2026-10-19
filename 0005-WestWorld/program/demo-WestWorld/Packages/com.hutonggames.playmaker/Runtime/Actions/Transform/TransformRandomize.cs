using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Randomize the position, rotation and scale of a Transform.")]
    [HelpURL("actions/transform-actions/transform-value-actions/")]
    public class TransformRandomize : BaseAction
    {
        [SerializeField]
        [Tooltip("The Transform to randomize.")]
        private TransformVar _transform;
        
        [Tooltip("Maximum offset per axis. Interpreted as ± value.")]
        [SerializeField]
        private RandomAxisValue _offset;
        
        [Tooltip("Maximum rotation per axis in degrees. Interpreted as ± value.")]
        [SerializeField]
        private RandomAxisValue _rotation;
        
        [Tooltip("Maximum scale delta per axis. 0.2 => scale in [0.8, 1.2].")]
        [SerializeField]
        private RandomAxisValue _scaleDelta;
        
        [Tooltip("Probability of flipping each axis. 0 = never, 1 = always.")]
        [SerializeField]
        private RandomAxisValue _flipChance;

        public override bool CanExecute() => CheckParameters(_transform);

        public override void Execute()
        {
            var transform = _transform.Value;
            if (transform == null) return;

            var position = transform.position;
            var rotation = transform.rotation;
            var scale = transform.localScale;
            
            Apply(ref position, ref rotation, ref scale);
            
            transform.position = position;
            transform.rotation = rotation;
            transform.localScale = scale;
            
        }
        
        public void Apply(ref Vector3 position, ref Quaternion rotation, ref Vector3 scale)
        {
            _offset.ApplyOffset(ref position);
            _rotation.ApplyRotationDegrees(ref rotation);
            _scaleDelta.ApplyScaleDelta(ref scale);
            
            if (!_flipChance.IsEnabled) return;
            
            // Flip (probability 0–1)
            var flip = _flipChance.GetVector3();

            if (flip.x > 0f && Random.value < flip.x) scale.x *= -1f;
            if (flip.y > 0f && Random.value < flip.y) scale.y *= -1f;
            if (flip.z > 0f && Random.value < flip.z) scale.z *= -1f;
        }
        
        public override string GetSummary() => 
            "Randomize {_transform} " +
            (_offset.IsEnabled ? "offset " : "") +
            (_rotation.IsEnabled ? "rotation " : "") +
            (_scaleDelta.IsEnabled ? "scale " : "") +
            (_flipChance.IsEnabled ? "flip " : "");
    }
}