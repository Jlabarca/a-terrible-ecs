﻿using System;

namespace Online
{
    public interface INetwork
    {
        event Action<byte[]> DataReceived;

        /// <summary>
        /// Send data reliable ordered
        /// </summary>
        void Send(byte[] data);
    }
}
