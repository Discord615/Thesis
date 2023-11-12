using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerItems : MonoBehaviour
{
    public static playerItems instance { get; private set; }

    private void Awake() {
        if (instance != null){
            Debug.LogError(string.Format("More than one instance of {0} in current scene", instance.name));
        }
        instance = this;
    }

    public int coinCount = 0;
}
