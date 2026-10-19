using System;
using System.Collections.Generic;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [MovedFrom(true, null, null, "InteractionControllerVariable")]
    [DataType(typeof(Interactor))]
    public sealed partial class InteractorVariable : Variable<Interactor>
    {
        public InteractorVariable()
        {
        }

        public InteractorVariable(string name) :
            base(name)
        {
        }
    }

    [Serializable]
    [MovedFrom(true, null, null, "InteractionControllerListVariable")]
    [DataType(typeof(Interactor))]
    public sealed partial class InteractorListVariable : ListVariable<Interactor>
    {
        public InteractorListVariable()
        {
        }

        public InteractorListVariable(string name) :
            base(name)
        {
        }
    }

    [Serializable]
    [MovedFrom(true, null, null, "InteractionControllerRef")]
    [DataType(typeof(Interactor))]
    public sealed partial class InteractorRef : BaseComponentRef<Interactor>
    {
    }

    [Serializable]
    [MovedFrom(true, null, null, "InteractionControllerVar")]
    [DataType(typeof(Interactor))]
    public sealed partial class InteractorVar : BaseComponentVar<Interactor>
    {
    }

    [Serializable]
    [MovedFrom(true, null, null, "InteractionControllerListRef")]
    [DataType(typeof(Interactor))]
    public sealed partial class InteractorListRef : ListVariableRef<Interactor>
    {
    }

    [Serializable]
    [MovedFrom(true, null, null, "InteractionControllerListVar")]
    [DataType(typeof(Interactor))]
    public sealed partial class InteractorListVar : ListVariableVar<Interactor>
    {
    }

    [Serializable]
    [MovedFrom(true, null, null, "InteractionControllerOverride")]
    [DataType(typeof(Interactor))]
    public sealed partial class InteractorOverride : VariableOverride<Interactor, InteractorVariable, InteractorVar>
    {
        public InteractorOverride(IVariable variable) :
            base(variable)
        {
        }
    }

    [Serializable]
    [MovedFrom(true, null, null, "InteractionControllerOutput")]
    [DataType(typeof(Interactor))]
    public sealed partial class InteractorOutput : VariableOutput<Interactor, InteractorVariable, InteractorRef>
    {
        public InteractorOutput(IVariable variable) :
            base(variable)
        {
        }
    }

    [Serializable]
    [MovedFrom(true, null, null, "InteractionControllerListOverride")]
    [DataType(typeof(Interactor))]
    public sealed partial class InteractorListOverride : VariableOverride<List<Interactor>, InteractorListVariable, InteractorListVar>
    {
        public InteractorListOverride(IVariable variable) :
            base(variable)
        {
        }
    }

    [Serializable]
    [MovedFrom(true, null, null, "InteractionControllerListOutput")]
    [DataType(typeof(Interactor))]
    public sealed partial class InteractorListOutput : VariableOutput<List<Interactor>, InteractorListVariable, InteractorListRef>
    {
        public InteractorListOutput(IVariable variable) :
            base(variable)
        {
        }
    }
}
