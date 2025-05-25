using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAM109.Lab.Lab2.Bai3
{
    public interface ILevelEvent
    {
       void TriggerEvent(Player player, WaveManager waveManager);
    }
}