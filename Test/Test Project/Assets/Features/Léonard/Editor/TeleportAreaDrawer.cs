using UnityEngine;
using UnityEditor;
using System;

[InitializeOnLoad]
[CanEditMultipleObjects]
public class TeleportAreaDrawer : Editor
{
    static bool isDrawingArea = false, isInDrawMode = false;
    static string debugText = "Yeet";
    static GUIStyle style = new GUIStyle();

    static TeleportAreaDrawer()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
        SceneView.duringSceneGui += OnSceneGUI;
    }

    static void OnSceneGUI(SceneView sceneView)
    {
        Handles.BeginGUI();
        Rect rect = new Rect(sceneView.camera.pixelWidth * 0.5f, -sceneView.camera.pixelHeight * 0.45f, sceneView.camera.pixelWidth, -sceneView.camera.pixelHeight);
        rect.size = new Vector2(sceneView.camera.pixelWidth, sceneView.camera.pixelHeight);
        GUI.Label(rect, new GUIContent(debugText, null, null));

        if (Event.current.type == EventType.KeyUp)
        {
            if (Event.current.keyCode == KeyCode.B)
            {
                sceneView.orthographic = !isInDrawMode;
                Vector3 position = SceneView.lastActiveSceneView.pivot;
                if (!isInDrawMode)
                {
                    sceneView.LookAt(position, Quaternion.Euler(90, 0, 0));
                    style.normal.textColor = Color.green;
                    debugText = "You are in Draw Mode";
                }
                else
                {
                    debugText = "Yeet";
                    sceneView.LookAt(position, Quaternion.Euler(15, 45, 0));
                }

                isInDrawMode = !isInDrawMode;
            }
        }

        if (Event.current.button == 1 && Event.current.type == EventType.MouseDown && isInDrawMode)
        {
            GenericMenu genericMenu = new GenericMenu();

            genericMenu.AddDisabledItem(new GUIContent("Teleport Area Drawer"));
            genericMenu.AddItem(new GUIContent("Draw Area"), isDrawingArea, CustomCallback, "DrawingArea");

            genericMenu.ShowAsContext();
        }

    }

    static void CustomCallback(object callback)
    {
        if (callback as string == "DrawingArea") isDrawingArea = !isDrawingArea;
    }
}
