using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	public enum MoveAxis
	{
		[InspectorName("XYZ (3D)")] XYZ,
		[InspectorName("XY (2D Plane)")] XY,
		[InspectorName("XZ (Ground Plane)")] XZ,
		[InspectorName("X (Horizontal Only)")] X,
		[InspectorName("Y (Vertical Only)")] Y,
		[InspectorName("Z (Depth Only)")] Z,
		[InspectorName("YZ (Side-On 2D)")] YZ   // new, appended safely
	}
    
	[Serializable]
	[DataType(typeof(MoveAxis))]
	public sealed partial class MoveAxisVariable : Variable<MoveAxis>
	{
		
		public MoveAxisVariable()
		{
		}
		
		public MoveAxisVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(MoveAxis))]
	public sealed partial class MoveAxisListVariable : ListVariable<MoveAxis>
	{
		
		public MoveAxisListVariable()
		{
		}
		
		public MoveAxisListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(MoveAxis))]
	public sealed partial class MoveAxisRef : VariableRef<MoveAxis>
	{
	}
	
	[Serializable]
	[DataType(typeof(MoveAxis))]
	public sealed partial class MoveAxisVar : VariableVar<MoveAxis>
	{
	}
	
	[Serializable]
	[DataType(typeof(MoveAxis))]
	public sealed partial class MoveAxisListRef : ListVariableRef<MoveAxis>
	{
	}
	
	[Serializable]
	[DataType(typeof(MoveAxis))]
	public sealed partial class MoveAxisListVar : ListVariableVar<MoveAxis>
	{
	}
}