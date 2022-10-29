using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer
{
    public class IODevice : Device
    {
        private GenericUI _ui;
        public void SendMessage()
        {

        }
        public void SetUI(GenericUI ui)
        {
            _ui = ui;
        }
    }
}
