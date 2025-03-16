using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] regularTiles;

    [SerializeField]
    GameObject goalTile;

    [SerializeField]
    GameObject startTile;

    [SerializeField]
    int mapSize;

    [SerializeField]
    float tileSize;

    [SerializeField]
    int numberOfGoalTiles;

    int startTileIndex;

    List<GameObject> maze = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //create maze with regular tiles

        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                GameObject tile = Instantiate(regularTiles[Random.Range(0, regularTiles.Length)], new Vector3(i * tileSize, 0, j * tileSize),
                    Quaternion.Euler(-90, 0, Random.Range(0, 4) * 90), transform);
                maze.Add(tile);
            }
        }

        // Replace a regular tile with start tile on the maze randomly
        startTileIndex = Random.Range(0, maze.Count);

        ReplaceTile(startTileIndex, startTile);

        int goalTileIndex;
        for (int i = 0; i < numberOfGoalTiles; i++)
        {
            do
            {
                goalTileIndex = Random.Range(0, maze.Count);
            }
            while (goalTileIndex == startTileIndex);
        }
        ReplaceTile(startTileIndex, goalTile);
    }
        void ReplaceTile(int replaceIndex, GameObject replaceObject)
        {
            GameObject start = Instantiate(replaceObject,
                maze[replaceIndex].transform.position,
                Quaternion.identity,
                transform);
            Destroy(maze[replaceIndex]);
            maze[replaceIndex] = start;
        }

        // Update is called once per frame
        void Update()
    {
        
    }
}
