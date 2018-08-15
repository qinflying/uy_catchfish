using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttr : MonoBehaviour
{
    public float m_MoveMaxDis = 5.0f;
    private Vector3 m_InitPosition;
    private bool m_IsInit = false;

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
        GameObject oCodeHandler = GameObject.Find(ComDefine.CodeHandler);
        if (oCodeHandler) {
            GameObject oFishNetPrefab = oCodeHandler.GetComponent<ManyHandler>().m_FishingNet;
            if (oFishNetPrefab != null) {
                Debug.Log("FishingNet");
                GameObject oFishingNet = Instantiate(oFishNetPrefab);
                oFishingNet.transform.SetParent(transform.parent);
                oFishingNet.transform.localPosition = transform.localPosition;
            }
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == ComDefine.Tag_Fish) {
            CatchFish();
        }
    }
}
