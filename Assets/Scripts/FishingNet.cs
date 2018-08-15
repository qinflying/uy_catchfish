using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingNet : MonoBehaviour {
    public void OnNetAcitonEnd() {
        Destroy(gameObject);
    }
}
