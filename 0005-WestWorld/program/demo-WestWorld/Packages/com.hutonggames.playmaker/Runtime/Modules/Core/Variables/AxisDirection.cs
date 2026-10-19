using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	public enum AxisDirection
	{
		[InspectorName("X (Right)")] X,
		[InspectorName("Y (Up)")] Y,
		[InspectorName("Z (Forward)")] Z,
		[InspectorName("-X (Left)")] NegativeX,
		[InspectorName("-Y (Down)")] NegativeY,
		[InspectorName("-Z (Back)")] NegativeZ
	}

	public static class AxisDirectionExtensions
	{
		public static Vector3 GetDirection(this AxisDirection axisDirection, Transform transform)
		{
			return axisDirection switch
			{
				AxisDirection.X         => transform.right,
				AxisDirection.Y         => transform.up,
				AxisDirection.Z         => transform.forward,
				AxisDirection.NegativeX => -transform.right,
				AxisDirection.NegativeY => -transform.up,
				AxisDirection.NegativeZ => -transform.forward,
				_                       => Vector3.zero
			};
		}

		public static Vector3 GetDirection(this AxisDirection axisDirection)
		{
			return axisDirection switch
			{
				AxisDirection.X         => Vector3.right,
				AxisDirection.Y         => Vector3.up,
				AxisDirection.Z         => Vector3.forward,
				AxisDirection.NegativeX => -Vector3.right,
				AxisDirection.NegativeY => -Vector3.up,
				AxisDirection.NegativeZ => -Vector3.forward,
				_                       => Vector3.zero
			};
		}

		public static Vector3 GetOrthogonal(this AxisDirection axisDirection)
		{
			return axisDirection switch
			{
				AxisDirection.X or AxisDirection.NegativeX => Vector3.up,
				AxisDirection.Y or AxisDirection.NegativeY => Vector3.forward,
				_ => Vector3.up
			};
		}
		
		public static AxisDirection GetPlaneNormal(this AxisDirection localForward)
		{
			switch (localForward)
			{
				case AxisDirection.X:
				case AxisDirection.NegativeX:
				case AxisDirection.Y:
				case AxisDirection.NegativeY:
					return AxisDirection.Z; // sprite convention: normal is +Z
				case AxisDirection.Z:
				case AxisDirection.NegativeZ:
				default:
					return AxisDirection.Y; // mesh convention: normal is +Y
			}
		}
	}
    
	[Serializable]
	[DataType(typeof(AxisDirection))]
	public sealed partial class AxisDirectionVariable : Variable<AxisDirection>
	{
		
		public AxisDirectionVariable()
		{
		}
		
		public AxisDirectionVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(AxisDirection))]
	public sealed partial class AxisDirectionListVariable : ListVariable<AxisDirection>
	{
		
		public AxisDirectionListVariable()
		{
		}
		
		public AxisDirectionListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(AxisDirection))]
	public sealed partial class AxisDirectionRef : VariableRef<AxisDirection>
	{
	}
	
	[Serializable]
	[DataType(typeof(AxisDirection))]
	public sealed partial class AxisDirectionVar : VariableVar<AxisDirection>
	{
	}
	
	[Serializable]
	[DataType(typeof(AxisDirection))]
	public sealed partial class AxisDirectionListRef : ListVariableRef<AxisDirection>
	{
	}
	
	[Serializable]
	[DataType(typeof(AxisDirection))]
	public sealed partial class AxisDirectionListVar : ListVariableVar<AxisDirection>
	{
	}
}