
using System;


namespace HutongGames.PlayMaker.Actions.Playables
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.DirectorUpdateMode))]
	public sealed partial class DirectorUpdateModeVariable : Variable<UnityEngine.Playables.DirectorUpdateMode>
	{
		
		public DirectorUpdateModeVariable()
		{
		}
		
		public DirectorUpdateModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.DirectorUpdateMode))]
	public sealed partial class DirectorUpdateModeListVariable : ListVariable<UnityEngine.Playables.DirectorUpdateMode>
	{
		
		public DirectorUpdateModeListVariable()
		{
		}
		
		public DirectorUpdateModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.DirectorUpdateMode))]
	public sealed partial class DirectorUpdateModeRef : VariableRef<UnityEngine.Playables.DirectorUpdateMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.DirectorUpdateMode))]
	public sealed partial class DirectorUpdateModeVar : VariableVar<UnityEngine.Playables.DirectorUpdateMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.DirectorUpdateMode))]
	public sealed partial class DirectorUpdateModeListRef : ListVariableRef<UnityEngine.Playables.DirectorUpdateMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.DirectorUpdateMode))]
	public sealed partial class DirectorUpdateModeListVar : ListVariableVar<UnityEngine.Playables.DirectorUpdateMode>
	{
	}
}
