using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKey : MonoBehaviour
{
    public static PlayerKey instance;
    private List<Key> keyList = new List<Key>();


    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    public List<Key> GetKeyList()
    {
        return keyList;
    }
    public void PutKey(Key key)
    {
        if(!keyList.Contains(key))
        keyList.Add(key);
    }

}
