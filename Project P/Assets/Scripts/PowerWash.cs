using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerWash : MonoBehaviour
{
    public UnityEvent onShoot;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButton(1)){
            onShoot?.Invoke();
        }
    }
}
