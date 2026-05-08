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
        ShowInfo(0);
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
