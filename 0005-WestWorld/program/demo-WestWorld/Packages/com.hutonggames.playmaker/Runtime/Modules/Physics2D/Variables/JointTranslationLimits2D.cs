
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointTranslationLimits2D))]
	public sealed partial class JointTranslationLimits2DVariable : Variable<UnityEngine.JointTranslationLimits2D>
	{
		
		public JointTranslationLimits2DVariable()
		{
		}
		
		public JointTranslationLimits2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointTranslationLimits2D))]
	public sealed partial class JointTranslationLimits2DListVariable : ListVariable<UnityEngine.JointTranslationLimits2D>
	{
		
		public JointTranslationLimits2DListVariable()
		{
		}
		
		public JointTranslationLimits2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointTranslationLimits2D))]
	public sealed partial class JointTranslationLimits2DRef : VariableRef<UnityEngine.JointTranslationLimits2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointTranslationLimits2D))]
	public sealed partial class JointTranslationLimits2DVar : VariableVar<UnityEngine.JointTranslationLimits2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointTranslationLimits2D))]
	public sealed partial class JointTranslationLimits2DListRef : ListVariableRef<UnityEngine.JointTranslationLimits2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointTranslationLimits2D))]
	public sealed partial class JointTranslationLimits2DListVar : ListVariableVar<UnityEngine.JointTranslationLimits2D>
	{
	}
}
