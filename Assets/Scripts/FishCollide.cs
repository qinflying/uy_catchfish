using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollide : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D oCollision)
    {
        if (oCollision.tag == ComDefine.Tag_Border)
        {
            Destroy(gameObject);
        }
    }
}
