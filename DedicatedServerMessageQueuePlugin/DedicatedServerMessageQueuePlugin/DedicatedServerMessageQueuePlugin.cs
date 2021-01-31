using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VRage.Plugins;

namespace DedicatedServerMessageQueue
{
    public class DedicatedServerMessageQueuePlugin : IConfigurablePlugin
    {
        private DedicatedServerMessageQueuePluginConfiguration m_configuration;

        public void Init(object gameInstance)
        {
        }

        public void Update()
        {
        }

        public IPluginConfiguration GetConfiguration(string userDataPath)
        {
            if (m_configuration == null)
            {
                string configFile = Path.Combine(userDataPath, "DedicatedServerPlugin.cfg");
                if (File.Exists(configFile))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(DedicatedServerMessageQueuePluginConfiguration));
                    using (FileStream stream = File.OpenRead(configFile))
                    {
                        m_configuration = serializer.Deserialize(stream) as DedicatedServerMessageQueuePluginConfiguration;
                    }
                }

                if (m_configuration == null)
                {
                    m_configuration = new DedicatedServerMessageQueuePluginConfiguration();
                }
            }

            return m_configuration;
        }

        public void Dispose()
        {
            
        }

        public string GetPluginTitle()
        {
            return "DS Message Queue Plugin";
        }
    }
}
