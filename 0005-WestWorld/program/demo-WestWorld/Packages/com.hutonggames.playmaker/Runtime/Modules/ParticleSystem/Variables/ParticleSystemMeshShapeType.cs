
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemMeshShapeType))]
	public sealed partial class ParticleSystemMeshShapeTypeVariable : Variable<UnityEngine.ParticleSystemMeshShapeType>
	{
		
		public ParticleSystemMeshShapeTypeVariable()
		{
		}
		
		public ParticleSystemMeshShapeTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemMeshShapeType))]
	public sealed partial class ParticleSystemMeshShapeTypeListVariable : ListVariable<UnityEngine.ParticleSystemMeshShapeType>
	{
		
		public ParticleSystemMeshShapeTypeListVariable()
		{
		}
		
		public ParticleSystemMeshShapeTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemMeshShapeType))]
	public sealed partial class ParticleSystemMeshShapeTypeRef : VariableRef<UnityEngine.ParticleSystemMeshShapeType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemMeshShapeType))]
	public sealed partial class ParticleSystemMeshShapeTypeVar : VariableVar<UnityEngine.ParticleSystemMeshShapeType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemMeshShapeType))]
	public sealed partial class ParticleSystemMeshShapeTypeListRef : ListVariableRef<UnityEngine.ParticleSystemMeshShapeType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemMeshShapeType))]
	public sealed partial class ParticleSystemMeshShapeTypeListVar : ListVariableVar<UnityEngine.ParticleSystemMeshShapeType>
	{
	}
}
