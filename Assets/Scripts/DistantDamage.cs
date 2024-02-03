public class DistantDamage : ISimpleDamage
{
    public float damage { get; set; }
    public float delay { get; set; }
    public float cast { get; set; }
    public bool isDelayed { get; set; }

    public DistantDamage (float damage, float delay, float cast)
    {
        this.damage = damage;
        this.delay = delay;
        this.cast = cast;
    }
}