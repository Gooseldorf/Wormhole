using System;
using Cinemachine;
using Views;
using Data;
using UnityEngine;

namespace Controllers
{
    public class CameraController
    {
        private readonly CameraView _cameraView;
        private CameraData _cameraData;

        public readonly Action<float> ShakeCameraAction;
        
        public CameraController(CameraView view, CameraData data, PlayerView player)
        {
            _cameraView = view;
            _cameraData = data;
            ShakeCameraAction = ShakeCamera;
            _cameraView.Vcam.Follow = player.VcamTarget;
            _cameraView.Vcam.LookAt = player.VcamTarget;
        }
        
        private void ShakeCamera(float multiplier)
        {
            _cameraView.NoiseExtension.m_AmplitudeGain = _cameraData.NoiseAmplitude * multiplier;
            _cameraView.NoiseExtension.m_FrequencyGain = _cameraData.NoiseAmplitude * multiplier;
        }
    }
}