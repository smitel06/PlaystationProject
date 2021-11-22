using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class FindGameObjectsWithMissingScripts : Editor
{
    [MenuItem("Component/Find objects with missing scripts")]
    public static void FindGameObjects()
    {
        // Get all the paths to prefabs in our project
        string[] prefabPaths = AssetDatabase.GetAllAssetsPaths().Where(prefabPaths => path.EndsWith(".prefab", System.StringComparison.OrdinalIgnoreCase)).ToArray();
        
        GameObject parent = null;
        
        // Load each prefab
        foreach (string path in prefabPaths)
        {
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            // Get all components on this prefab
            Component[] components = prefab.GetComponents<Component>();
            // Check if any component is null, if so we have a missing component
            foreach (Component component in components)
            {
                if (component == null)
                {
                    if (parent == null)
                    {
                        parent = new GameObject("Missing Component Objects");
                    }
                    GameObject instance = Instantiate(prefab, parent.transform);

                    break;
                }
            }

        }




    }
}
