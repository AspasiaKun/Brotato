public class Enemy2: EnemyBase {
    void Start() {
        EnemyData enemy2Data = GameManager.instance.enemyDatas[1];

        id = enemy2Data.id;
        name = enemy2Data.name;
        hp = enemy2Data.hp;
        damage = enemy2Data.damage;
        speed = enemy2Data.speed;
        attackInternal = enemy2Data.attackTime;
        provideExp = enemy2Data.provideExp;
        skillTime = enemy2Data.skillTime;
        range = enemy2Data.range;
    }
}