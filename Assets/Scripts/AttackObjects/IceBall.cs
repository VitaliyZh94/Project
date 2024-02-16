using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class IceBall : AttackObject
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;

    private IMoveble _moveble;
    private IDamagetable _damagetable;
    
    private Rigidbody _rb;

    private void Start()
    {
        //_rb = GetComponent<Rigidbody>(); ???
    }
    
    public override void Attack()
    {
        var vector = gameObject.transform.forward;
        
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(vector * _speed, ForceMode.VelocityChange);
        _rb.useGravity = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out _moveble)) 
            _moveble.StopMoving();

        if (other.gameObject.TryGetComponent(out _damagetable)) 
            _damagetable.TakeDamage(_damage);

        gameObject.SetActive(false);
    }
}