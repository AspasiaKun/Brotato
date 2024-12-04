using System;

[Serializable]
public class WeaponData
{
    public int id;
    public string name;
    public string avatar;
    public int price;
    public float damage;
    public int isLong; // 0 近战 1 远程
    public int range;
    public float critical_strikes_multiple; // 暴击倍数
    public float critical_strikes_probability; // 暴击概率
    public float cooling;
    public int repel; // 击退
    public string describe;
}
