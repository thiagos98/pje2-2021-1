using System.Collections;
using UnityEngine;

namespace General
{
    public interface IResettable
    {
        public IEnumerator ResetBall(Rigidbody rb);
    }
}