using UnityEngine;
using UnityEditor;

public class ParticularlyProfessionalParenting : EditorWindow {

    public GameObject professionalParent;

    [MenuItem("Window/Particularly Powerful Professional Parenter")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<ParticularlyProfessionalParenting>("Particularly Powerful Professional Parenter");
    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Professional Parent:", EditorStyles.boldLabel);
        professionalParent = (GameObject)EditorGUILayout.ObjectField(professionalParent, typeof(GameObject), true);
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Produce Particularly Powerful Parent"))
        {
            Parent();
        }
    }

    void Parent()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            obj.transform.SetParent(professionalParent.transform);
        }
    }
}
