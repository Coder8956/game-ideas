
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Shadow))]
	public sealed partial class ShadowVariable : Variable<UnityEngine.UI.Shadow>
	{
		
		public ShadowVariable()
		{
		}
		
		public ShadowVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Shadow))]
	public sealed partial class ShadowListVariable : ListVariable<UnityEngine.UI.Shadow>
	{
		
		public ShadowListVariable()
		{
		}
		
		public ShadowListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Shadow))]
	public sealed partial class ShadowRef : BaseComponentRef<UnityEngine.UI.Shadow>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Shadow))]
	public sealed partial class ShadowVar : BaseComponentVar<UnityEngine.UI.Shadow>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Shadow))]
	public sealed partial class ShadowListRef : ListVariableRef<UnityEngine.UI.Shadow>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Shadow))]
	public sealed partial class ShadowListVar : ListVariableVar<UnityEngine.UI.Shadow>
	{
	}
}
