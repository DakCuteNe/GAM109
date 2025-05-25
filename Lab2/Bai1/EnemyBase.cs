using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GAM109.Lab.Lab1;

namespace GAM109.Lab.Lab2
{
    public abstract class EnemyBase
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackDamage { get; set; }
        public int GoldDropped { get; set; }

        public EnemyBase(string name, int health, int attackDamage, int goldDropped)
        {
            Name = name;
            Health = health;
            AttackDamage = attackDamage;
            GoldDropped = goldDropped;
        }

        public virtual void TakeDamage(int ammount)
        {
            Health -= ammount;
            if (Health > 0)
            {
                Console.WriteLine($"{Name} nhận {ammount} sát thương. Còn {Health} máu.");
                if (Health <= 0)
                {
                    Console.WriteLine($"{Name} đã bị tiêu diệt");
                    Die();
                }
            }
        }

        public abstract void PerformAttack(Player player);

        public virtual void Die()
        {
            Console.WriteLine($"{Name} đã chết và rơi ra {GoldDropped} vàng.");
        }

        internal void PerformAttack(Bai4.Player player)
        {
            throw new NotImplementedException();
        }
    }
}