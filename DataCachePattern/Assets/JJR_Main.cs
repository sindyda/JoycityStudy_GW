﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JeonJaram
{
    public class Component
    {
        public void Update()
        {

        }
    }
    public class InternalGameEntity
    {
        public InternalGameEntity()
        {

        }
        public void Update()
        {
            if (component != null)
            {
                component.Update();
            }
        }

        Component component = new Component();
    }

    public class ExternalGameEntity
    {
        public ExternalGameEntity()
        {

        }
        public void Update()
        {
            if (component != null)
            {
                component.Update();
            }
        }

        public void SetComponent(Component component)
        {
            this.component = component;
        }
        Component component = null;
    }

    public class JJR_Main : MonoBehaviour
    {
        const int MAX_ENTITY = 10000000;
        List<InternalGameEntity> internalGameEntities = new List<InternalGameEntity>();
        List<ExternalGameEntity> externalGameEntities = new List<ExternalGameEntity>();
        Component[] components = new Component[MAX_ENTITY];
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < MAX_ENTITY; ++i)
            {
                internalGameEntities.Add(new InternalGameEntity());
            }

            for (int i = 0; i < MAX_ENTITY; ++i)
            {
                components[i] = new Component();
            }

            for (int i = 0; i < MAX_ENTITY; ++i)
            {
                var gameEntity = new ExternalGameEntity();
                gameEntity.SetComponent(components[i]);
                externalGameEntities.Add(gameEntity);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                float befTime = Time.realtimeSinceStartup;
                for (int i = 0; i < internalGameEntities.Count; ++i)
                {
                    internalGameEntities[i].Update();
                }

                Debug.Log(string.Format("internal access time : {0}", Time.realtimeSinceStartup - befTime));

                befTime = Time.realtimeSinceStartup;

                for (int i = 0; i < externalGameEntities.Count; ++i)
                {
                    externalGameEntities[i].Update();
                }

                Debug.Log(string.Format("external access time : {0}", Time.realtimeSinceStartup - befTime));


                befTime = Time.realtimeSinceStartup;
                for (int i = 0; i < components.Length; ++i)
                {
                    components[i].Update();
                }

                Debug.Log(string.Format("direct access time : {0}", Time.realtimeSinceStartup - befTime));

            }
        }
    }

}