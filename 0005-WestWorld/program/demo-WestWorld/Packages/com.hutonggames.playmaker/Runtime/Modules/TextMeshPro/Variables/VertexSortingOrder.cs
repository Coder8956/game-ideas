
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.VertexSortingOrder))]
	public sealed partial class VertexSortingOrderVariable : Variable<TMPro.VertexSortingOrder>
	{
		
		public VertexSortingOrderVariable()
		{
		}
		
		public VertexSortingOrderVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.VertexSortingOrder))]
	public sealed partial class VertexSortingOrderListVariable : ListVariable<TMPro.VertexSortingOrder>
	{
		
		public VertexSortingOrderListVariable()
		{
		}
		
		public VertexSortingOrderListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.VertexSortingOrder))]
	public sealed partial class VertexSortingOrderRef : VariableRef<TMPro.VertexSortingOrder>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.VertexSortingOrder))]
	public sealed partial class VertexSortingOrderVar : VariableVar<TMPro.VertexSortingOrder>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.VertexSortingOrder))]
	public sealed partial class VertexSortingOrderListRef : ListVariableRef<TMPro.VertexSortingOrder>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.VertexSortingOrder))]
	public sealed partial class VertexSortingOrderListVar : ListVariableVar<TMPro.VertexSortingOrder>
	{
	}
}
