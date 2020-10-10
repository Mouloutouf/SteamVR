using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace GamePlay
{
    [CreateAssetMenu]
    public class BoolVariable : ScriptableObject
    {
        public bool Value;

        public void SetValue(bool value) => Value = value;

        public bool isTrue()
        {
            return Value;
        }
    }
}