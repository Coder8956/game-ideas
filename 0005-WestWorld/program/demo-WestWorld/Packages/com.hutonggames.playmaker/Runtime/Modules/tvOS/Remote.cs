
using System;


namespace HutongGames.PlayMaker.Actions.tvOS
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.tvOS.Remote))]
	public sealed partial class RemoteVariable : Variable<UnityEngine.tvOS.Remote>
	{
		
		public RemoteVariable()
		{
		}
		
		public RemoteVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.tvOS.Remote))]
	public sealed partial class RemoteListVariable : ListVariable<UnityEngine.tvOS.Remote>
	{
		
		public RemoteListVariable()
		{
		}
		
		public RemoteListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.tvOS.Remote))]
	public sealed partial class RemoteRef : VariableRef<UnityEngine.tvOS.Remote>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.tvOS.Remote))]
	public sealed partial class RemoteVar : VariableVar<UnityEngine.tvOS.Remote>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.tvOS.Remote))]
	public sealed partial class RemoteListRef : ListVariableRef<UnityEngine.tvOS.Remote>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.tvOS.Remote))]
	public sealed partial class RemoteListVar : ListVariableVar<UnityEngine.tvOS.Remote>
	{
	}
}
