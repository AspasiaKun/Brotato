public class Enemy3: EnemyBase {
    void Start() {
        EnemyData enemy3Data = GameManager.instance.enemyDatas[2];

        id = enemy3Data.id;
        name = enemy3Data.name;
        hp = enemy3Data.hp;
        damage = enemy3Data.damage;
        speed = enemy3Data.speed;
        attackInternal = enemy3Data.attackTime;
        provideExp = enemy3Data.provideExp;
        skillTime = enemy3Data.skillTime;
        range = enemy3Data.range;
    }
}