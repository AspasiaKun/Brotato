using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class RoleUI : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public RoleData _roleData; 
    public Image _backImage;
    public Image _avatar;
    public Button _button;

    void Awake() {
        _backImage = GetComponent<Image>();
        _avatar = transform.GetChild(0).GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _backImage.color = new Color(207/255f, 207/255f, 207/255f);
        if (RoleSelectPanel.instance._contentCanvasGroup.alpha != 1) {
            RoleSelectPanel.instance._contentCanvasGroup.alpha = 1;
            RoleSelectPanel.instance._contentCanvasGroup.interactable = true;
            RoleSelectPanel.instance._contentCanvasGroup.blocksRaycasts = true;
        }
        RenewUI(_roleData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _backImage.color = new Color(34/255f, 34/255f, 34/255f);
    }

    public void RenewUI(RoleData r)
    {

        //  未解锁
        if(r.unlock == 0) {
            RoleSelectPanel.instance._roleName.text = "???";
            RoleSelectPanel.instance._roleAvatar.sprite = Resources.Load<Sprite>("Image/UI/锁");
            RoleSelectPanel.instance._roleDescribe.text = r.unlockConditions;
            RoleSelectPanel.instance._roleRecordDetail.text = "尚未解锁";
        }
        else {
            RoleSelectPanel.instance._roleName.text = r.name;
            RoleSelectPanel.instance._roleAvatar.sprite = Resources.Load<Sprite>(r.avatar);
            RoleSelectPanel.instance._roleDescribe.text = r.describe;
            RoleSelectPanel.instance._roleRecordDetail.text = GetRecord(r.record);
        }
    }

    private string GetRecord(int record) {
        string result;
        switch (record) {
            case -1:
                result =  "尚无记录";
                break;
            default:
                result = $"通关危险{record}";
                break;
        }
        return result;
    }


    public void setData(RoleData roleData)
    {
        this._roleData = roleData;
        if (roleData.unlock == 0)
        {
            _avatar.sprite = Resources.Load<Sprite>("Image/UI/锁");
        }
        else 
        {
            _avatar.sprite = Resources.Load<Sprite>(roleData.avatar);
        }
        _button.onClick.AddListener(() => {
            ButtonClick(roleData);
        });
    }

    public void ButtonClick(RoleData roleData)
    {
        if (roleData.unlock == 0) {
            return;
        }
        // 记录角色选择信息
        GameManager.instance.setRoleData(roleData);

        // 隐藏 RoleSelectPanel
        RoleSelectPanel.instance._canvasGroup.alpha = 0;
        RoleSelectPanel.instance._canvasGroup.blocksRaycasts = false;
        RoleSelectPanel.instance._canvasGroup.interactable = false;

        // 显示WeaponSelectPanel
        WeaponSelectPanel.instance._canvasGroup.alpha = 1;
        WeaponSelectPanel.instance._canvasGroup.blocksRaycasts = true;
        WeaponSelectPanel.instance._canvasGroup.interactable = true;

        // 克隆角色显示ui
        GameObject go = Instantiate(RoleSelectPanel.instance._roleDetails, WeaponSelectPanel.instance._WeaponContent);
        go.transform.SetSiblingIndex(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
