using GamePlay;
using UnityEngine;

namespace Gameplay.VR
{
    public class AgentAwarenessData : MonoBehaviour
    {
        /*[SerializeField] protected BoolVariable detectedPlayer;*/
        [SerializeField] protected BoolVariable baseState;
        [SerializeField] protected FloatVariable detectionAngle;
        [SerializeField] protected FloatVariable detectionSpeed;
        [SerializeField] protected FloatVariable detectionRange;
        [SerializeField] protected GameEvent detectedPlayer;
        [SerializeField] protected LayerMask layerMask;
        [SerializeField] protected bool isActive;
        protected Light spotLight;
        [SerializeField] protected GameObject target;
        protected double myDetectionAngle; // the angle divided by two (interal value)
    }
}