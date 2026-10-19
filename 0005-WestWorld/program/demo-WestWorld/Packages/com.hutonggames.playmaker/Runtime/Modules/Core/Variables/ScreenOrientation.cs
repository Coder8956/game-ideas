
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ScreenOrientation))]
	public sealed partial class ScreenOrientationVariable : Variable<UnityEngine.ScreenOrientation>
	{
		
		public ScreenOrientationVariable()
		{
		}
		
		public ScreenOrientationVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ScreenOrientation))]
	public sealed partial class ScreenOrientationListVariable : ListVariable<UnityEngine.ScreenOrientation>
	{
		
		public ScreenOrientationListVariable()
		{
		}
		
		public ScreenOrientationListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ScreenOrientation))]
	public sealed partial class ScreenOrientationRef : VariableRef<UnityEngine.ScreenOrientation>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ScreenOrientation))]
	public sealed partial class ScreenOrientationVar : VariableVar<UnityEngine.ScreenOrientation>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ScreenOrientation))]
	public sealed partial class ScreenOrientationListRef : ListVariableRef<UnityEngine.ScreenOrientation>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ScreenOrientation))]
	public sealed partial class ScreenOrientationListVar : ListVariableVar<UnityEngine.ScreenOrientation>
	{
	}
}
