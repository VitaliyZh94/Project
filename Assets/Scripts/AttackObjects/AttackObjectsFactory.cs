using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class AttackObjectsFactory
{
    private Transform _spawnPos;
    private Queue<AttackObject> _objectsQueue;
    
    private string _objectPath;
    
    
    public AttackObjectsFactory(string objectPath, Transform spawnPos)
    {
        _objectPath = objectPath;
        _spawnPos = spawnPos;
        
        _objectsQueue = new Queue<AttackObject>();
        
        for (int i = 0; i < 10 ; i++) 
            AddObjToQueue();
    }
    
    public AttackObject GetObject()
    {
        if (_objectsQueue.Count <= 0 ) 
            AddObjToQueue();
        
        var obj = _objectsQueue.Dequeue();
        obj.gameObject.SetActive(true);
        
        CoroutineHandler.Instance.StartRoutine(ReturnToQueueRoutine(obj));

        return obj;
    }
    
    private void AddObjToQueue()
    {
        var objPrefab = GetObjectFromResources();
        var newObj = Object.Instantiate(objPrefab, _spawnPos.transform.position, Quaternion.identity);
        
        _objectsQueue.Enqueue(newObj);
        
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(_spawnPos);
    }
    

    private AttackObject GetObjectFromResources() => 
        Resources.Load<AttackObject>(_objectPath);

    
    private IEnumerator ReturnToQueueRoutine(AttackObject obj)
    {
        yield return new WaitForSeconds(5f);

        if (!obj) yield break;
        
        obj.gameObject.SetActive(false);
        _objectsQueue.Enqueue(obj);
        obj.transform.SetParent(_spawnPos);
    }
}