using Cinemachine;
using Views;
using Data;
using UnityEngine;

namespace Controllers
{
    public class CameraController
    {
        private CinemachineVirtualCamera _vcam;

        public CameraController(CameraView view, PlayerView player)
        {
            _vcam = view.Vcam;
            _vcam.Follow = player.VcamTarget;
            _vcam.LookAt = player.VcamTarget;
        }
    }
}