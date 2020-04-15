using UnityEngine;
using UnityEditor;

public class ModelWindowScript : EditorWindow
{
    [MenuItem("Window/3D Models")]

    public static void ShadowWindow()
    {
        EditorWindow.GetWindow<ModelWindowScript>("3D Models");
    }

    void OnGUI()
    {
        GUILayout.Label("Choose your model to spawn", EditorStyles.boldLabel);
        
        if (GUILayout.Button("Tree"))
        {
            Camera.main.GetComponent<Instantiator>().spawnTree();
        }

        if (GUILayout.Button("Grass"))
        {
            Camera.main.GetComponent<Instantiator>().spawnGrass();
        }

        if (GUILayout.Button("Rock"))
        {
            Camera.main.GetComponent<Instantiator>().spawnRock();
        }

        if (GUILayout.Button("Mushroom"))
        {
            Camera.main.GetComponent<Instantiator>().spawnMushroom();
        }
    }
}
