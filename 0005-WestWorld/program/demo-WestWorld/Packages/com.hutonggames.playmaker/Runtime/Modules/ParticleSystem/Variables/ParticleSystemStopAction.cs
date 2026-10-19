
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemStopAction))]
	public sealed partial class ParticleSystemStopActionVariable : Variable<UnityEngine.ParticleSystemStopAction>
	{
		
		public ParticleSystemStopActionVariable()
		{
		}
		
		public ParticleSystemStopActionVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemStopAction))]
	public sealed partial class ParticleSystemStopActionListVariable : ListVariable<UnityEngine.ParticleSystemStopAction>
	{
		
		public ParticleSystemStopActionListVariable()
		{
		}
		
		public ParticleSystemStopActionListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemStopAction))]
	public sealed partial class ParticleSystemStopActionRef : VariableRef<UnityEngine.ParticleSystemStopAction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemStopAction))]
	public sealed partial class ParticleSystemStopActionVar : VariableVar<UnityEngine.ParticleSystemStopAction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemStopAction))]
	public sealed partial class ParticleSystemStopActionListRef : ListVariableRef<UnityEngine.ParticleSystemStopAction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemStopAction))]
	public sealed partial class ParticleSystemStopActionListVar : ListVariableVar<UnityEngine.ParticleSystemStopAction>
	{
	}
}
