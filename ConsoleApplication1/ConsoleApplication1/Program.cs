using System;

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
            if (damage <= 0)
                throw new InvalidOperationException($"Not correct damage value: {damage}");

            if (bullets <= 0)
                throw new InvalidOperationException($"Not correct bullets value: {bullets}");

            _damage = damage;
            _bullets = bullets;
        }

        public void Fire(Player player)
        {
            if (!CanFire())
                throw new InvalidOperationException($"Can not fire");

            if (player == null)
                throw new InvalidOperationException($"Player is null");

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
            if (health <= 0)
                throw new InvalidOperationException($"Not correct health value: {health}"));

            _health = health;
        }

        public void TakeDamage(int damage)
        {
            if(!IsAlive)
                throw new InvalidOperationException($"Player is not alive");
            
            if (damage <= 0)
                throw new InvalidOperationException($"Not correct damage value: {damage}");

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
            if (weapon == null)
                throw new InvalidOperationException();

            _weapon = weapon;
        }

        public void OnSeePlayer(Player player)
        {
            if (player == null)
                throw new InvalidOperationException();

            if (_weapon.CanFire() && player.IsAlive)
            {
                _weapon.Fire(player);
            }
        }
    }
}