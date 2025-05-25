public class WaveData
{
    public int WaveID { get; set; }
    public List<string> EnemyTypes { get; set; } // Ví dụ: ["Goblin", "Goblin", "Orc"]

    public WaveData(int waveID, List<string> enemyTypes)
    {
        WaveID = waveID;
        EnemyTypes = enemyTypes;
    }
}
