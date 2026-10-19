
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightType))]
	public sealed partial class LightTypeVariable : Variable<UnityEngine.LightType>
	{
		
		public LightTypeVariable()
		{
		}
		
		public LightTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightType))]
	public sealed partial class LightTypeListVariable : ListVariable<UnityEngine.LightType>
	{
		
		public LightTypeListVariable()
		{
		}
		
		public LightTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightType))]
	public sealed partial class LightTypeRef : VariableRef<UnityEngine.LightType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightType))]
	public sealed partial class LightTypeVar : VariableVar<UnityEngine.LightType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightType))]
	public sealed partial class LightTypeListRef : ListVariableRef<UnityEngine.LightType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightType))]
	public sealed partial class LightTypeListVar : ListVariableVar<UnityEngine.LightType>
	{
	}
}
