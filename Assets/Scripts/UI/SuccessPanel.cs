using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class SuccessPanel: MonoBehaviour {
    public static SuccessPanel instance;
    public PlayerProp playerProp;
    private GameObject levelItem;
    private GameObject maxhpItem;
    private GameObject lifeRegenItem;
    private GameObject lifeStealItem;
    private GameObject damageItem;
    private GameObject shortDamageItem;
    private GameObject longDamageItem;
    private GameObject elementDamageItem;
    private GameObject attackSpeedItem;
    private GameObject criticalRateItem;
    private GameObject engineerItem;
    private GameObject rangeItem;
    private GameObject armorItem;
    private GameObject evasionItem;
    private GameObject speedItem;
    private GameObject luckItem;
    private GameObject harvestItem;
    void Awake() {
        instance = this;

        levelItem = Utils.Instance.findGameObject("LevelItem");
        maxhpItem = Utils.Instance.findGameObject("MaxhpItem");
        lifeRegenItem = Utils.Instance.findGameObject("LifeRegenItem");
        lifeStealItem = Utils.Instance.findGameObject("LifeStealItem");
        damageItem = Utils.Instance.findGameObject("DamageItem");
        shortDamageItem = Utils.Instance.findGameObject("ShortDamageItem");
        longDamageItem = Utils.Instance.findGameObject("LongDamageItem");
        elementDamageItem = Utils.Instance.findGameObject("ElementDamageItem");
        attackSpeedItem = Utils.Instance.findGameObject("AttackSpeedItem");
        criticalRateItem = Utils.Instance.findGameObject("CriticalRateItem");
        engineerItem = Utils.Instance.findGameObject("EngineerItem");
        rangeItem = Utils.Instance.findGameObject("RangeItem");
        armorItem = Utils.Instance.findGameObject("ArmorItem");
        evasionItem = Utils.Instance.findGameObject("EvasionItem");
        speedItem = Utils.Instance.findGameObject("SpeedItem");
        luckItem = Utils.Instance.findGameObject("LuckItem");
        harvestItem = Utils.Instance.findGameObject("HarvestItem");

    }

    private void UpdateUI(string propertyName, object value)
    {
        Debug.Log("shit!");
        switch (propertyName) {
            case nameof(playerProp.level):
                SetPropUI(levelItem, (float)value, 0); // 不同属性的基础阈值不一样，超过才显示绿色，不足显示红色
                break;
            case nameof(playerProp.maxHp):
                SetPropUI(maxhpItem, (float)value, 10);
                break;
            case nameof(playerProp.lifeRegen):
                SetPropUI(lifeRegenItem, (float)value, 0);
                break;
            case nameof(playerProp.lifeStealPercent):
                SetPropUI(lifeStealItem, (float)value, 0);
                break;
            case nameof(playerProp.damagePercent):
                SetPropUI(damageItem, (float)value, 0);
                break;
            case nameof(playerProp.shortDamage):
                SetPropUI(shortDamageItem, (float)value, 0);
                break;
            case nameof(playerProp.longDamage):
                SetPropUI(longDamageItem, (float)value, 0);
                break;
            case nameof(playerProp.elementDamage):
                SetPropUI(elementDamageItem, (float)value, 0);
                break;
            case nameof(playerProp.attackSpeedPercent):
                SetPropUI(attackSpeedItem, (float)value, 0);
                break;
            case nameof(playerProp.criticalRate):
                SetPropUI(criticalRateItem, (float)value, 0);
                break;
            case nameof(playerProp.engineering):
                SetPropUI(engineerItem, (float)value, 0);
                break;
            case nameof(playerProp.range):
                SetPropUI(rangeItem, (float)value, 0);
                break;
            case nameof(playerProp.armor):
                SetPropUI(armorItem, (float)value, 0);
                break;
            case nameof(playerProp.evasionPercent):
                SetPropUI(evasionItem, (float)value, 0);
                break;
            case nameof(playerProp.speedPercent):
                SetPropUI(speedItem, (float)value, 0);
                break;
            case nameof(playerProp.luck):
                SetPropUI(luckItem, (float)value, 0);
                break;
            case nameof(playerProp.harvest):
                SetPropUI(harvestItem, (float)value, 0);
                break;
        }
    }

    private void SetPropUI(GameObject go, float value, int threshold) {
        TextMeshProUGUI propName = go.transform.Find("PropName").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI propNum = go.transform.Find("PropNum").GetComponent<TextMeshProUGUI>();
        propNum.text = value.ToString();
        if ((int)value < threshold) {
            propName.color = Color.red;
            propNum.color = Color.red;
        }
        else if ((int)value > threshold) {
            propName.color = Color.green;
            propNum.color = Color.green;
        } else {
            propName.color = Color.white;
            propNum.color = Color.white;
        }
    }

    void Start() {
        playerProp = Player.instance.playerProp;
        playerProp.OnPropertyChanged += UpdateUI;
    }

    void Update() {

    }
}