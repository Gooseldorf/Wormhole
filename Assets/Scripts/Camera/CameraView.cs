using Cinemachine;
using Data;
using UnityEngine;
using Zenject;


namespace Views
{
    public class CameraView : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _vcam;
        private CameraData _cameraData;
        private CinemachineBasicMultiChannelPerlin _noiseExtension;
        
        public CinemachineVirtualCamera Vcam => _vcam;
        public CinemachineBasicMultiChannelPerlin NoiseExtension => _noiseExtension;

        [Inject]
        private void Construct(CameraData data)
        {
            _cameraData = data;
            
            InitializeValues();
        }

        private void InitializeValues()
        {
            _noiseExtension = _vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            _noiseExtension.m_AmplitudeGain = _cameraData.NoiseAmplitude;
            _noiseExtension.m_FrequencyGain = _cameraData.NoiseFrequency;
        }
    }
}
