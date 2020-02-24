using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YuEunhye : MonoBehaviour
{
    class Terrain
    {
        private int _cost;
        private bool _isWater;
        private Color _color;

        public int GetMovementCost() { return _cost; }
        public bool IsWater() { return _isWater; }
        public Color GetColor() { return _color; }
        public Terrain (int cost, bool iswater, Color color)
        {
            _cost = cost;
            _isWater = iswater;
            _color = color;
        }
    }

    class World
    {
        const int width = 50;
        const int height = 50;

        Terrain[,] _tiles = new Terrain[width, height];

        Terrain _grassTerrain = new Terrain(1, false, Color.green);
        Terrain _hillTerrain = new Terrain(2, false, Color.gray);
        Terrain _riverTerrain = new Terrain(3, true, Color.blue);

        public void GenerateTerrain(int range)
        {
            int riverX = Random.Range(0, width);
            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    if (x == riverX)
                    {
                        _tiles[x, y] = _riverTerrain;
                    }
                    else if (Random.Range(0, range) == 0)
                    {
                        _tiles[x, y] = _hillTerrain;
                    }
                    else
                    {
                        _tiles[x, y] = _grassTerrain;
                    }
                }
            }
        }

        public void Show(Image image, GameObject parent)
        {
            var sizeX = image.rectTransform.sizeDelta.x;
            var sizeY = image.rectTransform.sizeDelta.y;

            for (int x = 0; x < _tiles.GetLength(0); ++x)
            {
                for (int y = 0; y < _tiles.GetLength(1); ++y)
                {
                    var terrain = _tiles.GetValue(x, y) as Terrain;
                    image.color = terrain.GetColor();

                    var clone = Instantiate(image, parent.transform, false);
                    clone.transform.position = new Vector3(x * sizeX, y * sizeY, 1);
                }
            }
        }
    }

    public GameObject parent;
    public Image image;

    World world = new World();
    // Start is called before the first frame update
    void Start()
    {
        world.GenerateTerrain(10);
        world.Show(image, parent);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            world.GenerateTerrain(10);
            world.Show(image, parent);
        }
    }
}
