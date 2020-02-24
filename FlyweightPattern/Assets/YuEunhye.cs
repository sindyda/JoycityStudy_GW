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
        Dictionary<int, Dictionary<int, Terrain>> _tiles = new Dictionary<int, Dictionary<int, Terrain>>();

        Terrain _grassTerrain = new Terrain(1, false, Color.green);
        Terrain _hillTerrain = new Terrain(2, false, Color.gray);
        Terrain _riverTerrain = new Terrain(3, true, Color.blue);

        public void GenerateTerrain(int width, int height, int range)
        {
            for (int x = 0; x < width; ++x)
            {
                var ytiles = new Dictionary<int, Terrain>();
                for (int y = 0; y < height; ++y)
                {
                    if (Random.Range(0, range) == 0)
                    {
                        ytiles.Add(y, _hillTerrain);
                    }
                    else
                    {
                        ytiles.Add(y, _grassTerrain);
                    }
                }
                _tiles.Add(x, ytiles);
            }

            int riverX = Random.Range(0, width);
            for (int y = 0; y < height; ++y)
            {
                _tiles[riverX][y] = _riverTerrain;
            }
        }

        public void Show(Image image, GameObject parent)
        {
            foreach (var xtiles in _tiles)
            {
                var x = xtiles.Key;
                foreach (var ytiles in xtiles.Value)
                {
                    var y = ytiles.Key;
                    var terrain = ytiles.Value;

                    image.color = terrain.GetColor();
                    var clone = Instantiate(image, parent.transform, false);
                    clone.transform.position = new Vector3(x * 10, y * 10, 1);
                }
            }
        }
    }

    public GameObject parent;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        World world = new World();
        world.GenerateTerrain(50, 50, 10);
        world.Show(image, parent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
