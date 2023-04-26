using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
-- Author: Andrew Orvis
-- Description: Class for handeling tile screen buttons and menus
 */

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] GameObject playMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject helpMenu;
    [SerializeField] GameObject credits;

    private void Update()
    {
        if (this.isActiveAndEnabled)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
    private void Start()
    {
        playMenu.SetActive(false);
        optionsMenu.SetActive(false);
        helpMenu.SetActive(false);
        credits.SetActive(false);
    }

    #region open and closers
    public void openPlay()
    {
        playMenu.gameObject.SetActive(true);
        closeHelp();
        closeCredits();
        closeOptions();
    }
    public void closePlay() { playMenu.gameObject.SetActive(false); }
    public void openOptions(){
        optionsMenu.gameObject.SetActive(true);
        closeHelp();
        closeCredits();
        closePlay();
    }
    public void closeOptions(){optionsMenu.gameObject.SetActive(false);}
    public void openHelp(){
        helpMenu.gameObject.SetActive(true);
        closeOptions();
        closeCredits();
        closePlay();
    }
    public void closeHelp() { helpMenu.gameObject.SetActive(false); }
    public void openCredits(){
        credits.gameObject.SetActive(true);
        closeHelp();
        closeOptions();
        closePlay();
    }
    public void closeCredits() { credits.gameObject.SetActive(false); }
    #endregion


    public void quiteGame()
    {
        Application.Quit();
    }
}
