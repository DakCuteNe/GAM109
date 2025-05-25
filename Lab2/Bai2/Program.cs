// Simple Player class definition

public class Player
{
    private string v1;
    private int v2;

    public string Name { get; set; }
    public int Health { get; set; }
    public string PlayerName { get; internal set; }
    public int PlayerID { get; internal set; }

    public Player(int id, string name, int health)
    {
        Name = name;
        Health = health;
        v1 = name; // Initialize v1 with name
        v2 = id;   // Initialize v2 with id
        PlayerName = name; // Initialize PlayerName with name
        PlayerID = id;     // Initialize PlayerID with id
    }

    public Player(string v1, int v2)
    {
        this.v1 = v1;
        this.v2 = v2;
        Name = v1;
        PlayerName = v1;
    }

    internal void ShowInfo()
    {
        throw new NotImplementedException();
    }
}

// Renamed to avoid duplicate definition
class GameProgram
{
    static void Main(string[] args)
    {
        Player player = new Player("Hero", 100);

        // Tạo danh sách đợt
        List<WaveData> waves = new List<WaveData>
        {
            new WaveData(1, new List<string> { "Goblin", "Goblin", "SkeletonArcher" }),
            new WaveData(2, new List<string> { "Orc", "Goblin", "SkeletonArcher", "Orc" })
        };

        // Khởi tạo quản lý đợt
        WaveManager waveManager = new WaveManager(waves);

        // Load và triệu hồi đợt 1
        waveManager.LoadWave(0);

        while (true)
        {
            Console.WriteLine("\nNhấn phím bất kỳ để triệu hồi kẻ địch tiếp theo...");
            Console.ReadKey();

            waveManager.SpawnNextEnemy();
            waveManager.PrintWaveStatus();

            Console.WriteLine("\n(Đánh mỗi kẻ địch 1 lần để mô phỏng)");
            // Tấn công từng enemy một chút
            foreach (var enemy in waves[0].EnemyTypes)
            {
                // giả định người chơi gây sát thương (giả lập)
            }

            if (waveManager.IsWaveCleared())
            {
                Console.WriteLine("🔥 Đợt đã được dọn sạch!");
                break;
            }
        }
    }
}
