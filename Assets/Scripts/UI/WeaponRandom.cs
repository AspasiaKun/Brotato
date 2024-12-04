using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponRandom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image _backImage;
    public Button _button;
    private List<WeaponUI> weaponUI = new List<WeaponUI>();

    void Awake()
    {
        _backImage = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _backImage.color = new Color(207/255f, 207/255f, 207/255f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _backImage.color = new Color(34/255f, 34/255f, 34/255f);
    }
    // Start is called before the first frame update
    void Start()
    {
        _button.onClick.AddListener(() => {
            RandomButtonClick();
        });
    }

    private void RandomButtonClick()
    {
        foreach(WeaponUI weapon in WeaponSelectPanel.instance._weaponList.GetComponentsInChildren<WeaponUI>()) 
        {
            weaponUI.Add(weapon);
        }
        WeaponUI w = GameManager.instance.RandomInList<WeaponUI>(weaponUI) as WeaponUI;
        w.RenewWeaponUI(w._weaponData);
        w.ButtonClick(w._weaponData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
