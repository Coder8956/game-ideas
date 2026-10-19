
using System;
using UnityEngine.SceneManagement;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.SceneManagement.Scene))]
	public sealed partial class SceneVariable : Variable<Scene>
	{
		
		public SceneVariable()
		{
		}
		
		public SceneVariable(string name) : 
				base(name)
		{
		}

		public override string DebugValue()
		{
			return string.IsNullOrEmpty(Value.name) ? "None" : Value.name;
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SceneManagement.Scene))]
	public sealed partial class SceneListVariable : ListVariable<Scene>
	{
		
		public SceneListVariable()
		{
		}
		
		public SceneListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SceneManagement.Scene))]
	public sealed partial class SceneRef : VariableRef<Scene>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SceneManagement.Scene))]
	public sealed partial class SceneVar : VariableVar<Scene>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SceneManagement.Scene))]
	public sealed partial class SceneListRef : ListVariableRef<Scene>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SceneManagement.Scene))]
	public sealed partial class SceneListVar : ListVariableVar<Scene>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SceneManagement.Scene))]
	public sealed partial class SceneOverride : VariableOverride<Scene,SceneVariable,SceneVar>
	{
		
		public SceneOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SceneManagement.Scene))]
	public sealed partial class SceneOutput : VariableOutput<Scene,SceneVariable,SceneRef>
	{
		
		public SceneOutput(IVariable variable) : 
				base(variable)
		{
		}
	}
}
