using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UNE : MonoBehaviour
{
    public const int WALK_ACCELERATION = 1;
    public class GameObject
    {
        public int velocity;
        public int posX, posY;
        public float scaleX, scaleY;
        public Image image;

        private UNE_InputComponent inputComp;
        private UNE_GraphicsComponent graphicsComp;
        private UNE_PhysicsComponent physicsComp;

        public GameObject(Image img, UNE_InputComponent inputc, UNE_GraphicsComponent graphicc, UNE_PhysicsComponent physicsc)
        {
            image = img;
            inputComp = inputc;
            graphicsComp = graphicc;
            physicsComp = physicsc;
        }
        public void Update()
        {
            inputComp?.Update(this);
            graphicsComp?.Update(this);
            physicsComp?.Update(this);
        }
    }

    GameObject uneGo;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        uneGo = new GameObject(image, new Player_InputComponent(), new Player_GraphicsComponent(), new Player_PhysicsComponent());
    }

    // Update is called once per frame
    void Update()
    {
        uneGo?.Update();
    }
}
