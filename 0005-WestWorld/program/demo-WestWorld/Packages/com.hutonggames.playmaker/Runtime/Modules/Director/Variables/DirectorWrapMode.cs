
using System;


namespace HutongGames.PlayMaker.Actions.Playables
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.DirectorWrapMode))]
	public sealed partial class DirectorWrapModeVariable : Variable<UnityEngine.Playables.DirectorWrapMode>
	{
		
		public DirectorWrapModeVariable()
		{
		}
		
		public DirectorWrapModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.DirectorWrapMode))]
	public sealed partial class DirectorWrapModeListVariable : ListVariable<UnityEngine.Playables.DirectorWrapMode>
	{
		
		public DirectorWrapModeListVariable()
		{
		}
		
		public DirectorWrapModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.DirectorWrapMode))]
	public sealed partial class DirectorWrapModeRef : VariableRef<UnityEngine.Playables.DirectorWrapMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.DirectorWrapMode))]
	public sealed partial class DirectorWrapModeVar : VariableVar<UnityEngine.Playables.DirectorWrapMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.DirectorWrapMode))]
	public sealed partial class DirectorWrapModeListRef : ListVariableRef<UnityEngine.Playables.DirectorWrapMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.DirectorWrapMode))]
	public sealed partial class DirectorWrapModeListVar : ListVariableVar<UnityEngine.Playables.DirectorWrapMode>
	{
	}
}
