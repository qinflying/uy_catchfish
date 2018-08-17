using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttr : MonoBehaviour
{
    public float m_MoveMaxDis = 5.0f;
    public GameObject m_FishingNetPrefab;
    private Vector3 m_InitPosition;
    private bool m_IsInit = false;
    private float _damage;

    public void setDamage(float damage) {
        _damage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsInit)
        {
            float dis = Vector3.Distance(m_InitPosition, transform.position);
            if (dis >= m_MoveMaxDis)
            {
                CatchFish();
            }
        }
    }

    public void InitPosition()
    {
        m_IsInit = true;
        m_InitPosition = transform.position;
    }

    private void CatchFish()
    {
        if (m_FishingNetPrefab != null) {
            GameObject oFishingNet = Instantiate(m_FishingNetPrefab);
            oFishingNet.transform.SetParent(transform.parent);
            oFishingNet.transform.localPosition = transform.localPosition;
            oFishingNet.GetComponent<FishingNet>().setDamage(_damage);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == ComDefine.Tag_Fish) {
            CatchFish();
        }
    }
}
