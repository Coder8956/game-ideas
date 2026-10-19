
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemForceField))]
	public sealed partial class ParticleSystemForceFieldVariable : Variable<UnityEngine.ParticleSystemForceField>
	{
		
		public ParticleSystemForceFieldVariable()
		{
		}
		
		public ParticleSystemForceFieldVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemForceField))]
	public sealed partial class ParticleSystemForceFieldListVariable : ListVariable<UnityEngine.ParticleSystemForceField>
	{
		
		public ParticleSystemForceFieldListVariable()
		{
		}
		
		public ParticleSystemForceFieldListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemForceField))]
	public sealed partial class ParticleSystemForceFieldRef : BaseComponentRef<UnityEngine.ParticleSystemForceField>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemForceField))]
	public sealed partial class ParticleSystemForceFieldVar : BaseComponentVar<UnityEngine.ParticleSystemForceField>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemForceField))]
	public sealed partial class ParticleSystemForceFieldListRef : ListVariableRef<UnityEngine.ParticleSystemForceField>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemForceField))]
	public sealed partial class ParticleSystemForceFieldListVar : ListVariableVar<UnityEngine.ParticleSystemForceField>
	{
	}
}
