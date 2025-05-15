using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PrefabSpawnerWindow : EditorWindow
{
    private static bool _isSpawningEnabled = true;
    private int _selectedIndex = 0;
    private GUIStyle _labelStyle;
    private Dictionary<string, GameObject> _prefabDictionary;

    private string[] _dropDownOptions = new string[] 
    {
        "Prefab_Flower",
        "Prefab_Star",
        "Prefab_Mario",
        "Prefab_Floor",
        "Prefab_Coin",
        "Prefab_Spikes",
    };
    [MenuItem("Tools/Prefab Spawner")]
    public static void ShowWindow()
    {
       var window = GetWindow<PrefabSpawnerWindow>();
       window.titleContent = new GUIContent("Prefab Spawner");
       window.Show();
    }

    private void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
        _labelStyle = new GUIStyle();
        _labelStyle.normal.textColor = Color.white;

        if (_prefabDictionary == null || _prefabDictionary.Count == 0)
            LoadPrefabs();
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    private void OnGUI()
    {
        EditorGUILayout.Space();
        _selectedIndex = EditorGUILayout.Popup("Select Option",_selectedIndex,_dropDownOptions);
        EditorGUILayout.Space();

        if (GUILayout.Button("Toggle Prefab Spawning"))
            TogglePrefabSpawning();

        GUILayout.Label("Prefab Spawning Status: " + (_isSpawningEnabled ? "<color=yellow>Enabled</color>" : "<color=red>Disabled</color>"), _labelStyle);
    }

    private void OnSceneGUI(SceneView sceneView)
    {

        if (_prefabDictionary == null || !_prefabDictionary.ContainsKey(_dropDownOptions[_selectedIndex]))
            return;

        Event current = Event.current;

        if (current.type == EventType.MouseDown && current.button == 1)
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(current.mousePosition);
            Vector3 mouseWorldPos = ray.origin;

            if (current.shift)
            {
                Vector2 mousePos2D = new Vector2(mouseWorldPos.x, mouseWorldPos.y);
                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

                if (hit.collider != null)
                {
                    GameObject obj = hit.collider.gameObject;
                    string objName = obj.name; // cache before destroying
                    DestroyImmediate(obj);
                    Debug.Log("Deleted: " + obj.name);

                }
            }
            else if (_isSpawningEnabled)
            {
                Vector3 roundedPos = new Vector3(Mathf.RoundToInt(mouseWorldPos.x), Mathf.RoundToInt(mouseWorldPos.y), 0);
                Instantiate(_prefabDictionary[_dropDownOptions[_selectedIndex]], roundedPos, Quaternion.identity);
                Debug.Log("Spawned at: " + roundedPos);
            }

            current.Use();
        }
    }



    private void TogglePrefabSpawning()
    {
       _isSpawningEnabled = !_isSpawningEnabled;
    }

    private void LoadPrefabs()
    {
        _prefabDictionary = new Dictionary<string, GameObject>();
        foreach (string n in _dropDownOptions)
        {
            _prefabDictionary.Add(n,Resources.Load<GameObject>("Tiles/" + n));
        }
    }
}
