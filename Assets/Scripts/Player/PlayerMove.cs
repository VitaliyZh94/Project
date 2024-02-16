using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour, IMoveble
{
    [SerializeField] private Heroes _enemy;
    [SerializeField] private Heroes _player;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _spawnPos;

    [SerializeField] private float _speed;
    [SerializeField] private float _castTime;
    [SerializeField] private float _manaCost;

    private FarSkill _skill;
    
    private bool _isCanMove = true;
    public float Speed { get; set; }
    
    private void Start()
    {
        _skill = new FarSkill(3, _castTime, Constants.IceBallPrefabPath, _spawnPos, _player, _manaCost);
        Speed = _speed;
    }
    
    private void Update()
    {
        if (_isCanMove == true) 
            Move();

        if (Input.GetKeyDown(KeyCode.P)) 
            _skill.Attack(_enemy);
    }

    public void StopMoving() => 
        StopMoving(_castTime);

    public void Move()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0, vertical) * Speed * Time.deltaTime);
        transform.forward = (_enemy.transform.position - transform.position).normalized;
    }
    
    private void StopMoving(float castTime) => 
        StartCoroutine(StopMoveRoutine(castTime));

    private IEnumerator StopMoveRoutine(float castTime)
    {
        _isCanMove = false;
        _rigidbody.isKinematic = true;
        
        yield return new WaitForSeconds(castTime);
        
        _isCanMove = true;
        _rigidbody.isKinematic = false;
    }
}   