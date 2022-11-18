using TMPro;
using UnityEngine;


public sealed class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _time;
    
    public TextMeshProUGUI Score => _score;
    public TextMeshProUGUI Time => _time;
    
}
