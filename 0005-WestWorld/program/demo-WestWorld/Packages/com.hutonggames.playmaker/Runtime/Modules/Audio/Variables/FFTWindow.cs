
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.FFTWindow))]
	public sealed partial class FFTWindowVariable : Variable<UnityEngine.FFTWindow>
	{
		
		public FFTWindowVariable()
		{
		}
		
		public FFTWindowVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FFTWindow))]
	public sealed partial class FFTWindowListVariable : ListVariable<UnityEngine.FFTWindow>
	{
		
		public FFTWindowListVariable()
		{
		}
		
		public FFTWindowListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FFTWindow))]
	public sealed partial class FFTWindowRef : VariableRef<UnityEngine.FFTWindow>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FFTWindow))]
	public sealed partial class FFTWindowVar : VariableVar<UnityEngine.FFTWindow>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FFTWindow))]
	public sealed partial class FFTWindowListRef : ListVariableRef<UnityEngine.FFTWindow>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FFTWindow))]
	public sealed partial class FFTWindowListVar : ListVariableVar<UnityEngine.FFTWindow>
	{
	}
}
