using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAM109.Lab.Lab2.Bai4
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Gold { get; set; }

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
            Gold = 0;
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"{Name} nhận {amount} sát thương. Còn {Health} máu.");
        }

        public void Heal(int amount)
        {
            Health += amount;
            Console.WriteLine($"{Name} hồi phục {amount} máu. Còn {Health} máu.");
        }

        public bool IsAlive => Health > 0;
    }
}