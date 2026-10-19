
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightShadows))]
	public sealed partial class LightShadowsVariable : Variable<UnityEngine.LightShadows>
	{
		
		public LightShadowsVariable()
		{
		}
		
		public LightShadowsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightShadows))]
	public sealed partial class LightShadowsListVariable : ListVariable<UnityEngine.LightShadows>
	{
		
		public LightShadowsListVariable()
		{
		}
		
		public LightShadowsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightShadows))]
	public sealed partial class LightShadowsRef : VariableRef<UnityEngine.LightShadows>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightShadows))]
	public sealed partial class LightShadowsVar : VariableVar<UnityEngine.LightShadows>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightShadows))]
	public sealed partial class LightShadowsListRef : ListVariableRef<UnityEngine.LightShadows>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightShadows))]
	public sealed partial class LightShadowsListVar : ListVariableVar<UnityEngine.LightShadows>
	{
	}
}
