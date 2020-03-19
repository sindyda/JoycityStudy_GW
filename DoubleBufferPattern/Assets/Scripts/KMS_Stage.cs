using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_Stage : MonoBehaviour
{
    KMS_DoubleBufferPattern dbpattern = new KMS_DoubleBufferPattern();
    // Start is called before the first frame update
    void Start()
    {
        KMS_Comedian h = new KMS_Comedian("헤리");
        KMS_Comedian b = new KMS_Comedian("발리");
        KMS_Comedian c = new KMS_Comedian("찰리");

        h.face(b);
        b.face(c);
        c.face(h);

        dbpattern.add(h, 0);
        dbpattern.add(b, 1);
        dbpattern.add(c, 2);

        h.slap();

        dbpattern.update();

    }
}
