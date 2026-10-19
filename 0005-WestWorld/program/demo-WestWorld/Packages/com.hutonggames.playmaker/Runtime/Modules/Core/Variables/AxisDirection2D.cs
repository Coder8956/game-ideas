using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    public enum AxisDirection2D
    {
		[InspectorName("X (Right)")] X,
		[InspectorName("Y (Up)")] Y,
		[InspectorName("-X (Left)")] NegativeX,
		[InspectorName("-Y (Down)")] NegativeY,
    }
	
	internal static class AxisDirection2DAdapter
	{
		public static AxisDirection ToAxisDirection(this AxisDirection2D a) => a switch
		{
			AxisDirection2D.X         => AxisDirection.X,
			AxisDirection2D.Y         => AxisDirection.Y,
			AxisDirection2D.NegativeX => AxisDirection.NegativeX,
			AxisDirection2D.NegativeY => AxisDirection.NegativeY,
			_                         => AxisDirection.X
		};
	}

    public static class AxisDirection2DExtensions
    {
	    public static Vector3 GetDirection(this AxisDirection2D axisDirection2D, Transform transform)
	    {
		    var direction = axisDirection2D switch
		    {
			    AxisDirection2D.X => transform.right,
			    AxisDirection2D.Y => transform.up,
			    AxisDirection2D.NegativeX => -transform.right,
			    AxisDirection2D.NegativeY => -transform.up,
			    _ => new Vector3()
		    };

		    return direction;
	    }
	    
	    public static Vector3 GetDirection(this AxisDirection2D axisDirection2D)
	    {
		    var direction = axisDirection2D switch
		    {
			    AxisDirection2D.X => Vector3.right,
			    AxisDirection2D.Y => Vector3.up,
			    AxisDirection2D.NegativeX => -Vector3.right,
			    AxisDirection2D.NegativeY => -Vector3.up,
			    _ => new Vector3()
		    };

		    return direction;
	    }
    }
    
	[Serializable]
	[DataType(typeof(AxisDirection2D))]
	public sealed partial class AxisDirection2DVariable : Variable<AxisDirection2D>
	{
		
		public AxisDirection2DVariable()
		{
		}
		
		public AxisDirection2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(AxisDirection2D))]
	public sealed partial class AxisDirection2DListVariable : ListVariable<AxisDirection2D>
	{
		
		public AxisDirection2DListVariable()
		{
		}
		
		public AxisDirection2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(AxisDirection2D))]
	public sealed partial class AxisDirection2DRef : VariableRef<AxisDirection2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(AxisDirection2D))]
	public sealed partial class AxisDirection2DVar : VariableVar<AxisDirection2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(AxisDirection2D))]
	public sealed partial class AxisDirection2DListRef : ListVariableRef<AxisDirection2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(AxisDirection2D))]
	public sealed partial class AxisDirection2DListVar : ListVariableVar<AxisDirection2D>
	{
	}
}