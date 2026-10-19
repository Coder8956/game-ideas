
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Resolution))]
	public sealed partial class ResolutionVariable : Variable<UnityEngine.Resolution>
	{
		
		public ResolutionVariable()
		{
		}
		
		public ResolutionVariable(string name) : 
				base(name)
		{
		}

		public override string DebugValue()
		{
			return "!!#@";
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Resolution))]
	public sealed partial class ResolutionListVariable : ListVariable<UnityEngine.Resolution>
	{
		
		public ResolutionListVariable()
		{
		}
		
		public ResolutionListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Resolution))]
	public sealed partial class ResolutionRef : VariableRef<UnityEngine.Resolution>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Resolution))]
	public sealed partial class ResolutionVar : VariableVar<UnityEngine.Resolution>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Resolution))]
	public sealed partial class ResolutionListRef : ListVariableRef<UnityEngine.Resolution>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Resolution))]
	public sealed partial class ResolutionListVar : ListVariableVar<UnityEngine.Resolution>
	{
	}
}
