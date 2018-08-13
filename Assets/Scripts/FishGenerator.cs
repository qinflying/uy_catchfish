using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour {
    //鱼的挂靠点
    public Transform m_FishPanel;
    //地点列表
    public RectTransform[] m_GeneratePositions;
    //鱼的预制体
    public GameObject[] m_FishPrefabs;

	void Start () {
        InvokeRepeating("ToGenerate", 0, 1);
	}

    void ToGenerate() { 
    
    }
}
