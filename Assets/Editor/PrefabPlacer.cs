using UnityEngine;
using UnityEditor;
using System.Collections;

public class PrefabPlacer : EditorWindow {

    public PrefabPlacerData ppd;

    float pepperRightPos = 5.5f;
    float pepperJellyYPos = 2.6f;
    float tomatoRightPos = 5.5f;
    float bigTomatoRightPos = 0;
    float bigKnifePos = 21f;

    float easyJellyPos = 8.9f;
    float mediumJullyPos = 5f;
    float hardJellyPos = 2f;

    public GameObject jellyPrefab;
    public GameObject jellyBeanParent;
    private GameObject saltShaker;
    private GameObject pepperShaker;
    private GameObject smallTomato;
    private GameObject bigTomato;

    [MenuItem("Window/Prefab Placer")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<PrefabPlacer>("Prefab Placer");
    }

    protected void OnEnable()
    {
        pepperRightPos = ppd.pepperRightPos;
        pepperJellyYPos = ppd.pepperJellyYPos;
        tomatoRightPos = ppd.tomatoRightPos;
        bigTomatoRightPos = ppd.bigTomatoRightPos;

        easyJellyPos = ppd.easyJellyPos;
        mediumJullyPos = ppd.mediumJullyPos;
        hardJellyPos = ppd.hardJellyPos;

        jellyPrefab = ppd.jellyPrefab;
        jellyBeanParent = ppd.jellyBeanParent;
        saltShaker = ppd.saltShaker;
        pepperShaker = ppd.pepperShaker;
        smallTomato = ppd.smallTomato;
        bigTomato = ppd.bigTomato;
    }

    protected void OnDisable()
    {
        ppd.pepperRightPos = pepperRightPos;
        ppd.pepperJellyYPos = pepperJellyYPos;
        ppd.tomatoRightPos = tomatoRightPos;
        ppd.bigTomatoRightPos = bigTomatoRightPos;

        ppd.easyJellyPos = easyJellyPos;
        ppd.mediumJullyPos = mediumJullyPos;
        ppd.hardJellyPos = hardJellyPos;

        ppd.jellyPrefab = jellyPrefab;
        ppd.jellyBeanParent = jellyBeanParent;
        //ppd.prefabToReplaceWith = prefabToReplaceWith;

    }

    // Use this for initialization
    void OnGUI ()
    {
        GUILayout.Label("Lane Position", EditorStyles.boldLabel);

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Left"))
        {
            Move("left");
        }

        if (GUILayout.Button("Centre"))
        {
            Move("centre");
        }

        if (GUILayout.Button("Right"))
        {
            Move("right");
        }

        GUILayout.EndHorizontal();        

        GUILayout.Space(7);

        GUILayout.Label("Jellybean Placement", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Jellybean Prefab", EditorStyles.label);
        jellyPrefab = (GameObject)EditorGUILayout.ObjectField(jellyPrefab, typeof(GameObject), true);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Jellybean Parent", EditorStyles.label);
        jellyBeanParent = (GameObject)EditorGUILayout.ObjectField(jellyBeanParent, typeof(GameObject), true);
        EditorGUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Easy"))
        {
            JellyBean("easy");
        }

        if (GUILayout.Button("Medium"))
        {
            JellyBean("medium");
        }

        if (GUILayout.Button("Hard"))
        {
            JellyBean("hard");
        }
        GUILayout.EndHorizontal();


        //ContextMenu;
        //Brakeys scriptable objects

        easyJellyPos = EditorGUILayout.FloatField("easy dist", easyJellyPos);
        mediumJullyPos = EditorGUILayout.FloatField("med dist", mediumJullyPos);
        hardJellyPos = EditorGUILayout.FloatField("hard dist", hardJellyPos);

        GUILayout.Space(7);
        GUILayout.Label("Outer Lane Distance", EditorStyles.boldLabel);
        pepperRightPos = EditorGUILayout.FloatField("Pepper R", pepperRightPos);
        pepperJellyYPos = EditorGUILayout.FloatField("Pepper Jelly Y", pepperJellyYPos);
        tomatoRightPos = EditorGUILayout.FloatField("Tomato R", tomatoRightPos);
        bigTomatoRightPos = EditorGUILayout.FloatField("Big Tomato R", bigTomatoRightPos);

        GUILayout.Space(7);
        GUILayout.Label("Object Replacer", EditorStyles.boldLabel);
        GUILayout.Label("Object to replace with", EditorStyles.label);

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("replace w' Salt"))
        {
            ReplaceWith("salt");
        }

        if (GUILayout.Button("replace w' Pepper"))
        {
            ReplaceWith("pepper");
        }
        if (GUILayout.Button("replace w' smallTom"))
        {
            ReplaceWith("smallTomato");
        }

        //if (GUILayout.Button("replace w' Big Tomato"))
        //{
        //    ReplaceWith("bigTomato");
        //}


        GUILayout.EndHorizontal();

    }

