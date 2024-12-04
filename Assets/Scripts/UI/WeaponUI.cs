using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public WeaponData _weaponData;
    public Image _backImage;
    public Image _avatar;
    public Button _button;

    void Awake() {
        _backImage = GetComponent<Image>();
        _avatar = transform.GetChild(0).GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    public void setData(WeaponData weaponData) 
    {
        this._weaponData = weaponData;
        
        _avatar.sprite = Resources.Load<Sprite>(weaponData.avatar);
        
        _button.onClick.AddListener(()=> {
            ButtonClick(weaponData);
        });
    }

    public void ButtonClick(WeaponData weaponData)
    {
        // 记录当前武器
        GameManager.instance.setWeaponDatas(weaponData);
        // 克隆武器UI
        GameObject weapon_clone = Instantiate(WeaponSelectPanel.instance._weaponDetails, DifficultySelectPanel.instance._difficultyContent);
        weapon_clone.transform.SetSiblingIndex(0);
        // 克隆角色UI
        GameObject role_clone = Instantiate(RoleSelectPanel.instance._roleDetails, DifficultySelectPanel.instance._difficultyContent);
        role_clone.transform.SetSiblingIndex(0);
        // 关闭当前面板
        WeaponSelectPanel.instance._canvasGroup.alpha = 0;
        WeaponSelectPanel.instance._canvasGroup.interactable = false;
        WeaponSelectPanel.instance._canvasGroup.blocksRaycasts = false;
        // 打开下一个面板
        DifficultySelectPanel.instance._canvasGroup.alpha = 1;
        DifficultySelectPanel.instance._canvasGroup.interactable = true;
        DifficultySelectPanel.instance._canvasGroup.blocksRaycasts = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _backImage.color = new Color(207/255f, 207/255f, 207/255f);
        if (WeaponSelectPanel.instance._weaponDetailCanvasGroup.alpha != 1) {
            WeaponSelectPanel.instance._weaponDetailCanvasGroup.alpha = 1;
            WeaponSelectPanel.instance._weaponDetailCanvasGroup.interactable = true;
            WeaponSelectPanel.instance._weaponDetailCanvasGroup.blocksRaycasts = true;
        }
        RenewWeaponUI(_weaponData);
    }

    // 更新上方卡片ui
    public void RenewWeaponUI(WeaponData weaponData)
    {
        WeaponSelectPanel.instance._weaponAvatar.sprite = Resources.Load<Sprite>(weaponData.avatar);
        WeaponSelectPanel.instance._weaponName.text = weaponData.name;
        WeaponSelectPanel.instance._weaponType.text = weaponData.isLong == 0 ? "近战" : "远程";
        WeaponSelectPanel.instance._weaponDescribe.text = weaponData.describe;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _backImage.color = new Color(34/255f, 34/255f, 34/255f);
    }
}
