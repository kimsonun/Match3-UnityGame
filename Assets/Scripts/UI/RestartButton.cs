using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;

    public void Setup(GameManager manager)
    {
        gameManager = manager;
    }

    private void Awake()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(RestartLevel);
        }
    }

    private void RestartLevel()
    {
        if (gameManager != null)
        {
            gameManager.RestartCurrentLevel();
        }
    }

    private void OnDestroy()
    {
        if (button != null)
        {
            button.onClick.RemoveListener(RestartLevel);
        }
    }
} 