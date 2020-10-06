using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
[CanEditMultipleObjects]
public class TeleportAreaDrawer : Editor
{
    static bool isDrawingArea = false;

    private void Awake()
    {
        Debug.Log("Yos");
    }

    private void OnSceneGUI()
    {
        Debug.Log("Yos");
    }

    static TeleportAreaDrawer()
    {
        /*SceneView.duringSceneGui -= OnSceneGUI;
        SceneView.duringSceneGui += OnSceneGUI;*/
    }

    static void OnSceneGUI(SceneView sceneView)
    {
        if (Event.current.type == EventType.KeyUp)
        {
            if (Event.current.keyCode == KeyCode.B)
            {
                sceneView = SceneView.sceneViews[0] as SceneView;
                sceneView.in2DMode = true;
            }
        }

        if (Event.current.button == 1 && Event.current.type == EventType.MouseDown)
        {
            GenericMenu genericMenu = new GenericMenu();

            genericMenu.AddDisabledItem(new GUIContent("Teleport Area Drawer"));
            genericMenu.AddItem(new GUIContent("Draw Area"), isDrawingArea, CustomCallback);

            genericMenu.ShowAsContext();
        }
    }

    static void CustomCallback()
    {
        isDrawingArea = !isDrawingArea;
    }
}
