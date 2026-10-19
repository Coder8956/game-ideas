
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.SimulationMode2D))]
	public sealed partial class SimulationMode2DVariable : Variable<UnityEngine.SimulationMode2D>
	{
		
		public SimulationMode2DVariable()
		{
		}
		
		public SimulationMode2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SimulationMode2D))]
	public sealed partial class SimulationMode2DListVariable : ListVariable<UnityEngine.SimulationMode2D>
	{
		
		public SimulationMode2DListVariable()
		{
		}
		
		public SimulationMode2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SimulationMode2D))]
	public sealed partial class SimulationMode2DRef : VariableRef<UnityEngine.SimulationMode2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SimulationMode2D))]
	public sealed partial class SimulationMode2DVar : VariableVar<UnityEngine.SimulationMode2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SimulationMode2D))]
	public sealed partial class SimulationMode2DListRef : ListVariableRef<UnityEngine.SimulationMode2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SimulationMode2D))]
	public sealed partial class SimulationMode2DListVar : ListVariableVar<UnityEngine.SimulationMode2D>
	{
	}
}
