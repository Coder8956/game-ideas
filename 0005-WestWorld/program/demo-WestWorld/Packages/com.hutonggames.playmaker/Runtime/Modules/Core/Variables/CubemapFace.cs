
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.CubemapFace))]
	public sealed partial class CubemapFaceVariable : Variable<UnityEngine.CubemapFace>
	{
		
		public CubemapFaceVariable()
		{
		}
		
		public CubemapFaceVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CubemapFace))]
	public sealed partial class CubemapFaceListVariable : ListVariable<UnityEngine.CubemapFace>
	{
		
		public CubemapFaceListVariable()
		{
		}
		
		public CubemapFaceListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CubemapFace))]
	public sealed partial class CubemapFaceRef : VariableRef<UnityEngine.CubemapFace>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CubemapFace))]
	public sealed partial class CubemapFaceVar : VariableVar<UnityEngine.CubemapFace>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CubemapFace))]
	public sealed partial class CubemapFaceListRef : ListVariableRef<UnityEngine.CubemapFace>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CubemapFace))]
	public sealed partial class CubemapFaceListVar : ListVariableVar<UnityEngine.CubemapFace>
	{
	}
}
