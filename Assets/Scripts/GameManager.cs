using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static string p1WeaponName;
    public static string p2WeaponName;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
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
}
