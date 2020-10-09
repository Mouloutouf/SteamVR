using UnityEngine;

namespace GamePlay
{
    [CreateAssetMenu]
    public class FloatVariable : ScriptableObject
    {
        public float Value;

        public void SetValue(float value) => Value = value;
    }
}