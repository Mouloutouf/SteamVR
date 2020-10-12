using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace GamePlay
{
    [CreateAssetMenu(menuName = "Atom Variables/Bool Variable")]
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