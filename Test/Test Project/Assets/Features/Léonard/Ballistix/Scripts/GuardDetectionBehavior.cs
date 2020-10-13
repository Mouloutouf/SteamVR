using UnityEngine;

namespace Gameplay.VR
{
    public class GuardDetectionBehavior : GuardDetectionData
    {
        // call when the player is detected
        public void GE_BulletTime()
        {
            Debug.Log("I'm entering bullet time");
            Time.timeScale /= 4;
        }
    }
}