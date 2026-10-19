
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemForceFieldShape))]
	public sealed partial class ParticleSystemForceFieldShapeVariable : Variable<UnityEngine.ParticleSystemForceFieldShape>
	{
		
		public ParticleSystemForceFieldShapeVariable()
		{
		}
		
		public ParticleSystemForceFieldShapeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemForceFieldShape))]
	public sealed partial class ParticleSystemForceFieldShapeListVariable : ListVariable<UnityEngine.ParticleSystemForceFieldShape>
	{
		
		public ParticleSystemForceFieldShapeListVariable()
		{
		}
		
		public ParticleSystemForceFieldShapeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemForceFieldShape))]
	public sealed partial class ParticleSystemForceFieldShapeRef : VariableRef<UnityEngine.ParticleSystemForceFieldShape>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemForceFieldShape))]
	public sealed partial class ParticleSystemForceFieldShapeVar : VariableVar<UnityEngine.ParticleSystemForceFieldShape>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemForceFieldShape))]
	public sealed partial class ParticleSystemForceFieldShapeListRef : ListVariableRef<UnityEngine.ParticleSystemForceFieldShape>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemForceFieldShape))]
	public sealed partial class ParticleSystemForceFieldShapeListVar : ListVariableVar<UnityEngine.ParticleSystemForceFieldShape>
	{
	}
}
