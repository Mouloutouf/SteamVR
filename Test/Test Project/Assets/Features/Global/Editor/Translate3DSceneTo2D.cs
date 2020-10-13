using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
public class Translate3DSceneTo2D : EditorWindow
{
    public Object canvasMobile;
    public Object camMobile;
    public Object object3D;
    public Object prefabs2D;
    private GameObject prefab;

    [MenuItem("Window/Translate3DSceneTo2D")]
    public static void ShowWindow()
    {
        GetWindow<Translate3DSceneTo2D>("Translate3DSceneTo2D");
    }

    
    private void OnGUI()
    {
        GUILayout.Label("Il faut avoir la scène du level mobile et la scène du level VR d'ouvertes \n"+
        "Il faut glisser le prefab 3D de la scène mobile dans le champ 1\n"+
        "Ensuite le prefab correspondant en 2D dans le champ 2\n"+
        "La camera de la scène mobile en champ 3\n"+
        "Et finalement le canvas de la scène mobile en champ 4");
        object3D = EditorGUILayout.ObjectField("3D GameObject",object3D, typeof(GameObject), true);
        prefabs2D = EditorGUILayout.ObjectField("2D Prefab ", prefabs2D, typeof(GameObject), true);
        camMobile = EditorGUILayout.ObjectField("ShotCam Mobile ",camMobile, typeof(GameObject), true);
        canvasMobile = EditorGUILayout.ObjectField("Canvas Mobile",canvasMobile, typeof(GameObject), true);

        if (GUILayout.Button("Proceed"))
        {
            GameObject gameObject3D = object3D as GameObject; 
            GameObject cam = camMobile as GameObject; 
            GameObject canvas = canvasMobile as GameObject; 
            prefab = prefabs2D as GameObject; 
            Vector3 viewportCoefs = cam.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0, 0, 0));
            RectTransform newCanvas = canvas.GetComponent<RectTransform>();
            Vector2 position =
                new Vector2(-(newCanvas.sizeDelta.x / 2 / viewportCoefs.x) * gameObject3D.transform.position.x, 
                            -(newCanvas.sizeDelta.y / 2 / viewportCoefs.z) * gameObject3D.transform.position.z);
            prefab =  Instantiate(prefabs2D, newCanvas.transform) as GameObject;
            prefab.GetComponent<RectTransform>().anchoredPosition = position;
        }
    }
    [InfoBox("Il faut avoir la scène du level mobile et la scène du level VR d'ouverts," +
        "Il faut glisser le prefab 3D de la scène mobile dans le champ 1, ensuite le prefab correspondant," +
        "en 2D, la camera de la scène mobile en champ 3 et finalement le canvas de la scène mobile en champ 4")]

    public void Setup()
    {

    }
}
