using UnityEditor;
using UnityEngine;

public class AddCollidersToPrefabs : MonoBehaviour
{
    [MenuItem("Tools/Add Colliders to Level Objects")]
    public static void AddColliders()
    {
        GameObject selectedLevel = Selection.activeGameObject;

        if (selectedLevel == null)
        {
            Debug.LogError("Please select a GameObject!");
            return;
        }

        Transform[] allObjects = selectedLevel.GetComponentsInChildren<Transform>();

        foreach (Transform obj in allObjects)
        {
            if (obj.CompareTag("Door"))
                continue;

            if (PrefabUtility.IsPartOfAnyPrefab(obj.gameObject))
            {
                // Modify the prefab instance
                GameObject prefabRoot = PrefabUtility.GetNearestPrefabInstanceRoot(obj.gameObject);
                if (prefabRoot != null)
                {
                    PrefabUtility.UnpackPrefabInstance(prefabRoot, PrefabUnpackMode.Completely, InteractionMode.UserAction);
                }
            }

            // Add Collider if none exists
            if (obj.GetComponent<Collider>() == null)
            {
                obj.gameObject.AddComponent<BoxCollider>();
            }
        }

        Debug.Log("Colliders added to objects, including prefab instances!");
    }
}
