using Cinemachine;
using UnityEngine;

namespace Views
{
    public class CameraView : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _vcam;
        public CinemachineVirtualCamera Vcam => _vcam;
    }
}
