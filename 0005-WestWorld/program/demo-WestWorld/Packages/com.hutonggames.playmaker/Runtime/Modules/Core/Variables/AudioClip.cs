
using System;
using System.Collections.Generic;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioClip))]
	public sealed partial class AudioClipVariable : Variable<AudioClip>
	{
		
		public AudioClipVariable()
		{
		}
		
		public AudioClipVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioClip))]
	public sealed partial class AudioClipListVariable : ListVariable<AudioClip>
	{
		
		public AudioClipListVariable()
		{
		}
		
		public AudioClipListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioClip))]
	public sealed partial class AudioClipRef : VariableRef<AudioClip>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioClip))]
	public sealed partial class AudioClipVar : VariableVar<AudioClip>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioClip))]
	public sealed partial class AudioClipListRef : ListVariableRef<AudioClip>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioClip))]
	public sealed partial class AudioClipListVar : ListVariableVar<AudioClip>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioClip))]
	public sealed partial class AudioClipOverride : VariableOverride<AudioClip,AudioClipVariable,AudioClipVar>
	{
		
		public AudioClipOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioClip))]
	public sealed partial class AudioClipOutput : VariableOutput<AudioClip,AudioClipVariable,AudioClipRef>
	{
		
		public AudioClipOutput(IVariable variable) : 
				base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.AudioClip))]
	public sealed partial class
		AudioClipListOverride : VariableOverride<List<AudioClip>, AudioClipListVariable, AudioClipListVar>
	{
		public AudioClipListOverride(IVariable variable) :
			base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.AudioClip))]
	public sealed partial class
		AudioClipListOutput : VariableOutput<List<AudioClip>, AudioClipListVariable, AudioClipListRef>
	{
		public AudioClipListOutput(IVariable variable) :
			base(variable)
		{
		}
	}
}
