
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemShapeType))]
	public sealed partial class ParticleSystemShapeTypeVariable : Variable<UnityEngine.ParticleSystemShapeType>
	{
		
		public ParticleSystemShapeTypeVariable()
		{
		}
		
		public ParticleSystemShapeTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemShapeType))]
	public sealed partial class ParticleSystemShapeTypeListVariable : ListVariable<UnityEngine.ParticleSystemShapeType>
	{
		
		public ParticleSystemShapeTypeListVariable()
		{
		}
		
		public ParticleSystemShapeTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemShapeType))]
	public sealed partial class ParticleSystemShapeTypeRef : VariableRef<UnityEngine.ParticleSystemShapeType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemShapeType))]
	public sealed partial class ParticleSystemShapeTypeVar : VariableVar<UnityEngine.ParticleSystemShapeType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemShapeType))]
	public sealed partial class ParticleSystemShapeTypeListRef : ListVariableRef<UnityEngine.ParticleSystemShapeType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemShapeType))]
	public sealed partial class ParticleSystemShapeTypeListVar : ListVariableVar<UnityEngine.ParticleSystemShapeType>
	{
	}
}
