using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour, IMoveble
{
    [SerializeField] private Rigidbody _rigidbody;
    
    [SerializeField] private float _speed;
    [SerializeField] private float _deathYPos = 3f;
    [SerializeField] private PlayerAnim _playerAnim;
    
    private Enemy _enemy;
    
    private float _yStartPosition;
    private bool _isCanMove;
    private float _castSkillTime;

    public float Speed { get; set; }
    
    private void OnEnable()
    {
        EventBus.OnCastStarted += CastTime;
        EventBus.OnPlayerDied += DisableInputs;
        EventBus.OnEnemyDied += DisableInputs;
    }

    private void OnDisable()
    {
        EventBus.OnCastStarted -= CastTime;
        EventBus.OnPlayerDied -= DisableInputs;
        EventBus.OnEnemyDied -= DisableInputs;
    }

    private void Start()
    {
        _isCanMove = true;
        Speed = _speed;
        _yStartPosition = gameObject.transform.position.y;

        _enemy = FindObjectOfType<Enemy>();
    }

    private void Update()
    {
        if (_isCanMove == true) 
            Move();

        if (_yStartPosition - transform.position.y > _deathYPos) 
            EventBus.PlayerDie();
    }

    public void StopMoving() => 
        StartCoroutine(StopMoveRoutine());

    public void Move()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var  movementSpeed = horizontal + vertical;
        var absSpeed = Mathf.Abs(movementSpeed);
        _playerAnim.Run(absSpeed);

        transform.Translate(new Vector3(horizontal, 0, vertical) * Speed * Time.deltaTime);
        transform.forward = (_enemy.transform.position - transform.position).normalized;
    }

    private IEnumerator StopMoveRoutine()
    {
        _isCanMove = false;
        _rigidbody.isKinematic = true;
        
        yield return new WaitForSeconds(_castSkillTime);
        
        _isCanMove = true;
        _rigidbody.isKinematic = false;
    }

    private void CastTime(float castTime) => 
        _castSkillTime = castTime;

    private void DisableInputs() => 
        _isCanMove = false;
    

}   