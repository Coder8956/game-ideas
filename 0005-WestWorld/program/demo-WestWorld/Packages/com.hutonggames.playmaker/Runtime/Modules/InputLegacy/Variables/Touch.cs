
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Touch))]
	public sealed partial class TouchVariable : Variable<UnityEngine.Touch>
	{
		
		public TouchVariable()
		{
		}
		
		public TouchVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Touch))]
	public sealed partial class TouchListVariable : ListVariable<UnityEngine.Touch>
	{
		
		public TouchListVariable()
		{
		}
		
		public TouchListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Touch))]
	public sealed partial class TouchRef : VariableRef<UnityEngine.Touch>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Touch))]
	public sealed partial class TouchVar : VariableVar<UnityEngine.Touch>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Touch))]
	public sealed partial class TouchListRef : ListVariableRef<UnityEngine.Touch>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Touch))]
	public sealed partial class TouchListVar : ListVariableVar<UnityEngine.Touch>
	{
	}
}
