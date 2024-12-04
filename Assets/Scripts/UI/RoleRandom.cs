using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RoleRandom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image _backImage;
    public Button _button;
    private List<RoleUI> unlockRoleUI = new List<RoleUI>();

    void Awake() {
        _backImage = GetComponent<Image>();
        _button = GetComponent<Button>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _backImage.color = new Color(207/255f, 207/255f, 207/255f);
        RoleSelectPanel.instance._contentCanvasGroup.alpha = 0;
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
        // 需要获取已经解锁的角色列表，再进行随机。
        foreach(RoleUI roleUI in RoleSelectPanel.instance._roleList.GetComponentsInChildren<RoleUI>()) {
            // 将所有已解锁角色加入list
            if (roleUI._roleData.unlock == 1) {
                unlockRoleUI.Add(roleUI);
            }
        }
        RoleUI r = GameManager.instance.RandomInList<RoleUI>(unlockRoleUI) as RoleUI;
        r.RenewUI(r._roleData);
        r.ButtonClick(r._roleData);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
