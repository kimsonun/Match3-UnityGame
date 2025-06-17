using UnityEngine;
using System.Collections.Generic;

public class ItemPool : MonoBehaviour
{
    private static ItemPool instance;
    public static ItemPool Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("ItemPool");
                instance = go.AddComponent<ItemPool>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }

    private Dictionary<string, Queue<GameObject>> pools = new Dictionary<string, Queue<GameObject>>();
    private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public GameObject GetItem(string prefabName)
    {
        if (!pools.ContainsKey(prefabName))
        {
            pools[prefabName] = new Queue<GameObject>();
        }

        if (pools[prefabName].Count > 0)
        {
            GameObject item = pools[prefabName].Dequeue();
            item.SetActive(true);
            return item;
        }

        if (!prefabs.ContainsKey(prefabName))
        {
            prefabs[prefabName] = Resources.Load<GameObject>(prefabName);
        }

        return Instantiate(prefabs[prefabName]);
    }

    public void ReturnItem(string prefabName, GameObject item)
    {
        if (!pools.ContainsKey(prefabName))
        {
            pools[prefabName] = new Queue<GameObject>();
        }

        item.SetActive(false);
        pools[prefabName].Enqueue(item);
    }

    public void ClearPool()
    {
        foreach (var pool in pools.Values)
        {
            while (pool.Count > 0)
            {
                GameObject item = pool.Dequeue();
                if (item != null)
                {
                    Destroy(item);
                }
            }
        }
        pools.Clear();
        prefabs.Clear();
    }
} 