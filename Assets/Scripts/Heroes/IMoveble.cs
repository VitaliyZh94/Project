public interface IMoveble
{
    public void Move();
    public bool IsCanMove { get; set; }
    public float Speed { get; set; }
}