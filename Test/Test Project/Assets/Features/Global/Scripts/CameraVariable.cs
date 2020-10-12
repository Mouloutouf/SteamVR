using UnityEngine;

namespace GamePlay
{
    [CreateAssetMenu(menuName = "Atom Variables/Camera Variable")]
    public class CameraVariable : ScriptableObject
    {
        public Camera Value;

        public void SetValue(Camera value) => Value = value;
    }
}
