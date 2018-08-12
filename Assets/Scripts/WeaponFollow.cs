using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollow : MonoBehaviour {
    public RectTransform m_UGUICanvas;
    public Camera m_RenderCamera;

	void Start () {

	}

	void Update () {
        Vector3 worldPoint = new Vector3();
        Vector2 screenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        float dAngle = 0.0f;
        //坐标转换
        RectTransformUtility.ScreenPointToWorldPointInRectangle(m_UGUICanvas, screenPoint, m_RenderCamera, out worldPoint);
        if (transform.position.x >= worldPoint.x)
        {
            dAngle = Vector3.Angle(Vector3.up, worldPoint - transform.position);
        }
        else {
            dAngle = -Vector3.Angle(Vector3.up, worldPoint - transform.position);
        }

        transform.localRotation = Quaternion.Euler(0, 0, dAngle);

    }
}