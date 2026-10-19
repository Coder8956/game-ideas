
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ConvertibleGroup("AudioPlay")]
	[ActionDescription("Plays an AudioClip at a Transform's position.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource.PlayClipAtPoint.html")]
	public sealed class AudioSourcePlayClipAtTransform : BaseAction
	{
		
		[Tooltip("Audio data to play.")]
		[SerializeField]
		private AudioClipVar _clip;
		
		[Tooltip("Transform from which sound originates.")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Playback volume.")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _volume;
		
		public override bool CanExecute()
		{
			return CheckParameters(_clip, _transform, _volume);
		}
		
		public override void Execute()
		{
			AudioSource.PlayClipAtPoint(_clip.Value, _transform.Value.position, _volume.Value);
		}
		
		public override string GetSummary()
		{
			return "Play {_clip} at {_transform}" +
			       (_volume.IsNotDefault(1) ? "({_volume})" : "");
		}
	}
}
