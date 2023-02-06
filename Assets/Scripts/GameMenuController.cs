using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

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
    [SerializeField] private GameObject EndMenu;
    [SerializeField] private ScoreManager scriptScoreManager;
    [SerializeField] private XRInteractorLineVisual XrLine;
    [SerializeField] private GameObject StartMenu;
    private bool isActiveStartMenuUi = true;
    private int countNext = 0;

    // Variable boolean pour l'état du menu
    private bool isActiveWristUi = false;

    private void Start()
    {
        isActiveWristUi = false;
        // On disable le menu au lancement
        Time.timeScale = 0;
        StartMenu.SetActive(true);
        XrLine.enabled = true;
        OnStart();
        //ShowUiWristMenu();
    }

    public void OnStart()
    {
        countNext++;
        if (countNext < 4)
        {
            scriptScoreManager.OnStartMenu(countNext);
            XrLine.enabled = true;
        }
        else
        {
            isActiveStartMenuUi = false;
            isActiveWristUi = false;
            StartMenu.SetActive(false);
            XrLine.enabled = false;
            Time.timeScale = 1;
        }
    }

    public void PauseButtonPressed(InputAction.CallbackContext context)
    {
        // si l'action sur le bouton est fait
        // on affiche le menu
        ShowUiWristMenu();
    }

    public void ShowUiWristMenu()
    {
        if (isActiveStartMenuUi == false)
        {
            // affiche ou pas le menu suivant la valeur de isActiveWristUI
            WristMenu.SetActive(!isActiveWristUi);
            isActiveWristUi = !isActiveWristUi;

            //src = https://docs.unity3d.com/ScriptReference/Time-timeScale.html
            // si true alors valeur 0 = pause sinon on contiue 
            Time.timeScale = isActiveWristUi ? 0f : 1.0f;
        }
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

    public void PauseGameEnd()
    {
        Time.timeScale = 0;
        EndMenu.SetActive(true);
    }

}