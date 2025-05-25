using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAM109.Lab.Lab2.Bai3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Hero", 100);

            List<WaveData> waves = new List<WaveData>
            {
                new WaveData(1, new List<string> {"Goblin", "SkeletonArcher"})
            };

            WaveManager waveManager = new WaveManager(waves);
            waveManager.LoadWave(0);

            LevelManager levelManager = new LevelManager();
            levelManager.RegisterEvent("BossArrival", new BossSpawnEvent());
            levelManager.RegisterEvent("HealingSpring", new HealZoneEvent(20));
            levelManager.ActivateLevelEvent("BossArrival", player, waveManager);
            waveManager.SpawnNextEnemy();
            waveManager.PrintWaveStatus();

            Console.WriteLine("\n Người chơi chạm vào vùng hồi phục!");
            levelManager.ActivateLevelEvent("HealingSpring", player, waveManager);

            Console.WriteLine("\n Người chơi chạm vào vùng triệu hồi Boss!");
            levelManager.ActivateLevelEvent("BossArrival", player, waveManager);
        }
    }
}