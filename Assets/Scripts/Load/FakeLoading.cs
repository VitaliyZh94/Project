using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeLoading
{
    private Canvas _curtain;
    
    public void ShowCurtain()
    {
        _curtain = Resources.Load<Canvas>("LoadingUI");

        if (_curtain != null) 
            Object.Instantiate(_curtain);
    }

}
