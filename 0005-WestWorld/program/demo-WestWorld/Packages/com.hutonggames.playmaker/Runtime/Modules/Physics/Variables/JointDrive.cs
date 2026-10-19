
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	/// <summary>
	/// JointDrives fields are not serializable.
	/// </summary>
	[Serializable]
	public class SerializableJointDrive
	{
		public float positionSpring;
		public float positionDamper;
		public float maximumForce;
		public bool useAcceleration;

		public SerializableJointDrive()
		{
		}

		public SerializableJointDrive(JointDrive jointDrive)
		{
			positionSpring = jointDrive.positionSpring;
			positionDamper = jointDrive.positionDamper;
			maximumForce = jointDrive.maximumForce;
			useAcceleration = jointDrive.useAcceleration;
		}

		public JointDrive ToJointDrive()
		{
			return new JointDrive
			{
				positionSpring = positionSpring,
				positionDamper = positionDamper,
				maximumForce = maximumForce,
				useAcceleration = useAcceleration
			};
		}

		public static implicit operator JointDrive(SerializableJointDrive serializable)
		{
			return serializable?.ToJointDrive() ?? new JointDrive();
		}

		public static implicit operator SerializableJointDrive(JointDrive jointDrive)
		{
			return new SerializableJointDrive(jointDrive);
		}
	}

	
	[Serializable]
	[DataType(typeof(JointDrive))]
	public sealed partial class JointDriveVariable : Variable<JointDrive>
	{
		[SerializeField]
		private new SerializableJointDrive _value;
		
		public override JointDrive Value
		{
			get => _value;
			set => _value = value;
		}
		
		public JointDriveVariable()
		{
		}
		
		public JointDriveVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(JointDrive))]
	public sealed partial class JointDriveListVariable : ListVariable<JointDrive>
	{
		
		public JointDriveListVariable()
		{
		}
		
		public JointDriveListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(JointDrive))]
	public sealed partial class JointDriveRef : VariableRef<JointDrive>
	{
	}
	
	[Serializable]
	[DataType(typeof(JointDrive))]
	public sealed partial class JointDriveVar : VariableVar<JointDrive>
	{
		[SerializeField]
		private new SerializableJointDrive _value;
		
		public override JointDrive Value
		{
			get => _value;
			set => _value = value;
		}
	}
	
	[Serializable]
	[DataType(typeof(JointDrive))]
	public sealed partial class JointDriveListRef : ListVariableRef<JointDrive>
	{
	}
	
	[Serializable]
	[DataType(typeof(JointDrive))]
	public sealed partial class JointDriveListVar : ListVariableVar<JointDrive>
	{
	}
}
