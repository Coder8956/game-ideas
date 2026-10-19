
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.MotionVectorGenerationMode))]
	public sealed partial class MotionVectorGenerationModeVariable : Variable<UnityEngine.MotionVectorGenerationMode>
	{
		
		public MotionVectorGenerationModeVariable()
		{
		}
		
		public MotionVectorGenerationModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.MotionVectorGenerationMode))]
	public sealed partial class MotionVectorGenerationModeListVariable : ListVariable<UnityEngine.MotionVectorGenerationMode>
	{
		
		public MotionVectorGenerationModeListVariable()
		{
		}
		
		public MotionVectorGenerationModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.MotionVectorGenerationMode))]
	public sealed partial class MotionVectorGenerationModeRef : VariableRef<UnityEngine.MotionVectorGenerationMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.MotionVectorGenerationMode))]
	public sealed partial class MotionVectorGenerationModeVar : VariableVar<UnityEngine.MotionVectorGenerationMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.MotionVectorGenerationMode))]
	public sealed partial class MotionVectorGenerationModeListRef : ListVariableRef<UnityEngine.MotionVectorGenerationMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.MotionVectorGenerationMode))]
	public sealed partial class MotionVectorGenerationModeListVar : ListVariableVar<UnityEngine.MotionVectorGenerationMode>
	{
	}
}
