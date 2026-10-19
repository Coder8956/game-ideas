
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Mask))]
	public sealed partial class MaskVariable : Variable<UnityEngine.UI.Mask>
	{
		
		public MaskVariable()
		{
		}
		
		public MaskVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Mask))]
	public sealed partial class MaskListVariable : ListVariable<UnityEngine.UI.Mask>
	{
		
		public MaskListVariable()
		{
		}
		
		public MaskListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Mask))]
	public sealed partial class MaskRef : BaseComponentRef<UnityEngine.UI.Mask>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Mask))]
	public sealed partial class MaskVar : BaseComponentVar<UnityEngine.UI.Mask>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Mask))]
	public sealed partial class MaskListRef : ListVariableRef<UnityEngine.UI.Mask>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Mask))]
	public sealed partial class MaskListVar : ListVariableVar<UnityEngine.UI.Mask>
	{
	}
}
