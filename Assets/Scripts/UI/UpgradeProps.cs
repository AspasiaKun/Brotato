using System;

public enum Rarity {
    Common, // Tier 1
    Rare, // Tire 2
    Epic, // Tire 3
    Legendary // Tire 4
}

public class UpgradeProps {
    public string _name;
    public string _description;
    public string _iconPath;
    public Rarity _rarity;
    public Func<Rarity, int> _getValue;

    public UpgradeProps(string name, string description, string iconPath, Func<Rarity, int> getValue) 
    {
        _name = name;
        _description = description;
        _iconPath = iconPath;
        _getValue = getValue;
    }

    public string GetDetailedDescription() {
        return _description;
    }

}