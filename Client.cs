using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{

    // app layer
    // magic (4)
    // length of encrypted data (8)
    // encrypted key (16)
    // encrypted data (...)

    // magic, encrypted length, encrypted key, encrypted iv, encrypted data
    public class Client
    {
        public string Key
        {
            get; set;
        }

        public void Send(byte[] data)
        {

        }
    }
}
