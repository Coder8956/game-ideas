
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.CaretInfo))]
	public sealed partial class CaretInfoVariable : Variable<TMPro.CaretInfo>
	{
		
		public CaretInfoVariable()
		{
		}
		
		public CaretInfoVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.CaretInfo))]
	public sealed partial class CaretInfoListVariable : ListVariable<TMPro.CaretInfo>
	{
		
		public CaretInfoListVariable()
		{
		}
		
		public CaretInfoListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.CaretInfo))]
	public sealed partial class CaretInfoRef : VariableRef<TMPro.CaretInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.CaretInfo))]
	public sealed partial class CaretInfoVar : VariableVar<TMPro.CaretInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.CaretInfo))]
	public sealed partial class CaretInfoListRef : ListVariableRef<TMPro.CaretInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.CaretInfo))]
	public sealed partial class CaretInfoListVar : ListVariableVar<TMPro.CaretInfo>
	{
	}
}
