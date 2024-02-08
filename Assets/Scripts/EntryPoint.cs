using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    public GameStateMachine GameStateMachine { get; set; }
    public static EntryPoint Instance;

    private FakeLoading _fakeLoading;

    private void Awake()
    {
        if (Instance == null) 
            Instance = this;
        
        else if (Instance = this) 
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        _fakeLoading = new FakeLoading();
        GameStateMachine = new GameStateMachine();
        
        GameStateMachine.Initialize(new LoadGameState(GameStateMachine, _fakeLoading));
    }

}
