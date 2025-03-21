using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    [Serializable]
    public class PlayerCameraUtility
    {
        [field: SerializeField] public CinemachineVirtualCamera VirtualCamera { get; private set; }
        [field: SerializeField] public float DefaultHorizontalWaitTime { get; private set; } = 0f;
        [field: SerializeField] public float DefaultHorizontalRecenteringTime { get; private set; } = 4f;

        private CinemachinePOV cinemachinePov;

        public void Initialize()
        {
            cinemachinePov = VirtualCamera.GetCinemachineComponent<CinemachinePOV>();
        }

        public void EnableRecentering(float waitTime = -1f, float recenteringTime = -1f, float baseMovementSpeed = 1f, float movementSpeed = 1f)
        {
            cinemachinePov.m_HorizontalRecentering.m_enabled = true;

            cinemachinePov.m_HorizontalRecentering.CancelRecentering();

            if(waitTime == -1f)
            {
                waitTime = DefaultHorizontalWaitTime;
            }

            if(recenteringTime == -1f)
            {
                recenteringTime = DefaultHorizontalRecenteringTime;
            }

            recenteringTime = recenteringTime * baseMovementSpeed / movementSpeed;

            cinemachinePov.m_HorizontalRecentering.m_WaitTime = waitTime;
            cinemachinePov.m_HorizontalRecentering.m_RecenteringTime = recenteringTime;
        }

        public void DisableRecentering()
        {
            cinemachinePov.m_HorizontalRecentering.m_enabled = false;
        }
    }
}
