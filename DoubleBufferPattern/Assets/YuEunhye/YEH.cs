using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YEH : MonoBehaviour
{
    public class Framebuffer
    {
        Text _text = null;
        readonly char[] _pixels = new char[WIDTH * HEIGHT];

        const int WIDTH = 100;
        const int HEIGHT = 50;
        public Framebuffer(Text text)
        {
            _text = text;
        }
        public void Clear()
        {
            for (int i = 0; i < WIDTH * HEIGHT; ++i)
            {
                _pixels[i] = ' ';
            }
            Print();
        }
        public void Default()
        {
            for (int i = 0; i < WIDTH * HEIGHT; ++i)
            {
                _pixels[i] = '□';
            }
        }
        public void Draw(int x, int y)
        {
            _pixels[(WIDTH * y) + x] = '■';
        }
        public void Print()
        {
            if (_text == null)
                return;

            _text.text = "";
            for (int y = 0; y < HEIGHT; ++y)
            {
                for (int x = 0; x < WIDTH; ++x)
                {
                    _text.text += _pixels[(WIDTH * y) + x];
                }
                _text.text += "\n";
            }
        }
        public Text GetText
        {
            get
            {
                return _text;
            }
        }
    }
    public class Scene
    {
        private Framebuffer[] _buffers = new Framebuffer[2];
        private Framebuffer _current;
        private Framebuffer _next;

        private int _index;

        public Scene(Text current, Text next)
        {
            _current = new Framebuffer(current);
            _next = new Framebuffer(next);

            _buffers[0] = _current;
            _buffers[1] = _next;
            _index = 0;
        }
        public void Draw()
        {
            _buffers[_index].Default();
            _buffers[_index].Draw(1, 1);
            _buffers[_index].Draw(4, 1);
            _buffers[_index].Draw(1, 3);
            _buffers[_index].Draw(2, 4);
            _buffers[_index].Draw(3, 4);
            _buffers[_index].Draw(4, 3);
            _buffers[_index].Print();
            Debug.Log(_buffers[_index].GetText.name);

            Swap();
            _buffers[_index].Clear();
        }

        private void Swap()
        {
            _index = 1 - _index;
        }
    }

    [SerializeField] Text current;
    [SerializeField] Text next;
    Scene scene = null;
    // Start is called before the first frame update
    void Start()
    {
        scene = new Scene(current, next);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            scene.Draw();
        }
    }
}
