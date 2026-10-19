
using System;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.RaycastResult))]
	public sealed partial class RaycastResultVariable : Variable<UnityEngine.EventSystems.RaycastResult>
	{
		
		public RaycastResultVariable()
		{
		}
		
		public RaycastResultVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.RaycastResult))]
	public sealed partial class RaycastResultListVariable : ListVariable<UnityEngine.EventSystems.RaycastResult>
	{
		
		public RaycastResultListVariable()
		{
		}
		
		public RaycastResultListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.RaycastResult))]
	public sealed partial class RaycastResultRef : VariableRef<UnityEngine.EventSystems.RaycastResult>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.RaycastResult))]
	public sealed partial class RaycastResultVar : VariableVar<UnityEngine.EventSystems.RaycastResult>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.RaycastResult))]
	public sealed partial class RaycastResultListRef : ListVariableRef<UnityEngine.EventSystems.RaycastResult>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EventSystems.RaycastResult))]
	public sealed partial class RaycastResultListVar : ListVariableVar<UnityEngine.EventSystems.RaycastResult>
	{
	}
}
