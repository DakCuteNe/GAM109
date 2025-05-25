using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAM109.Lab.Lab2.Bai3
{
    public class LevelManager
    {
        private Dictionary<string, ILevelEvent> levelEvents = new Dictionary<string, ILevelEvent>();

        public void RegisterEvent(string name, ILevelEvent levelEvent)
        {
            if (!levelEvents.ContainsKey(name))
            {
                levelEvents.Add(name, levelEvent);
                Console.WriteLine($"Đã đăng ký sự kiện : {name}");
            }
        }


        public void ActivateLevelEvent(string eventName, Player player, WaveManager waveManager)
        {
            if (levelEvents.TryGetValue(eventName, out ILevelEvent? levelEvent) && levelEvent != null)
            {
                Console.WriteLine($"Kích hoạt sự kiện: {eventName}");
                levelEvent.TriggerEvent(player, waveManager);
            }
            else
            {
                Console.WriteLine($"Không tìm thấy sự kiện : {eventName}");
            }
        }

        internal void RegisterEvent(string v, HealZoneEvent healZoneEvent)
        {
            throw new NotImplementedException();
        }

        internal void ActivateLevelEvent(string v, Bai4.Player player, WaveManager waveManager)
        {
            throw new NotImplementedException();
        }
    }
}