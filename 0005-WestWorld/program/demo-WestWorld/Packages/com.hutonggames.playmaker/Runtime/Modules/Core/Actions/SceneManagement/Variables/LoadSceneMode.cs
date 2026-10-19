
using System;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.SceneManagement.LoadSceneMode))]
	public sealed partial class LoadSceneModeVariable : Variable<UnityEngine.SceneManagement.LoadSceneMode>
	{
		
		public LoadSceneModeVariable()
		{
		}
		
		public LoadSceneModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SceneManagement.LoadSceneMode))]
	public sealed partial class LoadSceneModeListVariable : ListVariable<UnityEngine.SceneManagement.LoadSceneMode>
	{
		
		public LoadSceneModeListVariable()
		{
		}
		
		public LoadSceneModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SceneManagement.LoadSceneMode))]
	public sealed partial class LoadSceneModeRef : VariableRef<UnityEngine.SceneManagement.LoadSceneMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SceneManagement.LoadSceneMode))]
	public sealed partial class LoadSceneModeVar : VariableVar<UnityEngine.SceneManagement.LoadSceneMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SceneManagement.LoadSceneMode))]
	public sealed partial class LoadSceneModeListRef : ListVariableRef<UnityEngine.SceneManagement.LoadSceneMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SceneManagement.LoadSceneMode))]
	public sealed partial class LoadSceneModeListVar : ListVariableVar<UnityEngine.SceneManagement.LoadSceneMode>
	{
	}
}
