using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
    public enum KeyType
    {
        None,
        Black,
        White,
        Red,
        Green,
        Blue,
        Admin
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }
}
