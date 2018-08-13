using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class FishGenerator : MonoBehaviour {
    //鱼的挂靠点
    public Transform m_FishPanel;
    //地点列表
    public RectTransform[] m_GeneratePositions;
    //鱼的预制体
    public GameObject[] m_FishPrefabs;
    //
    public float fishGenWaitTime = 0.5f;

	void Start () {
        InvokeRepeating("ToGenerate", 0, 1);
	}

    void ToGenerate() {
        int genPosIndex = Random.Range(0, m_GeneratePositions.Length);
        int fishPreIndex = Random.Range(0, m_FishPrefabs.Length);

        GameObject oFishPrefab = m_FishPrefabs[fishPreIndex];
        int nMaxAmout = oFishPrefab.GetComponent<FishAttr>().nMaxAmount;
        float fMaxSpeed = oFishPrefab.GetComponent<FishAttr>().fMaxSpeed;

        int gennum = Random.Range(nMaxAmout / 2 + 1, nMaxAmout);
        float speed = Random.Range(fMaxSpeed/2, fMaxSpeed);

        MoveMode mmode = (MoveMode) Random.Range(0, 2);

        if (mmode == MoveMode.MOVE_DIRECT)
        {
            float angOffset = Random.Range(-22.5f, 22.5f);
            StartCoroutine(GenerateDirectFish(genPosIndex, fishPreIndex, gennum, speed, angOffset));
        }
        else 
        { 
        }
    }

    //协程？
    IEnumerator GenerateDirectFish(int posIndex, int prefabIndex, int num, float speed, float angOffset)
    {
        GameObject oPrefab = m_FishPrefabs[prefabIndex];
        for (int i = 0; i < num; i++) {
            GameObject oFish = Instantiate(oPrefab);
            oFish.transform.SetParent(m_FishPanel, false);
            oFish.transform.localPosition = m_GeneratePositions[posIndex].localPosition;
            oFish.transform.localRotation = m_GeneratePositions[posIndex].localRotation;
            oFish.transform.Rotate(0, 0, angOffset);
            //渲染排序?
            oFish.GetComponent<SpriteRenderer>().sortingOrder += i;
            oFish.AddComponent<Ef_AutoMove>().m_Speed = speed;
            yield return new WaitForSeconds(fishGenWaitTime);
        }
    }
}
