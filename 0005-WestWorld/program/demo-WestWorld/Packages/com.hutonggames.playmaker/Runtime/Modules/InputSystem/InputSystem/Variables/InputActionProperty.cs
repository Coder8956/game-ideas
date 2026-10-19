#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DataType(typeof(InputActionProperty))]
    public sealed partial class InputActionPropertyVariable : Variable<InputActionProperty>, IHasDebugText
    {
        public InputActionPropertyVariable()
        {
        }

        public InputActionPropertyVariable(string name) : base(name)
        {
        }

        public void AppendDebugText(ref DebugTextWriter writer)
        {
            _value.AppendDebugText(ref writer);
        }
    }

    [Serializable]
    [DataType(typeof(InputActionProperty))]
    public sealed partial class InputActionPropertyListVariable : ListVariable<InputActionProperty>
    {
        public InputActionPropertyListVariable()
        {
        }

        public InputActionPropertyListVariable(string name) : base(name)
        {
        }
    }

    [Serializable]
    [DataType(typeof(InputActionProperty))]
    public sealed partial class InputActionPropertyRef : VariableRef<InputActionProperty>
    {
    }

    [Serializable]
    [DataType(typeof(InputActionProperty))]
    public sealed partial class InputActionPropertyVar : VariableVar<InputActionProperty>, IHasDebugText
    {
        public void AppendDebugText(ref DebugTextWriter writer)
        {
            if (IsConstantValue)
            {
                Value.AppendDebugText(ref writer);
                return;
            }

            // VariableVar: show referenced variable name when not constant
            writer.EntryRaw(Variable?.ToString() ?? "None");
        }
    }

    internal static class InputActionPropertyExtensions
    {
        internal static void AppendDebugText(this InputActionProperty value, ref DebugTextWriter writer)
        {
            if (value.action == null)
            {
                writer.EntryRaw("None");
                return;
            }

            // Inline action (not from a reference asset)
            if (value.reference == null)
            {
                // Prefer no per-binding allocations (avoid ToDisplayString string concatenation beyond what it does internally).
                // We'll build a comma separated list with the writer's underlying pooled builder.
                var sb = writer.Builder;
                var any = false;

                foreach (var binding in value.action.bindings)
                {
                    var displayString = binding.ToDisplayString(InputBinding.DisplayStringOptions.DontUseShortDisplayNames);
                    if (string.IsNullOrEmpty(displayString))
                        continue;

                    if (any) sb.Append(", ");
                    sb.Append(displayString);
                    any = true;
                }

                if (!any)
                    writer.EntryRaw("None");

                return;
            }

            // Referenced action asset
            writer.Builder
                .Append(value.action.name)
                .Append(" (")
                .Append(value.action.type.ToString())
                .Append(')');
        }
    }

    [Serializable]
    [DataType(typeof(InputActionProperty))]
    public sealed partial class InputActionPropertyListRef : ListVariableRef<InputActionProperty>
    {
    }

    [Serializable]
    [DataType(typeof(InputActionProperty))]
    public sealed partial class InputActionPropertyListVar : ListVariableVar<InputActionProperty>
    {
    }

    [Serializable]
    [DataType(typeof(InputActionProperty))]
    public sealed partial class InputActionPropertyOverride : VariableOverride<InputActionProperty, InputActionPropertyVariable, InputActionPropertyVar>
    {
        public InputActionPropertyOverride(IVariable variable) : base(variable)
        {
        }
    }

    [Serializable]
    [DataType(typeof(InputActionProperty))]
    public sealed partial class InputActionPropertyOutput : VariableOutput<InputActionProperty, InputActionPropertyVariable, InputActionPropertyRef>
    {
        public InputActionPropertyOutput(IVariable variable) : base(variable)
        {
        }
    }

    [Serializable]
    [DataType(typeof(InputActionProperty))]
    public sealed partial class InputActionPropertyListOverride : VariableOverride<List<InputActionProperty>, InputActionPropertyListVariable, InputActionPropertyListVar>
    {
        public InputActionPropertyListOverride(IVariable variable) : base(variable)
        {
        }
    }

    [Serializable]
    [DataType(typeof(InputActionProperty))]
    public sealed partial class InputActionPropertyListOutput : VariableOutput<List<InputActionProperty>, InputActionPropertyListVariable, InputActionPropertyListRef>
    {
        public InputActionPropertyListOutput(IVariable variable) : base(variable)
        {
        }
    }
}

#endif
