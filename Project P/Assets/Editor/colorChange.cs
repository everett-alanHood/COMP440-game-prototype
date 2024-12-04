using UnityEditor;
using UnityEngine;

public class ApplyMaterialToChildren : EditorWindow
{
    public Material materialToApply; // The material to apply
    public GameObject parentObject;  // The parent containing children to apply the material to

    [MenuItem("Tools/Apply Material to Children")]
    public static void ShowWindow()
    {
        GetWindow<ApplyMaterialToChildren>("Apply Material");
    }

    private void OnGUI()
    {
        // Input fields for the material and parent object
        GUILayout.Label("Apply Material to Children", EditorStyles.boldLabel);

        materialToApply = (Material)EditorGUILayout.ObjectField("Material", materialToApply, typeof(Material), false);
        parentObject = (GameObject)EditorGUILayout.ObjectField("Parent Object", parentObject, typeof(GameObject), true);

        if (GUILayout.Button("Apply Material"))
        {
            ApplyMaterial();
        }
    }

    private void ApplyMaterial()
    {
        if (materialToApply == null || parentObject == null)
        {
            Debug.LogError("Please assign both a Material and a Parent Object.");
            return;
        }

        // Loop through all children of the parent object
        foreach (Transform child in parentObject.transform)
        {
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                Undo.RecordObject(renderer, "Apply Material"); // Allow Undo
                renderer.sharedMaterial = materialToApply;
            }
        }

        Debug.Log($"Applied {materialToApply.name} to all children of {parentObject.name}.");
    }
}
