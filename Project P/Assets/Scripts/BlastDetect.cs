using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class BlastDetect : MonoBehaviour
{
    public GameObject User;
    public GameObject Item;
    public float range;
    public float speed;
    public Transform PlayerCam;
    void Start()
    {
        PlayerCam = Camera.main.transform;
    }
    public void Shoot()
    {
        Ray toolRay = new Ray(PlayerCam.position, PlayerCam.forward);
        if(Physics.Raycast(toolRay, out RaycastHit hitInfo, range)){
            if(hitInfo.collider.gameObject.TryGetComponent(out Entity portals)){
                Item.transform.position = Vector3.MoveTowards(Item.transform.position, User.transform.position, speed)
                
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
