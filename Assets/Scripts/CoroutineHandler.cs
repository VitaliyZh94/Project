using System.Collections;
using UnityEngine;

public class CoroutineHandler : MonoBehaviour
{
    public static CoroutineHandler Instance;
    
    private void Start()
    {
        if (Instance == null)
            Instance = this;
        
        else if (Instance == this) 
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    
    public void StartRoutine(IEnumerator enumerator) => 
        StartCoroutine(enumerator);

    public void StopRoutine(IEnumerator enumerator) =>
        StopCoroutine(enumerator);

}