using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttr : MonoBehaviour
{
    //发射消耗数组
    public int[] m_ShootCosts;
    public GameObject[] m_Bullets;
    public Transform m_FirePosition;
    public Transform m_BulletPanel;
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

    //初始化枪的最小威力
    public void initMinPower()
    {
        m_Index = 0;
    }

    public void initMaxPower() {
        m_Index = m_ShootCosts.Length - 1;
        m_Index = (m_Index < 0) ? 0 : m_Index;
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

    public void GameFire(int level) {
        int index = level / 10;
        index = (index >= m_Bullets.Length) ? m_Bullets.Length - 1 : index;
        if (index < 0) {
            return;
        }

        GameObject oBulletPrefab = m_Bullets[index];
        GameObject oBullet = Instantiate(oBulletPrefab);
        oBullet.transform.SetParent(m_BulletPanel);
        oBullet.transform.position = m_FirePosition.position;
        oBullet.transform.localRotation = transform.localRotation;

        oBullet.AddComponent<Ef_AutoMove>().m_Speed = 5;
        oBullet.GetComponent<Ef_AutoMove>().m_Direct = Vector3.up;
        BulletAttr oBulletAttr = oBullet.GetComponent<BulletAttr>();
        oBulletAttr.InitPosition();
        oBulletAttr.setDamage(GetCurrentCost());
    }
}
