
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Flare))]
	public sealed partial class FlareVariable : Variable<UnityEngine.Flare>
	{
		
		public FlareVariable()
		{
		}
		
		public FlareVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Flare))]
	public sealed partial class FlareListVariable : ListVariable<UnityEngine.Flare>
	{
		
		public FlareListVariable()
		{
		}
		
		public FlareListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Flare))]
	public sealed partial class FlareRef : VariableRef<UnityEngine.Flare>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Flare))]
	public sealed partial class FlareVar : VariableVar<UnityEngine.Flare>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Flare))]
	public sealed partial class FlareListRef : ListVariableRef<UnityEngine.Flare>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Flare))]
	public sealed partial class FlareListVar : ListVariableVar<UnityEngine.Flare>
	{
	}
}
