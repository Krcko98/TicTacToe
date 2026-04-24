using System;

namespace Game.Save.Stats.Data
{
    public class UIStatData
    {
        public Func<string, string> statFormatter;
        public string data;

        public UIStatData(string data, Func<string, string> statFormatter)
        {
            this.data = data;
            this.statFormatter = statFormatter;
        }
    }
}