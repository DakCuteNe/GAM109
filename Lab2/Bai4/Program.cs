using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GAM109.Lab.Lab2.Bai3;
using GAM109.Lab.Lab2.Bai4;

namespace GAM109.Lab.Lab2.Bai4
{
    public class Program
    {
        private static int i;

        static void Main(string[] args)
        {
            Console.WriteLine("Bắt đầu trò chơi!");

            Player player = new Player("Hero", 100);

            List<WaveData> waves = new List<WaveData>
            {
                new WaveData(1, new List<string> {"Goblin", "Goblin", "SkeletonArcher"}),
                new WaveData(2, new List<string> {"SkeletonArcher", "SkeletonArcher", "Goblin"}),
                new WaveData(3, new List<string> {"SkeletonArcher", "Goblin", "Goblin", "SkeletonArcher"})
            };

            WaveManager waveManager = new WaveManager(waves);
            LevelManager levelManager = new LevelManager();

            levelManager.RegisterEvent("BossArrival", new BossSpawnEvent());
            levelManager.RegisterEvent("HealingSpring", new HealZoneEvent(20));

            for (int i = 0; i < waves.Count; i++)
            {
                Console.WriteLine($"\n Bắt đầu đợt {i + 1}!");
                waveManager.LoadWave(i);

                while (!waveManager.IsWaveCleared())
                {
                    waveManager.SpawnNextEnemy();
                    if (!player.IsAlive)
                        break;

                    EnemyBase currentEnemy = waveManager.GetCurrentEnemy();
                    if (currentEnemy == null)
                        continue;

                    while (currentEnemy.Health > 0 && player.IsAlive)
                    {
                        int playerAttack = 10; // Giả sử người chơi tấn công 10 sát thương
                        Console.WriteLine($"{player.Name} tấn công {currentEnemy.Name} với {playerAttack} sát thương!");
                        currentEnemy.TakeDamage(playerAttack);

                        if (currentEnemy.Health <= 0)
                        {
                            player.Gold += currentEnemy.GoldDropped;
                            currentEnemy.Die();
                            break;
                        }

                        currentEnemy.PerformAttack(player);
                    }
                }
            }
            if (!player.IsAlive)
            {
                Console.WriteLine("Bạn đã chết! Game Over");
                return;
            }
            Console.WriteLine($"Đợt {i + 1} đã hoàn thành! Bạn đã thu thập được {player.Gold} vàng.");

            if (i == 1)
            {
                Console.WriteLine("\n Người chơi đã tìm thấy suối hồi máu và vùng xuất hiện Boss!");
                levelManager.ActivateLevelEvent("HealingSpring", player, waveManager);
                levelManager.ActivateLevelEvent("BossArrival", player, waveManager);

                EnemyBase boss = new Boss();

                while (boss.Health > 0 && player.IsAlive)
                {
                    Console.WriteLine($"{player.Name} tấn công Boss!");
                    boss.TakeDamage(25);

                    if (boss.Health <= 0)
                    {
                        boss.Die();
                        player.Gold += boss.GoldDropped;
                        break;
                    }

                    boss.PerformAttack(player);
                }

                if (!player.IsAlive)
                {
                    Console.WriteLine("Bạn đã bị Boss tiêu diet");
                }
            }
        }
    }
}