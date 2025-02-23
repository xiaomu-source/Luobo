using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

abstract class Role : ReusbleObject, IReusable
{
    #region 常量
    
    #endregion

    #region 事件
    public event Action<int, int> HpChanged; //血量变化
    public event Action<Role> Dead; //死亡
    #endregion

    #region 字段
    int m_Hp;
    int m_MaxHp;
    #endregion

    #region 属性
    public int Hp
    {
        get { return m_Hp; }
        set
        {
            //范围约定
            value = Mathf.Clamp(value, 0, m_MaxHp);

            //减少重复
            if (value == m_Hp)
                return;

            //赋值
            m_Hp = value;

            //血量变化
            if (HpChanged != null)
                HpChanged(m_Hp, m_MaxHp);

            //死亡事件
            if (Dead != null)
                Dead(this);
        }
    }

    public int MaxHp
    {
        get { return m_MaxHp; }
        set
        {

            if (value < 0)
                value = 0;

            m_MaxHp = value;
        }
    }

    public bool IsDead
    {
        get { return m_Hp == 0; }
    }
    #endregion

    #region 方法
    public virtual void Damage(int hit)
    {
        if (IsDead)
            return;

        Hp -= hit;
    }

    protected virtual void Die(Role role)
    {

    }
    #endregion

    #region Unity回调
    #endregion

    #region 事件回调
    public  override void OnSpawn()
    {
        this.Dead += Die;
    }

    public override void OnUnspawn()
    {
        Hp = 0;
        MaxHp = 0;

        while (HpChanged != null)
            HpChanged -= HpChanged;

        while (Dead != null)
            Dead -= Dead;
    }
    #endregion

    #region 帮助方法
    #endregion
}