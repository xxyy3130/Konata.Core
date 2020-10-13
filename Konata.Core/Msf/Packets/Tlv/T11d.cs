﻿using System;

namespace Konata.Msf.Packets.Tlv
{
    public class T11dBody : TlvBody
    {
        public readonly uint _appId;
        public readonly byte[] _st;
        public readonly byte[] _stKey;

        public T11dBody(uint appId, byte[] st, byte[] stKey)
            : base()
        {
            _appId = appId;
            _st = st;
            _stKey = stKey;

            PutUintBE(_appId);
            PutBytes(_st);
            PutBytes(_stKey, 2);
        }

        public T11dBody(byte[] data)
            : base(data)
        {
            TakeUintBE(out _appId);
            TakeBytes(out _st, 16);
            TakeBytes(out _stKey, Prefix.Uint16);
        }
    }
}
