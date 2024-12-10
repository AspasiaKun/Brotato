using System.Linq;
using System.Collections.Generic;
using System;

public class UpgradePropsManager {
    private static readonly UpgradePropsManager _instance = new UpgradePropsManager();
    private UpgradePropsManager() {}
    public static UpgradePropsManager Instance => _instance;
    private List<UpgradeProps> upgradePropsList = new List<UpgradeProps>();

    public void AddUpgradeProp(UpgradeProps props) {
        upgradePropsList.Add(props);
    }

    // 从所有属性列表中取出指定数量的随机属性
    public List<UpgradeProps> GetRandomProps(int count, int currentLevel) {
        Random random = new Random();
        return upgradePropsList
            .OrderBy(x => random.Next())
            .Take(count)
            .Select(prop =>
            {
                // 根据当前等级来对稀有度进行随机
                if (currentLevel == 1){
                    // 当前等级为1时，4个选项均为tier 1
                    prop._rarity = (Rarity)0;
                    return prop;
                } else if (currentLevel == 5) {
                    prop._rarity = (Rarity)1;
                    return prop;
                } else if (currentLevel == 10) {
                    prop._rarity = (Rarity)2;
                    return prop;
                } else if (currentLevel == 15) {
                    prop._rarity = (Rarity)2;
                    return prop;
                } else if (currentLevel == 20) {
                    prop._rarity = (Rarity)2;
                    return prop;
                } else if (currentLevel >= 25 && currentLevel % 5 ==0) {
                    prop._rarity = (Rarity)3;
                    return prop;
                }

                float[] rarityChances = new float[4];
                rarityChances[0] = CalculateChance(currentLevel,1, 100, 0, 100);
                rarityChances[1] = CalculateChance(currentLevel,1, 0, 6, 60);
                rarityChances[2] = CalculateChance(currentLevel,3, 0, 2, 25);
                rarityChances[3] = CalculateChance(currentLevel,7, 0, 0.23f, 8);

                float totalChance = rarityChances.Sum();
                float randomValue = (float)random.NextDouble() * totalChance;
                float cumulative = 0;
                for (int i=0;i<rarityChances.Length;i++) {
                    cumulative += rarityChances[i];
                    if (randomValue <= cumulative) {
                        prop._rarity = (Rarity)i;
                        break;
                    }
                }
                
                return prop;
            }).ToList();
    }

    private float CalculateChance(int currentLevel, int minLevel, float baseChance, float chancePerLevel, float maxChance)
    {
        if (currentLevel < minLevel) {
            return 0;
        }
        float chance = ((chancePerLevel * (currentLevel - minLevel))+baseChance) * (1 + Player.instance.playerProp.luck / 100);
        return MathF.Max(chance, maxChance);
    }
}