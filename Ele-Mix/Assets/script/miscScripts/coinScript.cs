using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class coinScript : MonoBehaviour
{
    private void Start() {
        SphereCollider coinCollider = GetComponent<SphereCollider>();
        coinCollider.radius = 3f;
        coinCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }

    private void OnDestroy() {
        playerItems.instance.coinCount++;
    }
}
