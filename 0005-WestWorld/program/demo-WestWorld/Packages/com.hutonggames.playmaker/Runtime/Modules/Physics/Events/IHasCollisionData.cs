using UnityEngine;

namespace HutongGames.PlayMaker
{
    public interface IHasCollisionData
    {
        public Collision Collision { get; }
    }
}