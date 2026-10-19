
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemOverlapAction))]
	public sealed partial class ParticleSystemOverlapActionVariable : Variable<UnityEngine.ParticleSystemOverlapAction>
	{
		
		public ParticleSystemOverlapActionVariable()
		{
		}
		
		public ParticleSystemOverlapActionVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemOverlapAction))]
	public sealed partial class ParticleSystemOverlapActionListVariable : ListVariable<UnityEngine.ParticleSystemOverlapAction>
	{
		
		public ParticleSystemOverlapActionListVariable()
		{
		}
		
		public ParticleSystemOverlapActionListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemOverlapAction))]
	public sealed partial class ParticleSystemOverlapActionRef : VariableRef<UnityEngine.ParticleSystemOverlapAction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemOverlapAction))]
	public sealed partial class ParticleSystemOverlapActionVar : VariableVar<UnityEngine.ParticleSystemOverlapAction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemOverlapAction))]
	public sealed partial class ParticleSystemOverlapActionListRef : ListVariableRef<UnityEngine.ParticleSystemOverlapAction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemOverlapAction))]
	public sealed partial class ParticleSystemOverlapActionListVar : ListVariableVar<UnityEngine.ParticleSystemOverlapAction>
	{
	}
}
