using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ef_AutoMove : MonoBehaviour {
    public float m_Speed = 1.0f;
    public Vector3 m_Direct = Vector3.right;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(m_Direct * m_Speed * Time.deltaTime);
	}
}
