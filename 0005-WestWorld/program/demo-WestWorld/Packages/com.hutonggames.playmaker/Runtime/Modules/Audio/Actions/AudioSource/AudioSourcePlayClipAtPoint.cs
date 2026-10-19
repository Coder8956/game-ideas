
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ConvertibleGroup("AudioPlay")]
	[ActionDescription("Plays an AudioClip at a given position in world space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource.PlayClipAtPoint.html")]
	public sealed class AudioSourcePlayClipAtPoint : BaseAction
	{
		
		[Tooltip("Audio data to play.")]
		[SerializeField]
		private AudioClipVar _clip;
		
		[Tooltip("Position in world space from which sound originates.")]
		[SerializeField]
		private Vector3Var _position;
		
		[Tooltip("Playback volume.")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _volume;
		
		public override bool CanExecute()
		{
			return CheckParameters(_clip, _position, _volume);
		}
		
		public override void Execute()
		{
			//UnityEngine.AudioSource.PlayClipAtPoint(UnityEngine.AudioClip, UnityEngine.Vector3, System.Single);
			AudioSource.PlayClipAtPoint(_clip.Value, _position.Value, _volume.Value);
		}
		
		public override string GetSummary()
		{
			return "Play {_clip} at {_position}" +
			       (_volume.IsNotDefault(1) ? "({_volume})" : "");
		}
	}
}
