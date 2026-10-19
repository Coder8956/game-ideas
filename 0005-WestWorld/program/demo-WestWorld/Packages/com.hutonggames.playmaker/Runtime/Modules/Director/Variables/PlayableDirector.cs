
using System;
using UnityEngine.Playables;


namespace HutongGames.PlayMaker.Actions.Playables
{
	
	
	[Serializable]
	[DataType(typeof(PlayableDirector))]
	public sealed partial class PlayableDirectorVariable : Variable<PlayableDirector>
	{
		
		public PlayableDirectorVariable()
		{
		}
		
		public PlayableDirectorVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(PlayableDirector))]
	public sealed partial class PlayableDirectorListVariable : ListVariable<PlayableDirector>
	{
		
		public PlayableDirectorListVariable()
		{
		}
		
		public PlayableDirectorListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(PlayableDirector))]
	public sealed partial class PlayableDirectorRef : VariableRef<PlayableDirector>
	{
	}
	
	[Serializable]
	[DataType(typeof(PlayableDirector))]
	public sealed partial class PlayableDirectorVar : VariableVar<PlayableDirector>
	{
	}
	
	[Serializable]
	[DataType(typeof(PlayableDirector))]
	public sealed partial class PlayableDirectorListRef : ListVariableRef<PlayableDirector>
	{
	}
	
	[Serializable]
	[DataType(typeof(PlayableDirector))]
	public sealed partial class PlayableDirectorListVar : ListVariableVar<PlayableDirector>
	{
	}
	
	[Serializable]
	[DataType(typeof(PlayableDirector))]
	public sealed partial class PlayableDirectorOverride : VariableOverride<PlayableDirector,PlayableDirectorVariable,PlayableDirectorVar>
	{
		
		public PlayableDirectorOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(PlayableDirector))]
	public sealed partial class PlayableDirectorOutput : VariableOutput<PlayableDirector,PlayableDirectorVariable,PlayableDirectorRef>
	{
		
		public PlayableDirectorOutput(IVariable variable) : 
				base(variable)
		{
		}
	}
}
