using System;

namespace HutongGames.PlayMaker.UI
{
    [Serializable]
    [DataType(typeof(SpriteMeter))]
    public class SpriteMeterVariable : Variable<SpriteMeter>
    {
        public SpriteMeterVariable()
        {
        }

        public SpriteMeterVariable(string name) : base(name)
        {
        }
    }

    [Serializable]
    [DataType(typeof(SpriteMeter))]
    public class SpriteMeterVar : VariableVar<SpriteMeter>
    {
    }

    [Serializable]
    [DataType(typeof(SpriteMeter))]
    public class SpriteMeterRef : VariableRef<SpriteMeter>
    {
    }
}
