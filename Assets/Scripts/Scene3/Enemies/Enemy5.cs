public class Enemy5: EnemyBase {
    void Start() {
        EnemyData enemy5Data = GameManager.instance.enemyDatas[4];

        id = enemy5Data.id;
        name = enemy5Data.name;
        hp = enemy5Data.hp;
        damage = enemy5Data.damage;
        speed = enemy5Data.speed;
        attackInternal = enemy5Data.attackTime;
        provideExp = enemy5Data.provideExp;
        skillTime = enemy5Data.skillTime;
        range = enemy5Data.range;
    }
}