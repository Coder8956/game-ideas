
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	/// <summary>
	/// SoftJointLimitSpring fields are not serializable.
	/// </summary>
	[Serializable]
	public class SerializableSoftJointLimitSpring
	{
		public float spring;
		public float damper;

		public SerializableSoftJointLimitSpring()
		{
		}

		public SerializableSoftJointLimitSpring(SoftJointLimitSpring softJointLimitSpring)
		{
			spring = softJointLimitSpring.spring;
			damper = softJointLimitSpring.damper;
		}

		public SoftJointLimitSpring ToSoftJointLimitSpring()
		{
			return new SoftJointLimitSpring
			{
				spring = spring,
				damper = damper
			};
		}

		public static implicit operator SoftJointLimitSpring(SerializableSoftJointLimitSpring serializable)
		{
			return serializable?.ToSoftJointLimitSpring() ?? new SoftJointLimitSpring();
		}

		public static implicit operator SerializableSoftJointLimitSpring(SoftJointLimitSpring softJointLimitSpring)
		{
			return new SerializableSoftJointLimitSpring(softJointLimitSpring);
		}
	}

	
	[Serializable]
	[DataType(typeof(SoftJointLimitSpring))]
	public sealed partial class SoftJointLimitSpringVariable : Variable<SoftJointLimitSpring>
	{
		[SerializeField]
		private new SerializableSoftJointLimitSpring _value;
		
		public override SoftJointLimitSpring Value
		{
			get => _value;
			set => _value = value;
		}
		
		public SoftJointLimitSpringVariable()
		{
		}
		
		public SoftJointLimitSpringVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(SoftJointLimitSpring))]
	public sealed partial class SoftJointLimitSpringListVariable : ListVariable<SoftJointLimitSpring>
	{
		
		public SoftJointLimitSpringListVariable()
		{
		}
		
		public SoftJointLimitSpringListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(SoftJointLimitSpring))]
	public sealed partial class SoftJointLimitSpringRef : VariableRef<SoftJointLimitSpring>
	{
	}
	
	[Serializable]
	[DataType(typeof(SoftJointLimitSpring))]
	public sealed partial class SoftJointLimitSpringVar : VariableVar<SoftJointLimitSpring>
	{
		[SerializeField]
		private new SerializableSoftJointLimitSpring _value;
		
		public override SoftJointLimitSpring Value
		{
			get => _value;
			set => _value = value;
		}

	}
	
	[Serializable]
	[DataType(typeof(SoftJointLimitSpring))]
	public sealed partial class SoftJointLimitSpringListRef : ListVariableRef<SoftJointLimitSpring>
	{
	}
	
	[Serializable]
	[DataType(typeof(SoftJointLimitSpring))]
	public sealed partial class SoftJointLimitSpringListVar : ListVariableVar<SoftJointLimitSpring>
	{
	}
}
