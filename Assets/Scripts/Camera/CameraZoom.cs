using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] [Range(0f, 10f)] private float defaultDistance = 6f;
        [SerializeField] [Range(0f, 10f)] private float minimumDistance = 1f;
        [SerializeField] [Range(0f, 10f)] private float maximumDistance = 6f;

        [SerializeField][Range(0f, 10f)] private float smoothing = 6f;
        [SerializeField][Range(0f, 10f)] private float zoomSensitivity = 6f;

        private CinemachineFramingTransposer framingTransposer;
        private CinemachineInputProvider inputProvider;

        private float currentTargetDistance;

        private void Awake()
        {
            framingTransposer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
            inputProvider = GetComponent<CinemachineInputProvider>();

            currentTargetDistance = defaultDistance;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            Zoom();
        }

        private void Zoom()
        {
            float zoomValue = inputProvider.GetAxisValue(2) * zoomSensitivity;

            currentTargetDistance = Mathf.Clamp(currentTargetDistance + zoomValue, minimumDistance, maximumDistance);

            float currentDistance = framingTransposer.m_CameraDistance;

            if(currentDistance == currentTargetDistance)
            {
                return;
            }

            float lerpedZoomValue = Mathf.Lerp(currentDistance, currentTargetDistance, smoothing * Time.deltaTime);

            framingTransposer.m_CameraDistance = lerpedZoomValue;
        }
    }
}
