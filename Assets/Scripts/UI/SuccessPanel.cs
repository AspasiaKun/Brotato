using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

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
    private GameObject propPrefab;
    private Transform propLevelUpParent;
    UpgradePropsManager propManager = new UpgradePropsManager();
    GameObject prop_1;
    GameObject prop_2;
    GameObject prop_3;
    GameObject prop_4;
    Button refreshButton;
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

        refreshButton = Utils.Instance.findGameObject("RefreshButton").GetComponent<Button>();
        propPrefab = Resources.Load<GameObject>("Prefabs/Prop_1");
        propLevelUpParent = Utils.Instance.findGameObject("PropLevelUp").transform;
        // 添加升级属性
        propManager.AddUpgradeProp(new UpgradeProps(
            "心脏",
            "最大生命值",
            "Image/其他/Max_HP_Upgrade",
            rarity => {
                return rarity switch {
                    Rarity.Common => 3,
                    Rarity.Rare => 6,
                    Rarity.Epic => 9,
                    Rarity.Legendary => 12,
                    _ => 0
                };
            }));
        propManager.AddUpgradeProp(new UpgradeProps(
            "肺" ,
            "生命再生",
            "Image/其他/HP_Regeneration_Upgrade",
            rarity => {
                return rarity switch {
                    Rarity.Common => 2,
                    Rarity.Rare => 3,
                    Rarity.Epic => 4,
                    Rarity.Legendary => 5,
                    _ => 0
                };
            }
        ));
        propManager.AddUpgradeProp(new UpgradeProps(
            "牙齿" ,
            "生命窃取",
            "Image/其他/Life_Steal_Upgrade",
            rarity => {
                return rarity switch {
                    Rarity.Common => 1,
                    Rarity.Rare => 2,
                    Rarity.Epic => 3,
                    Rarity.Legendary => 4,
                    _ => 0
                };
            }
        ));
        propManager.AddUpgradeProp(new UpgradeProps(
            "上臂" ,
            "伤害",
            "Image/其他/Damage_Upgrade",
            rarity => {
                return rarity switch {
                    Rarity.Common => 5,
                    Rarity.Rare => 8,
                    Rarity.Epic => 12,
                    Rarity.Legendary => 16,
                    _ => 0
                };
            }
        ));
        propManager.AddUpgradeProp(new UpgradeProps(
            "前臂" ,
            "近战伤害",
            "Image/其他/Melee_Damage_Upgrade",
            rarity => {
                return rarity switch {
                    Rarity.Common => 2,
                    Rarity.Rare => 4,
                    Rarity.Epic => 6,
                    Rarity.Legendary => 8,
                    _ => 0
                };
            }
        ));
        propManager.AddUpgradeProp(new UpgradeProps(
            "肩膀" ,
            "远程伤害",
            "Image/其他/Ranged_Damage_Upgrade",
            rarity => {
                return rarity switch {
                    Rarity.Common => 1,
                    Rarity.Rare => 2,
                    Rarity.Epic => 3,
                    Rarity.Legendary => 4,
                    _ => 0
                };
            }
        ));
        propManager.AddUpgradeProp(new UpgradeProps(
            "大脑" ,
            "元素伤害",
            "Image/其他/Elemental_Damage_Upgrade",
            rarity => {
                return rarity switch {
                    Rarity.Common => 1,
                    Rarity.Rare => 2,
                    Rarity.Epic => 3,
                    Rarity.Legendary => 4,
                    _ => 0
                };
            }
        ));
        propManager.AddUpgradeProp(new UpgradeProps(
            "反应" ,
            "攻击速度",
            "Image/其他/Attack_Speed_Upgrade",
            rarity => {
                return rarity switch {
                    Rarity.Common => 5,
                    Rarity.Rare => 10,
                    Rarity.Epic => 15,
                    Rarity.Legendary => 20,
                    _ => 0
                };
            }
        ));
        propManager.AddUpgradeProp(new UpgradeProps(
            "手指" ,
            "暴击率",
            "Image/其他/Crit_Chance_Upgrade",
            rarity => {
                return rarity switch {
                    Rarity.Common => 3,
                    Rarity.Rare => 5,
                    Rarity.Epic => 7,
                    Rarity.Legendary => 9,
                    _ => 0
                };
            }
        ));
        propManager.AddUpgradeProp(new UpgradeProps(
            "头骨" ,
            "工程学",
            "Image/其他/Engineering_Upgrade",
            rarity => {
                return rarity switch {
                    Rarity.Common => 2,
                    Rarity.Rare => 3,
                    Rarity.Epic => 4,
                    Rarity.Legendary => 5,
                    _ => 0
                };
            }
        ));
        propManager.AddUpgradeProp(new UpgradeProps(
            "眼睛" ,
            "范围",
            "Image/其他/Range_Upgrade",
            rarity => {
                return rarity switch {
                    Rarity.Common => 15,
                    Rarity.Rare => 30,
                    Rarity.Epic => 45,
                    Rarity.Legendary => 60,
                    _ => 0
                };
            }
        ));
        propManager.AddUpgradeProp(new UpgradeProps(
            "胸部" ,
            "护甲",
            "Image/其他/Armor_Upgrade",
            rarity => {
                return rarity switch {
                    Rarity.Common => 1,
                    Rarity.Rare => 2,
                    Rarity.Epic => 3,
                    Rarity.Legendary => 4,
                    _ => 0
                };
            }
        ));
        propManager.AddUpgradeProp(new UpgradeProps(
            "背部" ,
            "闪避",
            "Image/其他/Dodge_Upgrade",
            rarity => {
                return rarity switch {
                    Rarity.Common => 3,
                    Rarity.Rare => 6,
                    Rarity.Epic => 9,
                    Rarity.Legendary => 12,
                    _ => 0
                };
            }
        ));
        propManager.AddUpgradeProp(new UpgradeProps(
            "腿部" ,
            "速度",
            "Image/其他/Speed_Upgrade",
            rarity => {
                return rarity switch {
                    Rarity.Common => 3,
                    Rarity.Rare => 6,
                    Rarity.Epic => 9,
                    Rarity.Legendary => 12,
                    _ => 0
                };
            }
        ));
        propManager.AddUpgradeProp(new UpgradeProps(
            "鼻子" ,
            "幸运",
            "Image/其他/Luck_Upgrade",
            rarity => {
                return rarity switch {
                    Rarity.Common => 5,
                    Rarity.Rare => 10,
                    Rarity.Epic => 15,
                    Rarity.Legendary => 20,
                    _ => 0
                };
            }
        ));
        propManager.AddUpgradeProp(new UpgradeProps(
            "手掌" ,
            "收获",
            "Image/其他/Harvesting_Upgrade",
            rarity => {
                return rarity switch {
                    Rarity.Common => 5,
                    Rarity.Rare => 8,
                    Rarity.Epic => 10,
                    Rarity.Legendary => 12,
                    _ => 0
                };
            }
        ));
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
        refreshButton.onClick.AddListener( () => {
            showRandomProps();
        });
        prop_1 = Instantiate(propPrefab, propLevelUpParent);
        prop_2 = Instantiate(propPrefab, propLevelUpParent);
        prop_3 = Instantiate(propPrefab, propLevelUpParent);
        prop_4 = Instantiate(propPrefab, propLevelUpParent);
        // 随机仅改变四个实体的属性值，因此四个实体可以先生成，便于后续刷新
        showRandomProps();

    }

    void Update() {
        
    }

    public void showRandomProps() {
        // 获取随机属性
        List<UpgradeProps> randomPropsList = propManager.GetRandomProps(4);
        
        // 修改每一个GO的显示ui
        UpdatePropUI(prop_1, randomPropsList[0]);
        UpdatePropUI(prop_2, randomPropsList[1]);
        UpdatePropUI(prop_3, randomPropsList[2]);
        UpdatePropUI(prop_4, randomPropsList[3]);
    }

    private void UpdatePropUI(GameObject prop, UpgradeProps upgradeProps)
    {
        Image prop_bg = prop.GetComponent<Image>();
        Image avatarBg = prop.transform.Find("Avatar").transform.Find("Avatar_BG").GetComponent<Image>();
        TextMeshProUGUI propName = prop.transform.Find("Prop_Name").GetComponent<TextMeshProUGUI>();
        // 修改选项背景与图标背景色，名字也需要修改，颜色与后缀
        switch(upgradeProps._rarity) {
            case Rarity.Common:
                prop_bg.color = new Color(116/255f,116/255f,116/255f);
                avatarBg.color = new Color(55/255f, 55/255f, 55/255f);
                propName.text = upgradeProps._name;
                propName.color = new Color(200/255f,200/255f,200/255f);
                break;
            case Rarity.Rare:
                prop_bg.color = new Color(57/255f,93/255f,122/255f);
                avatarBg.color = new Color(43/255f, 55/255f, 61/255f);
                propName.text = upgradeProps._name + " II";
                propName.color = new Color(95/255f,153/255f,204/255f);
                break;
            case Rarity.Epic:
                prop_bg.color = new Color(88/255f,52/255f,137/255f);
                avatarBg.color = new Color(39/255f, 35/255f, 49/255f);
                propName.text = upgradeProps._name + " III";
                propName.color = new Color(162/255f,94/255f,246/255f);
                break;
            case Rarity.Legendary:
                prop_bg.color = new Color(134/255f,44/255f,40/255f);
                avatarBg.color = new Color(56/255f, 36/255f, 35/255f);
                propName.text = upgradeProps._name + " IV";
                propName.color = new Color(235/255f, 78/255f, 69/255f);
                break;
        }
        // 修改图标
        Image avatar = prop.transform.Find("Avatar").transform.Find("Avatar_Prop").GetComponent<Image>();
        avatar.sprite = Resources.Load<Sprite>(upgradeProps._iconPath);

    }
}