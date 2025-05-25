using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAM109.Lab.Lab2
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health <= 0)
            {
                Console.WriteLine($"{Name} đã chết.");
            }
            else
            {
                Console.WriteLine($"{Name} nhận {amount} sát thương. Còn {Health} máu.");
            }
        }
    }
}