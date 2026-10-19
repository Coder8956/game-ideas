using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Vector3)]
    [ActionDescription("Get a direction vector from a source vector. " +
                       "If the source vector length is below a threshold value, leave the target vector unchanged.")]
    public sealed class Vector3GetDirection : BaseAction
    {
        [Tooltip("The Vector3 to get a direction from.")]
        [SerializeField]
        private Vector3Ref _source;
		
        [Tooltip("Minimum length of the source vector.")]
        [SerializeField]
        private FloatVar _threshold;
		
        [Tooltip("Get a direction vector from source if its length is greater than the threshold.")]
        [SerializeField]
        [WriteOnly]
        private Vector3Ref _getDirection;

        [DefaultValue(1)]
        [Tooltip("The length of the direction vector.")]
        [SerializeField]
        private FloatVar _length;
		
	
        public override bool CanExecute() => CheckParameters(_source, _threshold, _getDirection);
		
        public override void Execute()
        {
            var threshold = _threshold.Value;
            if (_source.Value.sqrMagnitude < threshold * threshold)
            {
                return;
            }
            _getDirection.Value = _source.Value.normalized * _length.Value;
        }
		
        public override string GetSummary() => "Get Direction from {_source} -> {_getDirection} ";
    }
}