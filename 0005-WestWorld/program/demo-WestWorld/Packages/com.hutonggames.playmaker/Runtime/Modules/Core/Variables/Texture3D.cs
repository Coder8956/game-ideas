
using System;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Texture3D))]
	public sealed partial class Texture3DVariable : Variable<Texture3D>
	{
		
		public Texture3DVariable()
		{
		}
		
		public Texture3DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Texture3D))]
	public sealed partial class Texture3DListVariable : ListVariable<Texture3D>
	{
		
		public Texture3DListVariable()
		{
		}
		
		public Texture3DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Texture3D))]
	public sealed partial class Texture3DRef : VariableRef<Texture3D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Texture3D))]
	public sealed partial class Texture3DVar : VariableVar<Texture3D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Texture3D))]
	public sealed partial class Texture3DListRef : ListVariableRef<Texture3D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Texture3D))]
	public sealed partial class Texture3DListVar : ListVariableVar<Texture3D>
	{
	}
}
