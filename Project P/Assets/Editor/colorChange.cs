using UnityEditor;
using UnityEngine;

public class ChangeChildrenColor : EditorWindow
{
    [MenuItem("Tools/Change Level Items Color")]
    public static void ChangeLevelItemsColor()
    {
        GameObject levelParent = GameObject.Find("Level");

        if (levelParent == null)
        {
            Debug.LogError("No GameObject named 'Level' found in the scene.");
            return;
        }

        foreach (Transform child in levelParent.transform)
        {
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                // Modify the prefab's shared material
                Undo.RecordObject(renderer.sharedMaterial, "Change Material Color");
                renderer.sharedMaterial.color = Color.yellow;
                EditorUtility.SetDirty(renderer.sharedMaterial); // Mark it as dirty to save changes
            }
        }

        Debug.Log("All items under 'Level' turned yellow, changes applied to prefabs.");
    }
}
