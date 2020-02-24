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
        const int range = 10;

        Terrain[,] _tiles;

        Terrain _grassTerrain = new Terrain(1, false, Color.green);
        Terrain _hillTerrain = new Terrain(2, false, Color.gray);
        Terrain _riverTerrain = new Terrain(3, true, Color.blue);

        public void FlyweightTerrain(int width, int height)
        {
            _tiles = new Terrain[width, height];

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

        public void NewTerrain(int width, int height)
        {
            _tiles = new Terrain[width, height];

            int riverX = Random.Range(0, width);
            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    if (x == riverX)
                    {
                        _tiles[x, y] = new Terrain(3, true, Color.blue);
                    }
                    else if (Random.Range(0, range) == 0)
                    {
                        _tiles[x, y] = new Terrain(2, false, Color.gray);
                    }
                    else
                    {
                        _tiles[x, y] = new Terrain(1, false, Color.green);
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
    public Text text;

    World world = new World();
    // Start is called before the first frame update
    void Start()
    {
        text.text = "F: Flyweight / N: New / C: Compare";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var beforeTime = Time.realtimeSinceStartup;
            world.FlyweightTerrain(50, 50);
            var afterTime = Time.realtimeSinceStartup;

            world.Show(image, parent);

            text.text = string.Format("Flyweight: {0}", afterTime - beforeTime);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            var beforeTime = Time.realtimeSinceStartup;
            world.NewTerrain(50, 50);
            var afterTime = Time.realtimeSinceStartup;

            world.Show(image, parent);

            text.text = string.Format("New: {0}", afterTime - beforeTime);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            var beforeTime1 = Time.realtimeSinceStartup;
            world.FlyweightTerrain(1000, 1000);
            var afterTime1 = Time.realtimeSinceStartup;
            var flytime = afterTime1 - beforeTime1;

            var beforeTime2 = Time.realtimeSinceStartup;
            world.NewTerrain(1000, 1000);
            var afterTime2 = Time.realtimeSinceStartup;
            var newtime = afterTime2 - beforeTime2;

            text.text = string.Format("Flyweight: {0:0.000000}\nNew: {1:0.000000}\n\nGap: {2:0.000000}", flytime, newtime, Mathf.Abs(flytime - newtime));
        }
    }
}
