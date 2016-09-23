using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IsoLevelManager : MonoBehaviour
{
    public GameObject TilePrefab;

    public string LevelFile;

    public List<GameObject> TileMap;

	// Use this for initialization
	void Start () {
        StartCoroutine(BuildLevel());
	}

    public IEnumerator BuildLevel()
    {
        for(int x = 0; x < 10; x++)
        {
            for(int z = 0; z < 10; z++)
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
