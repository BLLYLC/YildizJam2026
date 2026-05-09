using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionUI : MonoBehaviour
{
    [SerializeField] private List<WeaponInfoSO> weaponSOList;
    [SerializeField] private TextMeshProUGUI firstHalfTMP;
    [SerializeField] private TextMeshProUGUI secondHalfTMP;
    [SerializeField] private TextMeshProUGUI weaponNameTMP;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button leftButton;
    [SerializeField] private Image weaponSprite;
    [SerializeField] private int playerID;
    private int currentIndex = 0;

    private void Awake()
    {
        rightButton.onClick.AddListener(() => {
            ShowInfo(++currentIndex);
        });
        leftButton.onClick.AddListener(() => {
            ShowInfo(--currentIndex);
        });
    }
    private void Start()
    {
        GameInput.Instance.OnRightArrowAction += GameInput_OnRightArrowAction;
        GameInput.Instance.OnLeftArrowAction += GameInput_OnLeftArrowAction;
        GameInput.Instance.OnInteract1Action += GameInput_OnInteract1Action;
        ShowInfo(0);
    }

    private void GameInput_OnInteract1Action(object sender, int pID)
    {
        if (pID == 0)
        {
            GameManager.Instance.SetWeapon(0,weaponSOList[currentIndex].name);
        }
        else if (pID == 1)
        {
            GameManager.Instance.SetWeapon(1, weaponSOList[currentIndex].name);
        }
    }

    private void GameInput_OnLeftArrowAction(object sender, int pID)
    {
        if (playerID == pID)
        {
            leftButton.onClick.Invoke();
        }
    }

    private void GameInput_OnRightArrowAction(object sender, int pID)
    {
        if (playerID == pID)
        {
            rightButton.onClick.Invoke();
        }
    }

    private void ShowInfo(int index)
    {
        if (currentIndex > weaponSOList.Count-1) { currentIndex = 0; }
        if(currentIndex == -1)
        {
            currentIndex = weaponSOList.Count-1;
        }
        print(currentIndex);
        WeaponInfoSO currentWeapon = weaponSOList[currentIndex];
        weaponNameTMP.text = currentWeapon.WeaponName;
        firstHalfTMP.text = currentWeapon.FirstHalf;
        secondHalfTMP.text = currentWeapon.SecondHalf;
        weaponSprite.sprite = currentWeapon.WeaponSprite;
    }
}
