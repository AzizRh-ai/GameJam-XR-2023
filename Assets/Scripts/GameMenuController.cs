using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/*-----------------------------------------------
    -Filename    : GameMenuController
    -Description : Gestion Menu XR-Standard
    -Author      : ARH
    -Date        : lundi 30 janvier 2023
-----------------------------------------------*/

public class GameMenuController : MonoBehaviour
{
    // Ajout UI depuis Unity: Canvas 
    [SerializeField] private GameObject WristMenu;

    // Variable boolean pour l'état du menu
    private bool isActiveWristUi = true;

    private void Start()
    {
        // On disable le menu au lancement
        ShowUiWristMenu();
    }

    public void PauseButtonPressed(InputAction.CallbackContext context)
    {
        // si l'action sur le bouton est fait
        if (context.performed)
            // on affiche le menu
            ShowUiWristMenu();
    }

    private void ShowUiWristMenu()
    {
        // affiche ou pas le menu suivant la valeur de isActiveWristUI
        WristMenu.SetActive(!isActiveWristUi);
        isActiveWristUi = !isActiveWristUi;

        //src = https://docs.unity3d.com/ScriptReference/Time-timeScale.html
        // si true alors valeur 0 = pause sinon on contiue 
        Time.timeScale = isActiveWristUi ? 0f : 1.0f;
    }

    public void RestartGame()
    {
        // On relance la scène actuel
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        // Bye
        Application.Quit();
    }
}