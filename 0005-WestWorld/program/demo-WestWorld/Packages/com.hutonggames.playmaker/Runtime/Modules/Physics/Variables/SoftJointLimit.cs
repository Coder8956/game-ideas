
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(SoftJointLimit))]
	public sealed partial class SoftJointLimitVariable : Variable<SoftJointLimit>
	{
		[SerializeField]
		private new float _value;
		
		public override SoftJointLimit Value
		{
			get => new() { limit = _value };
			set => _value = value.limit;
		}

		public SoftJointLimitVariable()
		{
		}
		
		public SoftJointLimitVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(SoftJointLimit))]
	public sealed partial class SoftJointLimitListVariable : ListVariable<SoftJointLimit>
	{
		
		public SoftJointLimitListVariable()
		{
		}
		
		public SoftJointLimitListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(SoftJointLimit))]
	public sealed partial class SoftJointLimitRef : VariableRef<SoftJointLimit>
	{
	}
	
	[Serializable]
	[DataType(typeof(SoftJointLimit))]
	public sealed partial class SoftJointLimitVar : VariableVar<SoftJointLimit>
	{
		[SerializeField]
		private new float _value;
		
		public override SoftJointLimit Value
		{
			get => new SoftJointLimit { limit = _value };
			set => _value = value.limit;
		}
	}
	
	[Serializable]
	[DataType(typeof(SoftJointLimit))]
	public sealed partial class SoftJointLimitListRef : ListVariableRef<SoftJointLimit>
	{
	}
	
	[Serializable]
	[DataType(typeof(SoftJointLimit))]
	public sealed partial class SoftJointLimitListVar : ListVariableVar<SoftJointLimit>
	{
	}
}
