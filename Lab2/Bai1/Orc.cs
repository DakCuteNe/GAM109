using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GAM109.Lab.Lab1;

namespace GAM109.Lab.Lab2
{
    public class Orc : EnemyBase
    {
        public Orc() : base("Orc", 50, 10, 20)
        {
        }

        public override void PerformAttack(Player player)
        {
            Console.WriteLine($"{Name} vung rìu mạnh mẽ vào {player.Name}, gây {AttackDamage} sát thương!");
            player.TakeDamage(AttackDamage);
        }

        public override void Die()
        {
            Console.WriteLine($"{Name} gầm lên một tiếng cuối cùng trước khi ngã xuống!");
        }
    }
}