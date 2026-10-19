
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ColorSpace))]
	public sealed partial class ColorSpaceVariable : Variable<UnityEngine.ColorSpace>
	{
		
		public ColorSpaceVariable()
		{
		}
		
		public ColorSpaceVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ColorSpace))]
	public sealed partial class ColorSpaceListVariable : ListVariable<UnityEngine.ColorSpace>
	{
		
		public ColorSpaceListVariable()
		{
		}
		
		public ColorSpaceListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ColorSpace))]
	public sealed partial class ColorSpaceRef : VariableRef<UnityEngine.ColorSpace>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ColorSpace))]
	public sealed partial class ColorSpaceVar : VariableVar<UnityEngine.ColorSpace>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ColorSpace))]
	public sealed partial class ColorSpaceListRef : ListVariableRef<UnityEngine.ColorSpace>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ColorSpace))]
	public sealed partial class ColorSpaceListVar : ListVariableVar<UnityEngine.ColorSpace>
	{
	}
}
