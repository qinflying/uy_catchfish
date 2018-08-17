using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingNet : MonoBehaviour {
    //根据节点创建渔网
    public static GameObject CreateWithRoot(Transform oRoot) {
        GameObject oCodeHandler = GameObject.Find(ComDefine.CodeHandler);
        if (oCodeHandler)
        {
            GameObject oFishNetPrefab = oCodeHandler.GetComponent<ManyHandler>().m_FishingNet;
            if (oFishNetPrefab != null)
            {
                Debug.Log("FishingNet");
                GameObject oFishingNet = Instantiate(oFishNetPrefab);
                oFishingNet.transform.SetParent(oRoot.parent);
                oFishingNet.transform.localPosition = oRoot.localPosition;
                return oFishingNet;
            }
        }
        return null;
    }

    public void OnNetAcitonEnd() {
        Destroy(gameObject);
    }
}
