using UnityEngine;
using System.Collections;

public class Spawner : View
{
    #region 常量
    #endregion

    #region 事件
    #endregion

    #region 字段
    Map m_Map = null;
    #endregion

    #region 属性
    public override string Name
    {
        get { return Consts.V_Spanwner; }
    }
    #endregion

    #region 方法
    public void Spawn(int MonsterType)
    {
        //创建怪物
        string prefabName = "Monster" + MonsterType;
        GameObject go = Game.Instance.ObjectPool.Spawn(prefabName);
        Monster monster = go.GetComponent<Monster>();
        monster.Reached += monster_Reached;
        monster.HpChanged += monster_HpChanged;
        monster.Dead += monster_Dead;
        monster.Load(m_Map.Path);
    }

    void monster_HpChanged(int arg1, int arg2)
    {

    }

    void monster_Dead(Role obj)
    {
    }

    void monster_Reached(Monster monster)
    {
        Game.Instance.ObjectPool.Unspawn(monster.gameObject);
    }

    #endregion

    #region Unity回调
    #endregion

    #region 事件回调
    public override void RegisterEvents()
    {
        AttentionEvents.Add(Consts.E_EnterScene);
        AttentionEvents.Add(Consts.E_SpawnMonster);
    }

    public override void HandleEvent(string eventName, object data)
    {
        switch (eventName)
        {
            case Consts.E_EnterScene:
                SceneArgs e0 = data as SceneArgs;
                if (e0.SceneIndex == 3)
                {
                    m_Map = GetComponent<Map>();

                    //获取数据
                    GameModel gModel = GetModel<GameModel>();
                    m_Map.LoadLevel(gModel.PlayLevel);
                }
                break;
            case Consts.E_SpawnMonster:
                SpawnMonsterArgs e1 = data as SpawnMonsterArgs;
                Spawn(e1.MonsterType);
                break;
        }
    }
    #endregion

    #region 帮助方法
    #endregion
}
