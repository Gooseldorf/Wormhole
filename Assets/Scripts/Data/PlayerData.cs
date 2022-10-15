using UnityEngine;


[CreateAssetMenu(menuName = "My Assets/PLayerData")]
public class PlayerData : ScriptableObject
{
   [SerializeField] private GameObject _playerPrefab;
   [SerializeField] private float _playerSpeed;

   
}
