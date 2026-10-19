
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image))]
	public sealed partial class ImageVariable : Variable<UnityEngine.UI.Image>
	{
		
		public ImageVariable()
		{
		}
		
		public ImageVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image))]
	public sealed partial class ImageListVariable : ListVariable<UnityEngine.UI.Image>
	{
		
		public ImageListVariable()
		{
		}
		
		public ImageListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image))]
	public sealed partial class ImageRef : BaseComponentRef<UnityEngine.UI.Image>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image))]
	public sealed partial class ImageVar : BaseComponentVar<UnityEngine.UI.Image>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image))]
	public sealed partial class ImageListRef : ListVariableRef<UnityEngine.UI.Image>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image))]
	public sealed partial class ImageListVar : ListVariableVar<UnityEngine.UI.Image>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image))]
	public sealed partial class ImageOverride : VariableOverride<UnityEngine.UI.Image, ImageVariable, ImageVar>
	{
		public ImageOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image))]
	public sealed partial class ImageOutput : VariableOutput<UnityEngine.UI.Image, ImageVariable, ImageRef>
	{
		public ImageOutput(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image))]
	public sealed partial class ImageListOverride : VariableOverride<System.Collections.Generic.List<UnityEngine.UI.Image>, ImageListVariable, ImageListVar>
	{
		public ImageListOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.UI.Image))]
	public sealed partial class ImageListOutput : VariableOutput<System.Collections.Generic.List<UnityEngine.UI.Image>, ImageListVariable, ImageListRef>
	{
		public ImageListOutput(IVariable variable) : base(variable)
		{
		}
	}
}
