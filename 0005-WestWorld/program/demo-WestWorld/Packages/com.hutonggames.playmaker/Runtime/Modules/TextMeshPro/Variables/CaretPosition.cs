
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.CaretPosition))]
	public sealed partial class CaretPositionVariable : Variable<TMPro.CaretPosition>
	{
		
		public CaretPositionVariable()
		{
		}
		
		public CaretPositionVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.CaretPosition))]
	public sealed partial class CaretPositionListVariable : ListVariable<TMPro.CaretPosition>
	{
		
		public CaretPositionListVariable()
		{
		}
		
		public CaretPositionListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.CaretPosition))]
	public sealed partial class CaretPositionRef : VariableRef<TMPro.CaretPosition>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.CaretPosition))]
	public sealed partial class CaretPositionVar : VariableVar<TMPro.CaretPosition>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.CaretPosition))]
	public sealed partial class CaretPositionListRef : ListVariableRef<TMPro.CaretPosition>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.CaretPosition))]
	public sealed partial class CaretPositionListVar : ListVariableVar<TMPro.CaretPosition>
	{
	}
}
