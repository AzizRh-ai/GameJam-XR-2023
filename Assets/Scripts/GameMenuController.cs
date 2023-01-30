using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour
{
    [SerializeField] private GameObject WristMenu;
    private bool isActiveWristUi = true;
    // Start is called before the first frame update
    void Start()
    {
        ShowUiWristMenu();
    }

    public void PauseButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ShowUiWristMenu();
        }
    }

    private void ShowUiWristMenu()
    {
        WristMenu.SetActive(!isActiveWristUi);
        isActiveWristUi = !isActiveWristUi;
        Time.timeScale = isActiveWristUi ? 0f : 1.0f;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
