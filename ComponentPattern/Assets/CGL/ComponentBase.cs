using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CGL
{
    public class ComponentBase
    {
        List<ComponentBase> components = new List<ComponentBase>();
        protected GameObject gameObject = null; 
        public ComponentBase()
        {
            
        }

        void AddGameObject(GameObject obj)
        {
            gameObject = obj;
        }

        public List<T> GetComponents<T>() where T : class
        {
            return components.FindAll((x) =>
            {
                return x.GetType() == typeof(T);
            }) as List<T>;
        }

        public T GetComponent<T>() where T : class
        {
            return (components.Find((x) =>
            {
                return x.GetType() == typeof(T);
            })) as T;
        }

        public void AddComponent<T>() where T : class, new()
        {
            var comp = new T() as ComponentBase;
            comp.AddGameObject(gameObject);
            components.Add(comp);
        }
    }


    public class AudioComponent : ComponentBase
    {
        public AudioComponent() 
        {
        }

        public void PlaySound()
        {
            Debug.Log("Sound Play!");
        }
    }


    public class GraphicRenderComponent : ComponentBase
    {
        public GraphicRenderComponent() 
        {
        }

        public void RenderGraphic()
        {
            Debug.Log("Draw Item!");
        }
    }


}

