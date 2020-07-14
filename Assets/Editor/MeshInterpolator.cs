using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (TerrainInterpolator))]
public class MeshInterpolator : Editor {

    TerrainInterpolator terrainInterpolator;
    public override void OnInspectorGUI () {
        DrawDefaultInspector ();
 
        if(GUILayout.Button ("Interpolate")){
            
            terrainInterpolator.Interpolate(0.0f);
            terrainInterpolator.ConstructMesh();
        }
  
    }

    void OnEnable () {
        terrainInterpolator = (TerrainInterpolator) target;
        Tools.hidden = true;
    }

    void OnDisable () {
        Tools.hidden = false;
    }
}