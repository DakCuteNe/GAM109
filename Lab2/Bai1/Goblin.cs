using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GAM109.Lab.Lab1;

namespace GAM109.Lab.Lab2
{
    public class Goblin : EnemyBase
    {
        public int Speed { get; private set; }

        public Goblin() : base("Goblin", 30, 5, 10)
        {
            Speed = 10;
        }

        public override void PerformAttack(Player player)
        {
            Console.WriteLine($"{Name} lao tới và tấn công {player.Name}, gây {AttackDamage} sát thương!.");
            player.TakeDamage(AttackDamage);
        }

        public override void Die()
        {
            if (Health <= 0 && Health > -10)
            {
                Console.WriteLine($"{Name} sợ hãi bỏ chạy trước khi ngã xuống!");
            }
            else
            {
                base.Die();
            }
        }
    

    public virtual void Move()
        {
            Console.WriteLine($"{Name} di chuyển với tốc độ {Speed}.");
        }
    }
}