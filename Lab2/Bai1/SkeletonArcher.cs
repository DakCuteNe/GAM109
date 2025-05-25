using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAM109.Lab.Lab2
{
    public class SkeletonArcher : EnemyBase
    {
        public int AttackRange { get; private set; }

        public SkeletonArcher() : base("Skeleton Archer", 40, 8, 15)
        {
            AttackRange = 15;
        }

        public override void PerformAttack(Player player)
        {
            Console.WriteLine($"{Name} bắn một mũi tên vào {player.Name} từ khoảng cách {AttackRange} mét.");
            player.TakeDamage(AttackDamage);
        }

        public override void Die()
        {
            Console.WriteLine($"{Name} đã bị tiêu diệt và rơi ra {GoldDropped} vàng.");
        }
    }
}