    void Centre()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            obj.transform.position = new Vector3(0, obj.transform.position.y, obj.transform.position.z);
        }
    }

    void Move(string text)
    {
        float multiplier = 0f;

        if (text == "left")
        {
            multiplier = -1;
        }

        else if (text == "right")
        {
            multiplier = 1;
        }

        else if (text == "centre")
        {
            multiplier = 0;
        }

        foreach (GameObject obj in Selection.gameObjects)
        {
            if (obj.GetComponent<PepperShaker>())
            {
                obj.transform.position = new Vector3(pepperRightPos * multiplier, obj.transform.position.y, obj.transform.position.z);
            }

            if (obj.GetComponent<Knife_Behaviour>())
            {
                obj.transform.position = new Vector3(bigKnifePos * multiplier, obj.transform.position.y, obj.transform.position.z);
            }

            else if (obj.GetComponent<TomatoSplat>() || obj.GetComponentInChildren<TomatoSplat>())
            {
                obj.transform.position = new Vector3(tomatoRightPos * multiplier, obj.transform.position.y, obj.transform.position.z);
            }

            else
            {
                obj.transform.position = new Vector3(pepperRightPos * multiplier, obj.transform.position.y, obj.transform.position.z);
            }
        }
    }	

    void JellyBean(string text)
    {
        if (text == "easy")
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                if (obj.GetComponent<PepperShaker>())
                {
                    var jellyClone = PrefabUtility.InstantiatePrefab(jellyPrefab) as GameObject;
                    jellyClone.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + pepperJellyYPos, obj.transform.position.z - easyJellyPos);
                    jellyClone.transform.SetParent(jellyBeanParent.transform);
                }

                else
                {
                    var jellyClone = PrefabUtility.InstantiatePrefab(jellyPrefab) as GameObject;
                    jellyClone.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + pepperJellyYPos, obj.transform.position.z - easyJellyPos);
                    jellyClone.transform.SetParent(jellyBeanParent.transform);
                }
            }
        }

        if (text == "medium")
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                if (obj.GetComponent<PepperShaker>())
                {
                    var jellyClone = PrefabUtility.InstantiatePrefab(jellyPrefab) as GameObject;
                    jellyClone.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + pepperJellyYPos, obj.transform.position.z - mediumJullyPos);
                    jellyClone.transform.SetParent(jellyBeanParent.transform);
                }

                else
                {
                    var jellyClone = PrefabUtility.InstantiatePrefab(jellyPrefab) as GameObject;
                    jellyClone.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + pepperJellyYPos, obj.transform.position.z - mediumJullyPos);
                    jellyClone.transform.SetParent(jellyBeanParent.transform);
                }
            }
        }

        if (text == "hard")
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                if (obj.GetComponent<PepperShaker>())
                {
                    var jellyClone = PrefabUtility.InstantiatePrefab(jellyPrefab) as GameObject;
                    jellyClone.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + pepperJellyYPos, obj.transform.position.z - hardJellyPos);
                    jellyClone.transform.SetParent(jellyBeanParent.transform);
                }

                else
                {
                    var jellyClone = PrefabUtility.InstantiatePrefab(jellyPrefab) as GameObject;
                    jellyClone.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + pepperJellyYPos, obj.transform.position.z - hardJellyPos);
                    jellyClone.transform.SetParent(jellyBeanParent.transform);
                }
            }
        }        
    }

    void ReplaceWith(string thing)
    {
        if (thing == "salt")
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                Transform tempTransform = obj.transform;
                var replacement = PrefabUtility.InstantiatePrefab(saltShaker) as GameObject;
                replacement.transform.position = tempTransform.position;
            }
        }

        else if (thing == "pepper")
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                Transform tempTransform = obj.transform;
                //DestroyImmediate(obj);
                //obj = null;
                var replacement = PrefabUtility.InstantiatePrefab(pepperShaker) as GameObject;
                replacement.transform.position = tempTransform.position;
            }
        }

        else if (thing == "smallTomato")
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                Transform tempTransform = obj.transform;
                var replacement = PrefabUtility.InstantiatePrefab(smallTomato) as GameObject;
                replacement.transform.position = tempTransform.position;
                Destroy(obj);
            }
        }

        else if (thing == "bigTomato")
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                Transform tempTransform = obj.transform;
                var replacement = PrefabUtility.InstantiatePrefab(smallTomato) as GameObject;
                replacement.transform.position = tempTransform.position;
                Destroy(obj);
            }
        }

        foreach (GameObject obj in Selection.gameObjects)
        {
            DestroyImmediate(obj);
        }
    }

}
