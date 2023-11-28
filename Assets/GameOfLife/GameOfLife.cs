using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    //Object we spawn
    public GameObject TileObject;

    //How many tiles
    private static readonly int Width = 10;
    private static readonly int Height = 10; 
    Tile[,] tiles = new Tile[Width, Height]; //Array

    private float TimeAccu = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Generate tiles
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                // Instantiate the tile
                GameObject tile = Instantiate(TileObject,
                                        new Vector3(x, 0f, y) * 1.05f,
                                        TileObject.transform.rotation);
                tiles[x,y] = tile.GetComponent<Tile>();
                tiles[x, y].SetAlive(false);

                tiles[x, y].gameObject.transform.parent = this.transform;
                tiles[x, y].gameObject.name = "Tile " + x + ", " + y;
                
            }
        }

        //
        tiles[1, 5].SetAlive(true);

        tiles[3, 5].SetAlive(true);

        tiles[4, 9].SetAlive(true);

        tiles[3, 9].SetAlive(true);

        tiles[2, 9].SetAlive(true);

        tiles[2, 3].SetAlive(true);

        tiles[2, 1].SetAlive(true);

        tiles[2, 2].SetAlive(true);



    }

    //Return how many neighbors tile has.
    private int GetLiveNeighbours(int x, int y)
    {
        int liveneighbours = 0;
        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (!(i == x & j == y) && i >= 0 && j >= 0 && i < Width && j < Height)
                {
                    // current i,j is not x,y
                    if (tiles[i, j].alive)
                    {
                        liveneighbours++;
                    }
                }
            }
        }
        return liveneighbours;
    }

    // Update is called once per frame
    void Update()
    {
        TimeAccu += Time.deltaTime;

        if (TimeAccu > 2.0f)
        {
            // RULES:
            // 1. Fewer than 2 live neighbours --> die
            // 2. 2 or 3 live neighbours -> live on
            // 3. more than 3 live neighbours -> die
            // 4. dead cell with 3 live neighbours -> rebirth 
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    int live = GetLiveNeighbours(x, y);
                    if (live < 2)
                    {
                        tiles[x, y].CheckNextStatus(false); //Too few neighbours, he automatically dies
                    }
                    else if (live < 4 && tiles[x, y].alive == true) //Keeps living
                    {
                        tiles[x, y].CheckNextStatus(true);
                    }
                    else if (live > 3 && tiles[x, y].alive == true) //Too many neighbours, he dies
                    {
                        tiles[x, y].CheckNextStatus(false); 
                    }
                    else if (live == 3 && tiles[x, y].alive == false) //3 neighbours, be born you peasant
                    {
                        tiles[x, y].CheckNextStatus(true);
                    }
                }
            }

            // Update the tiles
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (tiles[x,y].nextAlive)
                    {
                        tiles[x, y].SetAlive(true);
                    }
                    else
                    {
                        tiles[x, y].SetAlive(false);
                    }
                }
            }
            TimeAccu = 0.0f;
        }

    }

    void ChangeTile(Tile tile)
    {
        return;
    }
}
