using System;
using System.Collections.Generic;
using GAM109.Lab.Lab1;
using static GAM109.Lab.Lab1.Player;

class Program
{
    static void Main()
    {
        List<Player> players = new List<Player>();
        List<ScoreEntry> highScores = new List<ScoreEntry>();

        while (true)
        {
            Console.WriteLine("\n=== MENU CHÍNH ===");
            Console.WriteLine("1. Vũ khí");
            Console.WriteLine("2. Sinh vật");
            Console.WriteLine("3. Nhiệm vụ");
            Console.WriteLine("4. Quản lý người chơi");
            Console.WriteLine("5. Quản lý điểm cao");
            Console.WriteLine("6. Thống kê rơi vật phẩm");
            Console.WriteLine("0. Thoát");
            Console.Write("👉 Chọn bài: ");
            string choice = Console.ReadLine() ?? string.Empty;

            switch (choice)
            {
                case "1":
                    Weapon sword = new Sword("Excalibur", 50, 3);
                    Weapon bow = new Bow("Longbow", 30, 5);
                    sword.Use();
                    bow.Use();
                    break;

                case "2":
                    Creature deer = new Animal("Hươu", 100, 20);
                    Creature orc = new Monster("Orc", 150, 6.0f);
                    deer.Move();
                    orc.Move();
                    break;

                case "3":
                    var collectTask = new CollectItemTask("Thu thập đá", "Thu thập 10 viên đá", "Đá", 10);
                    collectTask.Collect(6);
                    collectTask.Collect(4);
                    collectTask.MarkAsCompleted();

                    var defeatTask = new DefeatEnemyTask("Tiêu diệt goblin", "Diệt 3 goblin", "Goblin", 3);
                    defeatTask.Defeat();
                    defeatTask.Defeat();
                    defeatTask.Defeat();
                    defeatTask.MarkAsCompleted();
                    break;

                case "4":
                    ManagePlayers(players);
                    break;

                case "5":
                    ManageHighScores(highScores);
                    break;
                    case "6":
                    SimulateItemDrops();
                    break;

                case "0":
                    Console.WriteLine("👋 Tạm biệt!");
                    return;

                default:
                    Console.WriteLine("⚠️ Lựa chọn không hợp lệ.");
                    break;
            }
        }
    }

    static void ManageHighScores(List<ScoreEntry> highScores)
    {
        highScores.Clear();
        highScores.Add(new ScoreEntry("John", 200));
        highScores.Add(new ScoreEntry("Alice", 300));
        highScores.Add(new ScoreEntry("Bob", 150));
        highScores.Add(new ScoreEntry("Charlie", 250));
        highScores.Add(new ScoreEntry("Eve", 350));
        highScores.Add(new ScoreEntry("Dave", 180));
        highScores.Add(new ScoreEntry("Frank", 220));

        highScores.Sort((x, y) => y.Score.CompareTo(x.Score));

        if (highScores.Count > 5)
            highScores = highScores.GetRange(0, 5);

        Console.WriteLine("\n=== 🏆BẢNG ĐIỂM CAO ===");
        foreach (var s in highScores)
        {
                Console.WriteLine($"- {s.PlayerName}: {s.Score}");
        }
    }

    static void ManagePlayers(List<Player> players)
    {
        while (true)
        {
            Console.WriteLine("\n=== QUẢN LÝ NGƯỜI CHƠI ===");
            Console.WriteLine("1. Thêm người chơi");
            Console.WriteLine("2. Xóa người chơi theo ID");
            Console.WriteLine("3. Tìm người chơi theo tên");
            Console.WriteLine("4. Hiển thị tất cả");
            Console.WriteLine("0. Quay lại");
            Console.Write("👉 Chọn: ");
            string input = Console.ReadLine() ?? string.Empty;

            switch (input)
            {
                case "1":
                    Console.Write("ID: ");
                    string idInput = Console.ReadLine() ?? string.Empty;
                    if (!int.TryParse(idInput, out int id))
                    {
                        Console.WriteLine("⚠️ ID không hợp lệ.");
                        break;
                    }
                    Console.Write("Tên: ");
                    string name = Console.ReadLine() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("⚠️ Tên không được để trống.");
                        break;
                    }
                    Console.Write("Cấp độ: ");
                    string levelInput = Console.ReadLine() ?? string.Empty;
                    if (!int.TryParse(levelInput, out int level))
                    {
                        Console.WriteLine("⚠️ Cấp độ không hợp lệ.");
                        break;
                    }

                    players.Add(new Player(id, name, level));
                    Console.WriteLine("✅ Đã thêm người chơi.");
                    break;

                case "2":
                    Console.Write("ID cần xóa: ");
                    string delIdInput = Console.ReadLine() ?? string.Empty;
                    if (!int.TryParse(delIdInput, out int delId))
                    {
                        Console.WriteLine("⚠️ ID không hợp lệ.");
                        break;
                    }
                    var pToRemove = players.Find(p => p.PlayerID == delId);
                    if (pToRemove != null)
                    {
                        players.Remove(pToRemove);
                        Console.WriteLine("✅ Đã xóa.");
                    }
                    else
                    {
                        Console.WriteLine("❌ Không tìm thấy.");
                    }
                    break;

                case "3":
                    Console.Write("Tên cần tìm: ");
                    string search = Console.ReadLine() ?? string.Empty;
                    var found = players.FindAll(p => p.PlayerName == search);
                    if (found.Count > 0)
                        found.ForEach(p => p.ShowInfo());
                    else
                        Console.WriteLine("❌ Không có kết quả.");
                    break;

                case "4":
                    if (players.Count == 0)
                        Console.WriteLine("📭 Không có người chơi.");
                    else
                        players.ForEach(p => p.ShowInfo());
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("⚠️ Lựa chọn sai.");
                    break;
            }
        }
    }
    static void SimulateItemDrops()
    {
        Dictionary<string, int> itemDrops = new Dictionary<string, int>();
        string[] items = { "Sword", "Shield", "Potion", "Gold" };
        Random rnd = new Random();

        Console.WriteLine("Nhập số lần rơi vật phẩm:");
        if (!int.TryParse(Console.ReadLine(), out int times))
        {
            Console.WriteLine("⚠️ Số lần rơi không hợp lệ.");
            return;
        }

        for (int i = 0; i < times; i++)
        {
            string dropped = items[rnd.Next(items.Length)];
            if (itemDrops.ContainsKey(dropped))
            {
                itemDrops[dropped]++;
            }
            else
            {
                itemDrops[dropped] = 1;
            }
        }

        Console.WriteLine("\n📦 Thống kê vật phẩm đã rơi ra:");
        foreach (var kvp in itemDrops)
        {
            Console.WriteLine($"- {kvp.Key}: {kvp.Value} lần");
        }
    }
}
