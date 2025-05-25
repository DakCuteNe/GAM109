using System;
using System.Collections.Generic;

namespace GAM109.Lab.Lab1
{
    // Bài 1 : Vũ khí
    public class Weapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        public Weapon(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }

        public virtual void Use()
        {
            Console.WriteLine("Sử dụng vũ khí.");
        }
    }

    public class Sword : Weapon
    {
        public int Durability { get; set; }

        public Sword(string name, int damage, int durability) : base(name, damage)
        {
            Durability = durability;
        }

        public override void Use()
        {
            if (Durability > 0)
            {
                Durability--;
                Console.WriteLine($"🗡️ Sử dụng kiếm {Name}, gây {Damage} sát thương. Độ bền còn: {Durability}");
            }
            else
            {
                Console.WriteLine($"🛠️ Kiếm {Name} đã hỏng.");
            }
        }
    }

    public class Bow : Weapon
    {
        public int ArrowCount { get; set; }

        public Bow(string name, int damage, int arrowcount) : base(name, damage)
        {
            ArrowCount = arrowcount;
        }

        public override void Use()
        {
            if (ArrowCount > 0)
            {
                ArrowCount--;
                Console.WriteLine($"🏹 Bắn cung {Name}, gây {Damage} sát thương. Mũi tên còn lại: {ArrowCount}");
            }
            else
            {
                Console.WriteLine($"⚠️ Cung {Name} đã hết tên!");
            }
        }
    }

    // Bài 2 : Sinh vật
    public class Creature
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public Creature(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public virtual void Move()
        {
            Console.WriteLine($"{Name} đang di chuyển.");
        }
    }

    public class Animal : Creature
    {
        public int Speed { get; set; }

        public Animal(string name, int health, int speed) : base(name, health)
        {
            Speed = speed;
        }

        public override void Move()
        {
            Console.WriteLine($"🐾 Động vật {Name} đang di chuyển với tốc độ {Speed}.");
        }
    }

    public class Monster : Creature
    {
        public float AttackRange { get; set; }

        public Monster(string name, int health, float attackrange) : base(name, health)
        {
            AttackRange = attackrange;
        }

        public override void Move()
        {
            Console.WriteLine($"👹 Quái vật {Name} lượn quanh với tầm tấn công {AttackRange}m.");
        }
    }

    // Bài 3 : Nhiệm vụ
    public class Tasks
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public Tasks(string title, string description)
        {
            Title = title;
            Description = description;
            IsCompleted = false;
        }

        public virtual void MarkAsCompleted()
        {
            IsCompleted = true;
            Console.WriteLine($"✅ Nhiệm vụ hoàn thành: {Title}");
        }
    }

    public class CollectItemTask : Tasks
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int Collected { get; set; }

        public CollectItemTask(string title, string description, string itemname, int quantity) : base(title, description)
        {
            ItemName = itemname;
            Quantity = quantity;
            Collected = 0;
        }

        public void Collect(int amount)
        {
            Collected += amount;
            Console.WriteLine($"📦 Thu thập {Collected}/{Quantity} {ItemName}");
        }

        public override void MarkAsCompleted()
        {
            if (Collected >= Quantity)
                base.MarkAsCompleted();
            else
                Console.WriteLine($"⚠️ Chưa đủ {ItemName} để hoàn thành nhiệm vụ!");
        }
    }

    public class DefeatEnemyTask : Tasks
    {
        public string EnemyType { get; set; }
        public int Count { get; set; }
        public int Defeated { get; set; }

        public DefeatEnemyTask(string title, string description, string enemytype, int count) : base(title, description)
        {
            EnemyType = enemytype;
            Count = count;
            Defeated = 0;
        }

        public void Defeat()
        {
            Defeated++;
            Console.WriteLine($"⚔️ Đã tiêu diệt {Defeated}/{Count} {EnemyType}");
        }

        public override void MarkAsCompleted()
        {
            if (Defeated >= Count)
                base.MarkAsCompleted();
            else
                Console.WriteLine($"⚠️ Chưa tiêu diệt đủ {EnemyType}!");
        }
    }

    // Bài 4 + 6 : Người chơi & Điểm cao
    public class Player
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public int Level { get; set; }

        public Player(int playerid, string playername, int level)
        {
            PlayerID = playerid;
            PlayerName = playername;
            Level = level;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"👤 ID: {PlayerID}, Tên: {PlayerName}, Cấp: {Level}");
        }
    }

    public class ScoreEntry
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }

        public ScoreEntry(string playername, int score)
        {
            PlayerName = playername;
            Score = score;
        }
    } 
}
