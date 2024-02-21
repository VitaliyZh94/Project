using System;

public abstract class Skills
{
    protected float CastTime { get; set; }
    
    protected AttackObjectsFactory _factory;

    protected bool _isDelayed;
    protected float _delay;
    public abstract void Attack();
}
