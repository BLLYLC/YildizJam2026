using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private string exitButton = "MenuScene";
    [SerializeField] private string chooseYourWeaponButton = "WeaponSelect";
    [SerializeField] private string playAgain = "GameScene";

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
