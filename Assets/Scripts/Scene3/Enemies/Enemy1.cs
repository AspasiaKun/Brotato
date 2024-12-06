
public class Enemy1: EnemyBase {
    void Start() {
        EnemyData enemy1Data = GameManager.instance.enemyDatas[0];

        id = enemy1Data.id;
        name = enemy1Data.name;
        hp = enemy1Data.hp;
        damage = enemy1Data.damage;
        speed = enemy1Data.speed;
        attackInternal = enemy1Data.attackTime;
        provideExp = enemy1Data.provideExp;
        skillTime = enemy1Data.skillTime;
        range = enemy1Data.range;
    }
}