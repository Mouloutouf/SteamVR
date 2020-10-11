using GamePlay;
using UnityEngine;

namespace Gameplay.VR
{
    public class AgentAwarenessData : MonoBehaviour
    {
        /*[SerializeField] protected BoolVariable isActive;
        [SerializeField] protected BoolVariable detectedPlayer;*/
        [SerializeField] protected FloatVariable detectionAngle;
        [SerializeField] protected FloatVariable detectionSpeed;
        [SerializeField] protected FloatVariable detectionRange;
        [SerializeField] protected GameEvent detectedPlayer;
        protected Light spotLight;
        protected GameObject target;
        protected double myDetectionAngle; // the angle divided by two (interal value)
    }
}