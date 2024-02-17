using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleBall : AttackObject
{
    [SerializeField] private float _speed;
    
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
}