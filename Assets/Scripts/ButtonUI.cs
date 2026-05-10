using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class ButtonUI : MonoBehaviour
{

    public void ExitGameButton()
    {
        SceneManager.LoadScene(0); //main menu
    }

    public void WeaponSceneGameButton()
    {
        SceneManager.LoadScene(1); //weapon screne
    } 
    
    public void NewGameButton()
    {
        SceneManager.LoadScene(2); // game erkraný
    }
}
