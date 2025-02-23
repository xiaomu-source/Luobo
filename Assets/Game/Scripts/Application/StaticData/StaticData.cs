using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StaticData : Singleton<StaticData>
{
    Dictionary<int, MonsterInfo> m_monsters = new Dictionary<int, MonsterInfo>();

    protected override void Awake()
    {
        base.Awake();

        InitMonsters();
        InitTowers();
        InitBullets();
    }

    void InitMonsters()
    {
        m_monsters.Add(0, new MonsterInfo() { Hp = 1, MoveSpeed = 1.5f });
        m_monsters.Add(1, new MonsterInfo() { Hp = 2, MoveSpeed = 1f });
        m_monsters.Add(2, new MonsterInfo() { Hp = 5, MoveSpeed = 1f });
        m_monsters.Add(3, new MonsterInfo() { Hp = 10, MoveSpeed = 1f });
        m_monsters.Add(4, new MonsterInfo() { Hp = 10, MoveSpeed = 1f });
        m_monsters.Add(5, new MonsterInfo() { Hp = 100, MoveSpeed = 0.5f });
    }

    public MonsterInfo GetMonsterInfo(int monsterType)
    {
        return m_monsters[monsterType];
    }

    void InitTowers()
    {

    }

    void InitBullets()
    {

    }
}