using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

class Status
{
    public Vector3 pHero;
    public int redP, blueP, bomb;
    public bool sBomb;
    public List<bool> keys, locks;
};

public class KeysAndLocksSetterBehaviour : MonoBehaviour
{
    private List<KeyBehaviour> keys = null;
    private List<LockBehaviour> locks = null;
    private Stack<Status> stk = null,stkRedo=null;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Init()
    {
        keys = new List<KeyBehaviour>();
        locks = new List<LockBehaviour>();
        stk = new Stack<Status>();
        stkRedo = new Stack<Status>();
        Transform[] all = GetComponentsInChildren<Transform>(true);
        foreach (Transform t in all)
        {
            if (t.name == "KeysAndLocksSetter") continue;
            if (t.TryGetComponent<KeyBehaviour>(out var key))
            {
                keys.Add(key);
            }
            if (t.TryGetComponent<LockBehaviour>(out var lck))
            {
                locks.Add(lck);
            }
        }
        Push();
    }
    public void Push()
    {
        stkRedo.Clear();
        Debug.Log(stk.Count + " push pos=" + LockManagement.pHero.position);
        Status status = new()
        {
            pHero = LockManagement.pHero.position,
            redP = LockManagement.redP,
            blueP = LockManagement.blueP,
            bomb = LockManagement.bomb,
            sBomb = LockManagement.GetsBomb(),
            keys = new(),
            locks = new()
        };
        foreach (var key in keys)
        {
            status.keys.Add(key.Active());
        }
        foreach (var lk in locks)
        {
            status.locks.Add(lk.Active());
        }
        stk.Push(status);
    }
    public void Undo()
    {
        if (stk.Count > 1)
        {
            stkRedo.Push(stk.Peek());
            stk.Pop();
        }
        var status = stk.Peek();
        Load(ref status);
        Debug.Log(stk.Count + " undo pos=" + status.pHero+" redo.Count="+stkRedo.Count);
    }
    public void Redo()
    {
        if (stkRedo.Count > 0)
        {
            var status = stkRedo.Peek();
            Load(ref status);
            stk.Push(status);
            stkRedo.Pop();
            Debug.Log(stkRedo.Count + " redo pos=" + status.pHero);
        }
    }
    private void Load(ref Status status)
    {
        LockManagement.pHero.position = status.pHero;
        LockManagement.redP = status.redP;
        LockManagement.blueP = status.blueP;
        LockManagement.bomb = status.bomb;
        if (status.sBomb == true) LockManagement.SetsBomb();
        else LockManagement.ResetsBomb();
        for (int i = 0; i < keys.Count; i++)
        {
            if (status.keys[i] ^ keys[i].Active())
            {
                keys[i].Activate(status.keys[i]);
            }
        }
        for (int i = 0; i < locks.Count; i++)
        {
            if (status.locks[i] ^ locks[i].Active())
            {
                locks[i].Activate(status.locks[i]);
            }
        }
    }
}
