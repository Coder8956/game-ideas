
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioMixer)]
	[ActionDescription(@"Connected groups in the mixer form a path from the mixer's master group to the leaves. This path has the format Master GroupChild of Master GroupGrandchild of Master Group, and so on. For example, in the hierarchy below, the group DROPS has the path MasterWATERDROPS. To return only the group called DROPS, enter DROPS. The substring MasterAMBIENCE returns three groups, AMBIENCECROWD, AMBIENCEROAD, and AMBIENCE. The substring R would return both ROAD and RIVER.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Audio.AudioMixer.FindMatchingGroups.html" +
		"")]
	public sealed class AudioMixerFindMatchingGroups : BaseAction
	{
		
		[Tooltip("The AudioMixer.")]
		[SerializeField]
		private AudioMixerVar _audioMixer;
		
		[Tooltip("Path sub-strings to match with.")]
		[SerializeField]
		private StringVar _subPath;
		
		[Tooltip("Store the result in AudioMixerGroup List variable.")]
		[SerializeField]
		[WriteOnly]
		private AudioMixerGroupListRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioMixer, _subPath, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Audio.AudioMixer.FindMatchingGroups(System.String);
			_result.Values = _audioMixer.Value.FindMatchingGroups(_subPath.Value);
		}
		
		public override string GetSummary()
		{
			return "Find Matching Groups {_audioMixer} {_subPath} -> {_result}";
		}
	}
}
