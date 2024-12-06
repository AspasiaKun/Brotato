public class Enemy4: EnemyBase {
    void Start() {
        EnemyData enemy4Data = GameManager.instance.enemyDatas[3];

        id = enemy4Data.id;
        name = enemy4Data.name;
        hp = enemy4Data.hp;
        damage = enemy4Data.damage;
        speed = enemy4Data.speed;
        attackInternal = enemy4Data.attackTime;
        provideExp = enemy4Data.provideExp;
        skillTime = enemy4Data.skillTime;
        range = enemy4Data.range;
    }
}