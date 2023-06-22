using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private void Start()
    {
        GameOverCube.OnGameOverTrigger += OnGameOverTrigger;
        HideGameObject();
    }


    private void OnGameOverTrigger()
    {
        ShowGameObject();
    }


    private void ShowGameObject()
    {
        Time.timeScale = 0f;
        this.gameObject.SetActive(true);
    }
    private void HideGameObject()
    {
        this.gameObject.SetActive(false);
    }


    private void OnDestroy()
    {
        GameOverCube.OnGameOverTrigger -= OnGameOverTrigger;
    }
}
