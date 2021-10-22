using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ExitGameButton : MonoBehaviour
{
    private Button exitButton;

    private void Awake()
    {
        exitButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
