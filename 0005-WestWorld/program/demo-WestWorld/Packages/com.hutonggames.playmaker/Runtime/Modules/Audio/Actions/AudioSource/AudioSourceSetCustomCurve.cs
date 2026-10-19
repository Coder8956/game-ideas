
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Set the custom curve for the given AudioSourceCurveType.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource.SetCustomCurve.html")]
	public sealed class AudioSourceSetCustomCurve : BaseAction
	{
		
		[Tooltip("The AudioSource.")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("The curve type that should be set.")]
		[SerializeField]
		private AudioSourceCurveTypeVar _type;
		
		[Tooltip("The curve that should be applied to the given curve type.")]
		[SerializeField]
		private AnimationCurveVar _curve;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _type, _curve);
		}
		
		public override void Execute()
		{
			//UnityEngine.AudioSource.SetCustomCurve(UnityEngine.AudioSourceCurveType, UnityEngine.AnimationCurve);
			_audioSource.Value.SetCustomCurve(_type.Value, _curve.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} custom curve {_type} to {_curve}";
		}
	}
}
