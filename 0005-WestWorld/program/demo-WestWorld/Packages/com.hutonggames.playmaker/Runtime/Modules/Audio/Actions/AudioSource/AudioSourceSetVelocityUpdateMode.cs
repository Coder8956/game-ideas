
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Whether the Audio Source should be updated in the fixed or dynamic update.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-velocityUpdateMode.html")]
	public sealed class AudioSourceSetVelocityUpdateMode : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Velocity Update Mode")]
		[SerializeField]
		private AudioVelocityUpdateModeVar _setVelocityUpdateMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setVelocityUpdateMode);
		}
		
		public override void Execute()
		{
			_audioSource.Value.velocityUpdateMode = _setVelocityUpdateMode.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} velocity update mode to {_setVelocityUpdateMode}";
		}
	}
}
