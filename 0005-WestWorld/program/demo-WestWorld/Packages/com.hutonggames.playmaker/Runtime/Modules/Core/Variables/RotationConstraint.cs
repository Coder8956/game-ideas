using System;

namespace HutongGames.PlayMaker
{
    /// <summary>
    /// Specifies how rotation is constrained.
    /// </summary>
    public enum RotationConstraint
    {
        None, // Free rotation in all axes
        X,   // Only around X axis (e.g., pitch)
        Y,   // Only around Y axis (e.g., yaw)
        Z    // Only around Z axis (e.g., 2D top-down)
    }

    [Serializable]
    [DataType(typeof(RotationConstraint))]
    public sealed partial class RotationConstraintVariable : Variable<RotationConstraint>
    {
        public RotationConstraintVariable() { }
        public RotationConstraintVariable(string name) : base(name) { }
    }

    [Serializable]
    [DataType(typeof(RotationConstraint))]
    public sealed partial class RotationConstraintListVariable : ListVariable<RotationConstraint>
    {
        public RotationConstraintListVariable() { }
        public RotationConstraintListVariable(string name) : base(name) { }
    }

    [Serializable]
    [DataType(typeof(RotationConstraint))]
    public sealed partial class RotationConstraintRef : VariableRef<RotationConstraint> { }

    [Serializable]
    [DataType(typeof(RotationConstraint))]
    public sealed partial class RotationConstraintVar : VariableVar<RotationConstraint> { }

    [Serializable]
    [DataType(typeof(RotationConstraint))]
    public sealed partial class RotationConstraintListRef : ListVariableRef<RotationConstraint> { }

    [Serializable]
    [DataType(typeof(RotationConstraint))]
    public sealed partial class RotationConstraintListVar : ListVariableVar<RotationConstraint> { }
}