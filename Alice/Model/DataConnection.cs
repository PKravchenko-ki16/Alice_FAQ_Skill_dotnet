using System;
using System.Collections.Generic;
using System.Text;

namespace Alice.Model
{
    public class DataConnection
    {
        private static DataConnection instance;

        public string dataPosition { get; private set; }
        public string dataManager { get; private set; }
        public string dataStain { get; private set; }
        public string dataOldStain { get; private set; }

        protected DataConnection()
        {
            this.dataPosition = "../../../../dataPosition.json";
            this.dataManager = "../../../../dataManager.json";
            this.dataStain = "../../../../dataStain.json";
            this.dataOldStain = "../../../../dataOldStain.json";
        }

        public static DataConnection getDataConnection()
        {
            if (instance == null)
                instance = new DataConnection();
            return instance;
        }
    }
}
