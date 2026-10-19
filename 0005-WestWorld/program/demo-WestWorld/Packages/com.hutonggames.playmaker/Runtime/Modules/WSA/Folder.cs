
using System;


namespace HutongGames.PlayMaker.Actions.WSA
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.Folder))]
	public sealed partial class FolderVariable : Variable<UnityEngine.WSA.Folder>
	{
		
		public FolderVariable()
		{
		}
		
		public FolderVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.Folder))]
	public sealed partial class FolderListVariable : ListVariable<UnityEngine.WSA.Folder>
	{
		
		public FolderListVariable()
		{
		}
		
		public FolderListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.Folder))]
	public sealed partial class FolderRef : VariableRef<UnityEngine.WSA.Folder>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.Folder))]
	public sealed partial class FolderVar : VariableVar<UnityEngine.WSA.Folder>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.Folder))]
	public sealed partial class FolderListRef : ListVariableRef<UnityEngine.WSA.Folder>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.Folder))]
	public sealed partial class FolderListVar : ListVariableVar<UnityEngine.WSA.Folder>
	{
	}
}
