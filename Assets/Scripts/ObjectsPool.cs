using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [System.Serializable]
    private class PollObject
    {
        public Component Prefab;
        public float Size = 10;
        public Type Type;

        public LinkedList<GameObject> GameObjects = new LinkedList<GameObject>();
        public Queue<Component> GameObjectsQueue = new Queue<Component>();
    }

    [SerializeField] private PollObject[] _pullObjects; 

    public static ObjectsPool SingleTone { get; private set; }

    private void Awake()
    {
        if(SingleTone != null) Debug.LogError("SingleToneExeption");
        SingleTone = this;

        foreach (var item in _pullObjects)
        {
            item.Type = item.Prefab.GetType();

            for (int i = 0; i < item.Size; i++)
            {
                Component newComponent = Instantiate(item.Prefab);
                newComponent.gameObject.SetActive(false);
                item.GameObjectsQueue.Enqueue(newComponent);
            }
        }
    }

    public Component TakePrefab(Type prefabsType)
    {
        foreach (var item in _pullObjects)
        {
            if (item.Type != prefabsType) continue;

            Component prefab = item.GameObjectsQueue.Dequeue();
            prefab.gameObject.SetActive(true);
            return prefab;
        }

        Debug.LogError("Objects pool has not this type");
        return null;
    }

    public void PutPrefab(Component component)
    {
        foreach (var item in _pullObjects)
        {
            if (item.Type != component.GetType()) continue;

            component.gameObject.SetActive(false);
            item.GameObjectsQueue.Enqueue(component);
            return;
        }

        Debug.LogError("Objects pool has not this type");
    }
}
