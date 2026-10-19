
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Cubemap))]
	public sealed partial class CubemapVariable : Variable<UnityEngine.Cubemap>
	{
		
		public CubemapVariable()
		{
		}
		
		public CubemapVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Cubemap))]
	public sealed partial class CubemapListVariable : ListVariable<UnityEngine.Cubemap>
	{
		
		public CubemapListVariable()
		{
		}
		
		public CubemapListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Cubemap))]
	public sealed partial class CubemapRef : VariableRef<UnityEngine.Cubemap>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Cubemap))]
	public sealed partial class CubemapVar : VariableVar<UnityEngine.Cubemap>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Cubemap))]
	public sealed partial class CubemapListRef : ListVariableRef<UnityEngine.Cubemap>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Cubemap))]
	public sealed partial class CubemapListVar : ListVariableVar<UnityEngine.Cubemap>
	{
	}
}
