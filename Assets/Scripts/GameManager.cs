using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static string p1WeaponName;
    public static string p2WeaponName;

    private static int p1Wins = 0;
    private static int p2Wins = 0;
    public int currentRound = 1;
    public const int maxRounds = 2;

    private void Awake()
    {
        if (Instance != null) { Destroy(gameObject); }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void SetWeapon(int pID,string weaponName)
    {
        if(pID == 0)
        {
            p1WeaponName = weaponName;
        }else if(pID == 1)
        {
            p2WeaponName = weaponName;
        }
    }
    public string GetWeaponName(int pID)
    {
        if (pID == 0)
        {
            return p1WeaponName;
        }
        else if (pID == 1)
        {
            return p2WeaponName;
        }
        return null;
    }

    public void RoundOver(int loserID)
    {
        if (loserID == 0) { p2Wins++; } // Player1 kaybetti, Player2 kazandý
        else { p1Wins++; }               // Player2 kaybetti, Player1 kazandý
        print("P1 win sayýsý"+p1Wins +"p2win sayýsý" +p2Wins);
        // currentRound yerine kazanma sayýsýna bak
        if (p1Wins >= maxRounds || p2Wins >= maxRounds)
        {
            SceneManager.LoadScene(3); // Birisi 2 round kazandý, bitir
            ResetWins();
        }
        else
        {
            
            SceneManager.LoadScene(2); // Devam et
        }
    }

    public void StartGame()
    {   
        ResetWins();
        SceneManager.LoadScene(2);
    }
    public int GetPlayerWins(int playerID)
    {
        if(playerID == 0)
        {
            return p1Wins;
        }
        else { return p2Wins; }
    }
    public void ResetWins()
    {
        p1Wins= 0;
        p2Wins= 0;
    }
}
