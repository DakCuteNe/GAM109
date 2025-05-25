using System;
using System.Collections.Generic;

// Simple EnemyBase class definition to resolve missing reference
public abstract class EnemyBase
{
    public abstract string Name { get; }
    public abstract int Health { get; }
}

// Example derived enemy classes
public class Goblin : EnemyBase
{
    public override string Name => "Goblin";
    public override int Health { get; } = 30;
}

public class Orc : EnemyBase
{
    public override string Name => "Orc";
    public override int Health { get; } = 50;
}

public class SkeletonArcher : EnemyBase
{
    public override string Name => "SkeletonArcher";
    public override int Health { get; } = 25;
}

public class WaveManager
{
    private List<WaveData> allWaves = new List<WaveData>();
    private List<EnemyBase> currentWaveEnemies = new List<EnemyBase>();
    private int currentWaveIndex = 0;
    private int spawnIndex = 0;

    public WaveManager(List<WaveData> waves)
    {
        allWaves = waves;
    }

    // Load đợt theo index, khởi tạo enemy tương ứng
    public void LoadWave(int waveIndex)
    {
        if (waveIndex < 0 || waveIndex >= allWaves.Count)
        {
            Console.WriteLine("Chỉ số đợt không hợp lệ.");
            return;
        }

        currentWaveEnemies.Clear();
        spawnIndex = 0;
        currentWaveIndex = waveIndex;

        WaveData wave = allWaves[waveIndex];
        foreach (string enemyName in wave.EnemyTypes)
        {
            EnemyBase enemy = CreateEnemyByName(enemyName);
            if (enemy != null)
                currentWaveEnemies.Add(enemy);
        }

        Console.WriteLine($"Đã tải đợt #{wave.WaveID} với {currentWaveEnemies.Count} kẻ địch.");
    }

    // Tạo Enemy từ tên
    private EnemyBase CreateEnemyByName(string name)
    {
        return name switch
        {
            "Goblin" => new Goblin(),
            "Orc" => new Orc(),
            "SkeletonArcher" => new SkeletonArcher(),
            _ => throw new ArgumentException($"Unknown enemy type: {name}")
        };
    }

    // Triệu hồi kẻ địch tiếp theo
    public void SpawnNextEnemy()
    {
        if (spawnIndex < currentWaveEnemies.Count)
        {
            EnemyBase enemy = currentWaveEnemies[spawnIndex];
            Console.WriteLine($"▶ Triệu hồi {enemy.Name}!");
            spawnIndex++;
        }
        else
        {
            Console.WriteLine("Không còn kẻ địch nào để triệu hồi.");
        }
    }

    // Kiểm tra xem tất cả kẻ địch đã chết chưa
    public bool IsWaveCleared()
    {
        foreach (var enemy in currentWaveEnemies)
        {
            if (enemy.Health > 0)
                return false;
        }
        return true;
    }

    // (Tuỳ chọn) Hiển thị trạng thái kẻ địch
    public void PrintWaveStatus()
    {
        Console.WriteLine($"Trạng thái đợt #{currentWaveIndex + 1}:");
        foreach (var enemy in currentWaveEnemies)
        {
            Console.WriteLine($"- {enemy.Name}: {enemy.Health} máu");
        }
    }

    internal GAM109.Lab.Lab2.EnemyBase GetCurrentEnemy()
    {
        throw new NotImplementedException();
    }
}
