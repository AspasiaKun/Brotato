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
    public List<UpgradeProps> GetRandomProps(int count) {
        Random random = new Random();
        return upgradePropsList
            .OrderBy(x => random.Next())
            .Take(count)
            .Select(prop =>
            {
                prop._rarity = (Rarity)random.Next(Enum.GetValues(typeof(Rarity)).Length);
                return prop;
            }).ToList();
    }
}