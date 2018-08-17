using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ef_DelayDestory : MonoBehaviour
{
    public float m_SurvivalTime = 1.0f;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, m_SurvivalTime);
    }

}
