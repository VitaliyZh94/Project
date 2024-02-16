using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    public GameStateMachine GameStateMachine { get; private set; }
    private FakeLoading _fakeLoading;
    
    public static EntryPoint Instance;

    private void Awake()
    {
        if (Instance == null) 
            Instance = this;
        
        else if (Instance == this) 
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _fakeLoading = new FakeLoading();
        GameStateMachine = new GameStateMachine();
        
        GameStateMachine.Initialize(new LoadGameState(GameStateMachine, _fakeLoading));
    }

}
