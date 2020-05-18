using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_GameManager : MonoBehaviour
{
    GameObject playObject = null;
    KMS_ComponentsPattern playCharactor = null;
    // Start is called before the first frame update
    void Start()
    {
        playObject = GameObject.Instantiate(Resources.Load("Capsule") as GameObject);
        if (playObject != null)
        {
            playCharactor = playObject.AddComponent<KMS_ComponentsPattern>();
            if (playCharactor != null)
            {
                playCharactor.SetComponents(new KMS_ChearactorInputComponent(),
                    new KMS_PlayerPhysicsComponent(), new KMS_PlayerGraphicsComponent());
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
