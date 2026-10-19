
using System;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.MoveDirection))]
	public sealed partial class MoveDirectionVariable : Variable<UnityEngine.EventSystems.MoveDirection>
	{
		
		public MoveDirectionVariable()
		{
		}
		
		public MoveDirectionVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.MoveDirection))]
	public sealed partial class MoveDirectionListVariable : ListVariable<UnityEngine.EventSystems.MoveDirection>
	{
		
		public MoveDirectionListVariable()
		{
		}
		
		public MoveDirectionListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.MoveDirection))]
	public sealed partial class MoveDirectionRef : VariableRef<UnityEngine.EventSystems.MoveDirection>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.MoveDirection))]
	public sealed partial class MoveDirectionVar : VariableVar<UnityEngine.EventSystems.MoveDirection>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.MoveDirection))]
	public sealed partial class MoveDirectionListRef : ListVariableRef<UnityEngine.EventSystems.MoveDirection>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.MoveDirection))]
	public sealed partial class MoveDirectionListVar : ListVariableVar<UnityEngine.EventSystems.MoveDirection>
	{
	}
}
