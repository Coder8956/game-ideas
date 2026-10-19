
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemVertexStream))]
	public sealed partial class ParticleSystemVertexStreamVariable : Variable<UnityEngine.ParticleSystemVertexStream>
	{
		
		public ParticleSystemVertexStreamVariable()
		{
		}
		
		public ParticleSystemVertexStreamVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemVertexStream))]
	public sealed partial class ParticleSystemVertexStreamListVariable : ListVariable<UnityEngine.ParticleSystemVertexStream>
	{
		
		public ParticleSystemVertexStreamListVariable()
		{
		}
		
		public ParticleSystemVertexStreamListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemVertexStream))]
	public sealed partial class ParticleSystemVertexStreamRef : VariableRef<UnityEngine.ParticleSystemVertexStream>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemVertexStream))]
	public sealed partial class ParticleSystemVertexStreamVar : VariableVar<UnityEngine.ParticleSystemVertexStream>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemVertexStream))]
	public sealed partial class ParticleSystemVertexStreamListRef : ListVariableRef<UnityEngine.ParticleSystemVertexStream>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemVertexStream))]
	public sealed partial class ParticleSystemVertexStreamListVar : ListVariableVar<UnityEngine.ParticleSystemVertexStream>
	{
	}
}
