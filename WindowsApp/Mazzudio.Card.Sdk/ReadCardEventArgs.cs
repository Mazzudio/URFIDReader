using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mazzudio.Card.Sdk
{
    public class ReadCardEventArgs : EventArgs
    {
        public string UIDString { get; private set; }

        public byte[] UID { get; private set; }

        public ReadCardEventArgs(byte[] uid)
        {
            UID = uid;
            UIDString = BitConverter.ToString(uid).Replace("-", "");
        }
    }
}
