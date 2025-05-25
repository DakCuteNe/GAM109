using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAM109.Lab.Lab2.Bai3
{
    public class Boss : EnemyBase
    {
        public Boss() : base("Dark Lord", 300, 50, 100) { }

        public override void PerformAttack(Player player)
        {
            Console.WriteLine($"{Name} tung chiêu hủy diệt vào {player.Name}, gây {AttackDamage} sát thương!");
            player.TakeDamage(AttackDamage);
        }

        public override void Die()
        {
            Console.WriteLine($"{Name} gầm thét và tan biến, rơi ra {GoldDropped} vàng!");
        }
    }
}
