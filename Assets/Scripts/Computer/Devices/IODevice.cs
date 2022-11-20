using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer
{
    public class IODevice : Device
    {
        private GenericUI _ui;
        public ConsoleType[] UITypes = { };
        public void SendMessage()
        {

        }
        public void SetUI(GenericUI ui)
        {
            if (!UITypes.Contains(ui.Type))
            {
                throw new NotSupportedException(
                    $"IO Device '{this.GetType().Name}' does not support UI of type {ui.Type}"
                );
            }

            // If UI does not support multiple instances, and it's being used somewhere else
            //    Check other device for active user first
            //    Kick user off if priority higher?
            //    Warn, or ask for permission to move otherwise??

            _ui = ui;
        }
    }
}
