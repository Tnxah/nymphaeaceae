using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;
    [SerializeField] private Animator door;

    [SerializeField] private Key key;

    [SerializeField] private string openAnimationName;
    [SerializeField] private string closeAnimationName;
    [SerializeField] private string tryOpenLocked;

    private LockState lockState = LockState.LOCKED;
    private DoorState doorState = DoorState.CLOSED;
    private enum LockState
    {
        LOCKED,
        UNLOCKED
    }
    private enum DoorState
    {
        CLOSED,
        OPENED
    }

    private void Awake()
    {
        door = gameObject.GetComponent<Animator>();
    }

    public void Lock()
    {
        List<Key> keyList = PlayerKey.instance.GetKeyList();
        if (lockState == LockState.LOCKED || 
            doorState == DoorState.OPENED || //The door can be locked only if it is closed
            !ContainsKey(keyList))
        {
            print(" useless action ");
            return;
        }

        lockState = LockState.LOCKED;
    }

    public void UnLock()
    {
        List<Key> keyList = PlayerKey.instance.GetKeyList();
        if (lockState == LockState.UNLOCKED || doorState == DoorState.OPENED || !ContainsKey(keyList))
        {
            print(" useless action ");
            return;
        }

        lockState = LockState.UNLOCKED;

    }

    public void Close()
    {
        if (doorState == DoorState.CLOSED)
        {
            print("It is alredy closed");
            return;
        }

        door.Play(closeAnimationName, 0, 0.0f);

        doorState = DoorState.CLOSED;
    }

    public void Open()
    {
        if (lockState == LockState.LOCKED)
        {
            print("Door is locked. You can't open it.");
            if (!tryOpenLocked.Equals(""))
            door.Play(tryOpenLocked, 0, 0.0f);
            return;
        }
        if (doorState == DoorState.OPENED)
        {
            print("It is alredy opened");
            return;
        }

        door.Play(openAnimationName, 0, 0.0f);

        doorState = DoorState.OPENED;
    }

    public void OpenClose()
    {
        if (doorState == DoorState.OPENED)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    private bool ContainsKey(List<Key> keyList)
    {
        
        
        
        foreach (var key in keyList)
        {
            if (key.GetKeyType().Equals(keyType) || key.GetKeyType().Equals(Key.KeyType.Admin))
            {
                return true;
            }
        }
        
        if (key && keyList.Contains(key))
        {
            return true;
        }
        return false;
    }

}
