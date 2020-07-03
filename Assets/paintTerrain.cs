using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintTerrain : MonoBehaviour
{
    [System.Serializable]
    public class SplatHeights
    {
        public int textureIndex;
        public float startingHeight;
    }
    public SplatHeights[] splatHeights;

    // Start is called before the first frame update
    void Start()
    {

        TerrainData terrainData = Terrain.activeTerrain.terrainData;
        float[,,] splatmapData = new float[terrainData.alphamapWidth,
                                            terrainData.alphamapHeight,
                                            terrainData.alphamapLayers];

        for(int y =0; y < terrainData.alphamapHeight; y++)
        {
            for (int x = 0; x < terrainData.alphamapWidth; x++)
            {
                float terrainHeight = terrainData.GetHeight(y, x);
                float[] splat = new float[splatHeights.Length];
                for(int i =0;i < splatHeights.Length; i++)
                {
                    if(i == splatHeights.Length-1 && terrainHeight >= splatHeights[i].startingHeight)
                    {
                        splat[i] = 1;
                    }
                    else if(terrainHeight >= splatHeights[i].startingHeight && terrainHeight <= splatHeights[i+1].startingHeight)
                    {
                        splat[i] = 1;
                    }
                }
                for (int j = 0; j < splatHeights.Length; j++)
                {
                    splatmapData[x, y, j] = splat[j];
                }

            }
        }
        terrainData.alphamapResolution = terrainData.heightmapResolution - 1;
        terrainData.SetAlphamaps(0, 0, splatmapData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
