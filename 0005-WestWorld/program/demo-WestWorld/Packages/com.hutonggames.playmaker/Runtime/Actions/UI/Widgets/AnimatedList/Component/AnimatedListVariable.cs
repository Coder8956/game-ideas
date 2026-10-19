using System;

namespace HutongGames.PlayMaker.UI
{
    [Serializable]
    [DataType(typeof(AnimatedList))]
    public class AnimatedListVariable : Variable<AnimatedList>
    {
        public AnimatedListVariable()
        {
        }

        public AnimatedListVariable(string name) : base(name)
        {
        }
    }

    [Serializable]
    [DataType(typeof(AnimatedList))]
    public class AnimatedListVar : VariableVar<AnimatedList>
    {
    }

    [Serializable]
    [DataType(typeof(AnimatedList))]
    public class AnimatedListRef : VariableRef<AnimatedList>
    {
    }
}