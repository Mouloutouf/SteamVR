using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
public class Translate3DSceneTo2D : EditorWindow
{
    public Object canvasMobile;
    public Object camMobile;
    public Object object3D;
    public Object prefabs2D;

    [MenuItem("Window/Translate3DSceneTo2D")]
    public static void ShowWindow()
    {
        GetWindow<Translate3DSceneTo2D>("Translate3DSceneTo2D");
    }

    private void OnGUI()
    {
        object3D = EditorGUILayout.ObjectField(object3D, typeof(GameObject), true);
        prefabs2D = EditorGUILayout.ObjectField(prefabs2D, typeof(GameObject), true);
        camMobile = EditorGUILayout.ObjectField(camMobile, typeof(GameObject), true);
        canvasMobile = EditorGUILayout.ObjectField(canvasMobile, typeof(GameObject), true);

        if (GUILayout.Button("Proceed"))
        {
            GameObject gameObject3D = object3D as GameObject; 
            GameObject cam = camMobile as GameObject; 
            GameObject canvas = canvasMobile as GameObject; 
            Vector3 viewportCoefs = cam.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0, 0, 0));
            RectTransform newCanvas = canvas.GetComponent<RectTransform>();
            Vector2 position =
                new Vector2(-(newCanvas.sizeDelta.x / 2 / viewportCoefs.x) * gameObject3D.transform.position.x, 
                            -(newCanvas.sizeDelta.y / 2 / viewportCoefs.z) * gameObject3D.transform.position.z);
            Instantiate(prefabs2D, position, Quaternion.identity, newCanvas.transform); 
        }
    }
}
