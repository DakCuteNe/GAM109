using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAM109.Lab.Lab2.Bai3
{
    public class HealZoneEvent
    {
        private int healAmount;

        public HealZoneEvent(int healAmount)
        {
            this.healAmount = healAmount;
        }

        public void Activate(Player player, WaveManager waveManager)
        {
            player.Health += healAmount;
            Console.WriteLine($"Người chơi đã hồi phục {healAmount} máu!");
        }
    }
}