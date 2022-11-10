public class Player
{
    private bool _isDead;
     public int Lives { get; set; } = 3;
     public bool IsDead
     {
        get
        {
            if(Lives<=0)
            {
                return true;
            }
            return false;
        }
     }
}