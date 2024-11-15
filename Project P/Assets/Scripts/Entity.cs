using UnityEngine;

public class Entity : MonoBehaviour
{
    // This class acts as a tag or marker for portal objects
    void Start()
    {
        Debug.Log("Entity script attached to: " + gameObject.name);
    }
}
