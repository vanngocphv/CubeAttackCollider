using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelStatusUI : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private TextMeshProUGUI _currentLevelTMP;
    [SerializeField] private TextMeshProUGUI _nextLevelTMP;
    [SerializeField] private Image _progressBar;

    [Header("Main Status")]
    [SerializeField] private TextMeshProUGUI _mainLevelStatus;
    
    private float _currentProgress;
    private float _currentAmountProgress = 0f;

    private void Start()
    {
        _currentProgress = 0;
        PlayerMovement.Instance.GetComponent<CylinderObject>().OnHitCountChanged += OnHitCountChangeUI;
        _progressBar.fillAmount = _currentAmountProgress;
    }

    private void Update()
    {
        
    }

    private void OnHitCountChangeUI(float hitCount)
    {
        _currentProgress = hitCount;
        _currentAmountProgress = Mathf.Abs((_currentProgress / 60) - Mathf.Ceil(_currentProgress / 60));

        _currentLevelTMP.text = Mathf.Ceil(_currentProgress / 60).ToString();
        _nextLevelTMP.text = Mathf.Ceil(1 + _currentProgress / 60).ToString();
        _progressBar.fillAmount = 1 - _currentAmountProgress;
        _mainLevelStatus.text = _currentLevelTMP.text;
    }

}
