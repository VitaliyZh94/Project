public class InterruptSkill : ISkillDamage
{
    public float damage { get; set; }
    public float delay { get; set; }
    public float cast { get; set; }
    public bool isDelayed { get; set; }


    public InterruptSkill (float damage, float delay, float cast)
    {
        this.damage = damage;
        this.delay = delay;
        this.cast = cast;
    }

    public AttackObjectsFactory AttackObjectsFactory { get; set; }
    public void Attack(Heroes aim)
    {
       
    }
}