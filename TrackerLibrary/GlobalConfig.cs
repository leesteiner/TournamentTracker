using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();
        public static void InitializeConnections(bool database, bool textFiles)
        {
            if (database)
            {
                // TODO - Set up the SQL Connection properly
                SqlConnection sql = new SqlConnection();
                Connections.Add(sql);
            }

            if (textFiles)
            {
                //TODO - Set up the Text Connection properly
                TextConnection txt = new TextConnection();
                Connections.Add(txt);
            }
        }
    }
}
