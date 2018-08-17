using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingNet : MonoBehaviour {
    //伤害
    private float _damage;

    public void setDamage(float damage) {
        _damage = damage;
    }
    
    public void OnNetAcitonEnd() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == ComDefine.Tag_Fish) {
            collision.SendMessage("TakeDamage", _damage);
        }
    }
}
