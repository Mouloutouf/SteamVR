using UnityEngine;
using UnityEditor;
using System;

namespace CustomEditor
{
    [InitializeOnLoad]
    [CanEditMultipleObjects]
    public class TeleportAreaDrawer : Editor
    {
        static bool isDrawingArea = false, isInDrawMode = false;
        static string debugText = "Hello";
        static Vector3 startMousePos, endMousePos;

        static TeleportAreaDrawer()
        {
            SceneView.duringSceneGui -= OnSceneGUI;
            SceneView.duringSceneGui += OnSceneGUI;
        }

        static void OnSceneGUI(SceneView sceneView)
        {
            Functions(sceneView);
            DrawShape();
        }

        private static void DrawShape()
        {
            if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
            {
                startMousePos = Camera.current.ScreenToWorldPoint(Event.current.mousePosition);
                startMousePos.y = 0;
                GameObject yes = GameObject.CreatePrimitive(PrimitiveType.Cube);
                yes.transform.position = startMousePos;
            }
        }

        private static void Functions(SceneView sceneView)
        {
            Handles.BeginGUI();
            Rect rect = new Rect();// = new Rect(sceneView.camera.pixelWidth * 0.5f, -sceneView.camera.pixelHeight * 0.45f, sceneView.camera.pixelWidth, -sceneView.camera.pixelHeight);
            rect.position = new Vector2(sceneView.camera.pixelWidth * 0.5f, -sceneView.camera.pixelHeight * 0.45f);
            rect.size = new Vector2(sceneView.camera.pixelWidth, sceneView.camera.pixelHeight);
            //rect.center = new Vector2(10, 10);
            GUI.Label(rect, debugText);

            if (Event.current.type == EventType.KeyUp)
            {
                if (Event.current.keyCode == KeyCode.B)
                {
                    sceneView.orthographic = !isInDrawMode;
                    Vector3 position = SceneView.lastActiveSceneView.pivot;
                    if (!isInDrawMode)
                    {
                        sceneView.LookAt(position, Quaternion.Euler(90, 0, 0));
                        debugText = "You have entered Draw Mode";
                    }

                    else
                    {
                        debugText = "";
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
}