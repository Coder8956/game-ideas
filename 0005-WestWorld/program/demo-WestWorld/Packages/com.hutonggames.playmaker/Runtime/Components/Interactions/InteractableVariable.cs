using System;
using System.Collections.Generic;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [DataType(typeof(Interactable))]
    public sealed partial class InteractableVariable : Variable<Interactable>
    {
        public InteractableVariable()
        {
        }

        public InteractableVariable(string name) :
            base(name)
        {
        }
    }

    [Serializable]
    [DataType(typeof(Interactable))]
    public sealed partial class InteractableListVariable : ListVariable<Interactable>
    {
        public InteractableListVariable()
        {
        }

        public InteractableListVariable(string name) :
            base(name)
        {
        }
    }

    [Serializable]
    [DataType(typeof(Interactable))]
    public sealed partial class InteractableRef : BaseComponentRef<Interactable>
    {
    }

    [Serializable]
    [DataType(typeof(Interactable))]
    public sealed partial class InteractableVar : BaseComponentVar<Interactable>
    {
    }

    [Serializable]
    [DataType(typeof(Interactable))]
    public sealed partial class InteractableListRef : ListVariableRef<Interactable>
    {
    }

    [Serializable]
    [DataType(typeof(Interactable))]
    public sealed partial class InteractableListVar : ListVariableVar<Interactable>
    {
    }

    [Serializable]
    [DataType(typeof(Interactable))]
    public sealed partial class InteractableOverride : VariableOverride<Interactable, InteractableVariable, InteractableVar>
    {
        public InteractableOverride(IVariable variable) :
            base(variable)
        {
        }
    }

    [Serializable]
    [DataType(typeof(Interactable))]
    public sealed partial class InteractableOutput : VariableOutput<Interactable, InteractableVariable, InteractableRef>
    {
        public InteractableOutput(IVariable variable) :
            base(variable)
        {
        }
    }

    [Serializable]
    [DataType(typeof(Interactable))]
    public sealed partial class InteractableListOverride : VariableOverride<List<Interactable>, InteractableListVariable, InteractableListVar>
    {
        public InteractableListOverride(IVariable variable) :
            base(variable)
        {
        }
    }

    [Serializable]
    [DataType(typeof(Interactable))]
    public sealed partial class InteractableListOutput : VariableOutput<List<Interactable>, InteractableListVariable, InteractableListRef>
    {
        public InteractableListOutput(IVariable variable) :
            base(variable)
        {
        }
    }
}
