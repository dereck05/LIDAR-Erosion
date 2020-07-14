using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (TerrainGenerator))]
public class MeshEditor : Editor {

    TerrainGenerator terrainGenerator;
    public override void OnInspectorGUI () {
        DrawDefaultInspector ();

        if (GUILayout.Button ("Generate Mesh")) {
            terrainGenerator.GenerateHeightMap ();
            terrainGenerator.ContructMesh();
        }

  
    }

    void OnEnable () {
        terrainGenerator = (TerrainGenerator) target;
        Tools.hidden = true;
    }

    void OnDisable () {
        Tools.hidden = false;
    }
}