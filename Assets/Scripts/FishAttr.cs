using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAttr : MonoBehaviour {
    public int nMaxAmount;      //最大数量
    public float fMaxSpeed;     //最大速度
    public float m_HP = 100;
    //死亡预制体
    public GameObject m_DiePrefab;

    public void TakeDamage(float damage) {
        m_HP -= damage;
        if (m_HP <= 0) {
            m_HP = 0;
            PlayDieEffect();
            Destroy(gameObject);
        }
    }

    private void PlayDieEffect() {
        if (m_DiePrefab != null) {
            GameObject oDieEffect = Instantiate(m_DiePrefab);
            oDieEffect.transform.SetParent(transform.parent, false);
            oDieEffect.transform.position = transform.position;
            oDieEffect.transform.rotation = transform.rotation;
            Destroy(oDieEffect, 3);
        }
    }
}
