using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAM109.Lab.Lab2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Hero", 100);

            EnemyBase goblin = new Goblin();
            EnemyBase orc = new Orc();
            EnemyBase archer = new SkeletonArcher();

            Console.WriteLine("--- Battle Start ---");
            Console.WriteLine("--- Kẻ địch tấn công ---");
            goblin.PerformAttack(player);
            orc.PerformAttack(player);
            archer.PerformAttack(player);

            Console.WriteLine("--- Người chơi phản công ---");
            goblin.TakeDamage(20);
            goblin.TakeDamage(20);

            Console.WriteLine("--- battle End ---");
        }
    }
}