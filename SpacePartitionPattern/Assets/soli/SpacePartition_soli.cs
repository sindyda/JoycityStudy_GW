using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpacePartition_soli : MonoBehaviour
{
    void Start()
    {
        grid_ = new Grid_soli();
        myUnit_.init(grid_, 0, 0);

        System.Random random = new System.Random();
        for (int i = 0; i < NUM_ENEMY; ++i)
        {
            var x = random.Next(6);
            var y = random.Next(6);
            enemyUnit_[i] = Instantiate(basicUnit, new Vector3(x, y, 0), Quaternion.identity);
            enemyUnit_[i].init(grid_, x, y);
        }

    }

    void Update()
    {
        if (myUnit_ != null)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                myUnit_.transform.Translate(Vector3.up * myUnitSpeed_ * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                myUnit_.transform.Translate(Vector3.down * myUnitSpeed_ * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                myUnit_.transform.Translate(Vector3.left * myUnitSpeed_ * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                myUnit_.transform.Translate(Vector3.right * myUnitSpeed_ * Time.deltaTime);
            }

            myUnit_.move(myUnit_.transform.localPosition.x, myUnit_.transform.localPosition.y);
        }

        grid_.handleMedee();
    }

    Grid_soli grid_;
    public Unit_soli myUnit_;
    public float myUnitSpeed_ = 2f;

    public Unit_soli basicUnit;
    private Unit_soli[] enemyUnit_ = new Unit_soli[NUM_ENEMY];
    public const int NUM_ENEMY = 10;
}
