namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Weapon weapon = new Weapon(25, 4);
            Player player = new Player(75);
            Bot bot = new Bot(weapon);
            bot.OnSeePlayer(player);
        }
    }

    public class Weapon
    {
        private int _damage;
        private int _bullets;

        public Weapon(int damage, int bullets)
        {
            _damage = damage;
            _bullets = bullets;
        }
        
        public void Fire(Player player)
        {
            player.TakeDamage(_damage);
            _bullets -= 1;
        }

        public bool CanFire()
        {
            return _bullets > 0;
        }
    }

    public class Player
    {
        private int _health;

        public bool IsAlive => _health > 0;

        public Player(int health)
        {
            _health = health;
        }
        
        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health < 0)
                _health = 0;
        }
    }

    public class Bot
    {
        private Weapon _weapon;

        public Bot(Weapon weapon)
        {
            _weapon = weapon;
        }

        public void OnSeePlayer(Player player)
        {
            if (_weapon.CanFire() && player.IsAlive)
            {
                _weapon.Fire(player);
            }
        }
    }
}