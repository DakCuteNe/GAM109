using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAM109.Lab.Lab2.Bai3
{
    public class BossSpawnEvent : ILevelEvent
    {
        public void TriggerEvent(Player player, WaveManager waveManager)
        {
            Console.WriteLine("Sự kiện Boss đã được kích hoạt!");
            EnemyBase boss = new Boss();
            Console.WriteLine("Triệu hồi Boss : {boss.Name}");
        }
    }
}