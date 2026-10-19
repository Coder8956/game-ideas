
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.SimulationMode))]
	public sealed partial class SimulationModeVariable : Variable<UnityEngine.SimulationMode>
	{
		
		public SimulationModeVariable()
		{
		}
		
		public SimulationModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SimulationMode))]
	public sealed partial class SimulationModeListVariable : ListVariable<UnityEngine.SimulationMode>
	{
		
		public SimulationModeListVariable()
		{
		}
		
		public SimulationModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SimulationMode))]
	public sealed partial class SimulationModeRef : VariableRef<UnityEngine.SimulationMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SimulationMode))]
	public sealed partial class SimulationModeVar : VariableVar<UnityEngine.SimulationMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SimulationMode))]
	public sealed partial class SimulationModeListRef : ListVariableRef<UnityEngine.SimulationMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SimulationMode))]
	public sealed partial class SimulationModeListVar : ListVariableVar<UnityEngine.SimulationMode>
	{
	}
}
