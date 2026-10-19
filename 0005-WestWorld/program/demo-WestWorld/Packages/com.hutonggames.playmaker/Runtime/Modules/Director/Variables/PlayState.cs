
using System;


namespace HutongGames.PlayMaker.Actions.Playables
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.PlayState))]
	public sealed partial class PlayStateVariable : Variable<UnityEngine.Playables.PlayState>
	{
		
		public PlayStateVariable()
		{
		}
		
		public PlayStateVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.PlayState))]
	public sealed partial class PlayStateListVariable : ListVariable<UnityEngine.Playables.PlayState>
	{
		
		public PlayStateListVariable()
		{
		}
		
		public PlayStateListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.PlayState))]
	public sealed partial class PlayStateRef : VariableRef<UnityEngine.Playables.PlayState>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.PlayState))]
	public sealed partial class PlayStateVar : VariableVar<UnityEngine.Playables.PlayState>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.PlayState))]
	public sealed partial class PlayStateListRef : ListVariableRef<UnityEngine.Playables.PlayState>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.PlayState))]
	public sealed partial class PlayStateListVar : ListVariableVar<UnityEngine.Playables.PlayState>
	{
	}
}
