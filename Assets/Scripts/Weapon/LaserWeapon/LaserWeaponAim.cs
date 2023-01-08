using UnityEngine;


public class LaserWeaponAim : MonoBehaviour
{
    [SerializeField] private Transform _leftAim;
    [SerializeField] private Transform _rightAim;
    [SerializeField] private GameObject _leftCrossHair;
    [SerializeField] private GameObject _rightCrossHair;
    [SerializeField] private Canvas _leftCanvas;
    [SerializeField] private Canvas _rightCanvas;

    private RaycastHit _left;
    private RaycastHit _right;
    

    private void Update()
    {
        if (Physics.Raycast(_leftAim.position, Vector3.forward, out _left, 200f))
        {
            _leftCanvas.enabled = true;
            _leftCrossHair.transform.position = _left.point;
        }
        else
        {
            _leftCanvas.enabled = false;
        }

        if (Physics.Raycast(_rightAim.position, Vector3.forward, out _right, 200f))
        {
            _rightCanvas.enabled = true;
            _rightCrossHair.transform.position = _right.point;
        }
        else
        {
            _rightCanvas.enabled = false;
        }
    }
}
