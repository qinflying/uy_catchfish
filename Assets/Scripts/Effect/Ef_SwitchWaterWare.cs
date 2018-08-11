using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ef_SwitchWaterWare : MonoBehaviour {
    public Texture[] m_WareTextures;
    private Material m_WareMaterial;
    private int m_Index = 0;
	
	void Start () {
        m_WareMaterial = GetComponent<MeshRenderer>().material;
        //定时重复调用方法，延时0s调用，每隔0.1s调用
        InvokeRepeating("SwitchWareTexture", 0, 0.1f);
	}

    private void SwitchWareTexture() {
        int iMax = m_WareTextures.Length;
        if (iMax <= 0) {
            return;
        }
        m_Index += 1;
        if (m_Index >= iMax) {
            m_Index = 0;
        }
        Texture switchtexture = m_WareTextures[m_Index];
        m_WareMaterial.mainTexture = switchtexture;
    }
}
