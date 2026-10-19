
using System;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.TrailRenderer))]
	public sealed partial class TrailRendererVariable : Variable<TrailRenderer>
	{
		
		public TrailRendererVariable()
		{
		}
		
		public TrailRendererVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TrailRenderer))]
	public sealed partial class TrailRendererListVariable : ListVariable<TrailRenderer>
	{
		
		public TrailRendererListVariable()
		{
		}
		
		public TrailRendererListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TrailRenderer))]
	public sealed partial class TrailRendererRef : BaseComponentRef<TrailRenderer>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TrailRenderer))]
	public sealed partial class TrailRendererVar : BaseComponentVar<TrailRenderer>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TrailRenderer))]
	public sealed partial class TrailRendererListRef : ListVariableRef<TrailRenderer>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TrailRenderer))]
	public sealed partial class TrailRendererListVar : ListVariableVar<TrailRenderer>
	{
	}
}
