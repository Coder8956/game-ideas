
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Get a direction vector from a source vector. " +
	                   "If the source vector length is below a threshold value, leave the target vector unchanged.")]
	public sealed class Vector2GetDirection : BaseAction
	{
		[Tooltip("The Vector2 to get a direction from.")]
		[SerializeField]
		private Vector2Ref _source;
		
		[Tooltip("Minimum length of the source vector.")]
		[SerializeField, DefaultValue(0.1f)]
		private FloatVar _threshold;
		
		[Tooltip("Get a direction vector from source if its length is greater than the threshold.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getDirection;
		
		[Tooltip("The length of the direction vector.")]
		[SerializeField, DefaultValue(1f)]
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
