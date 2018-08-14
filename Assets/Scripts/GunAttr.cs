using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttr : MonoBehaviour
{
    //发射消耗数组
    public int[] m_ShootCosts;
    private int m_Index = 0;

    //枪处于最大火力
    public bool isMaxPower()
    {
        return m_Index + 1 >= m_ShootCosts.Length;
    }

    //枪处于最大小力
    public bool isMinPower()
    {
        return m_Index == 0;
    }

    //初始化枪的威力
    public void initPower()
    {
        m_Index = 0;
    }

    //增加火力
    public bool AddPower()
    {
        if (m_Index + 1 < m_ShootCosts.Length)
        {
            m_Index++;
            return true;
        }
        return false;
    }

    //减少火力
    public bool MinusPower()
    {
        if (m_Index >= 1)
        {
            m_Index--;
            return true;
        }
        return false;
    }

    //获取当前花费
    public int GetCurrentCost()
    {
        if (m_Index >= 0 && m_Index < m_ShootCosts.Length)
        {
            return m_ShootCosts[m_Index];
        }
        return 0;
    }

    public int powerLevel {
        get {
            return m_ShootCosts.Length;
        }
    }
}
