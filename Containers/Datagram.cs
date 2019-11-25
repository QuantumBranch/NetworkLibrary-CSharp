﻿
// Copyright 2019 Nikita Fediuchin (QuantumBranch)
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Net;

namespace QuantumBranch.OpenNetworkLibrary
{
    /// <summary>
    /// Datagram container structure
    /// </summary>
    public struct Datagram
    {
        /// <summary>
        /// Datagram header byte size in the data array
        /// </summary>
        public const int HeaderByteSize = 2;
        /// <summary>
        /// Index of the type value in the datagram data array
        /// </summary>
        public const int HeaderTypeIndex = 0;
        /// <summary>
        ///  Index of the number value in the datagram data array
        /// </summary>
        public const int HeaderNumberIndex = 1;

        /// <summary>
        /// Datagram data byte array
        /// </summary>
        public byte[] data;
        /// <summary>
        /// Datagram remote/local ip end point
        /// </summary>
        public IPEndPoint ipEndPoint;
        
        /// <summary>
        /// Returns datagram data byte array length
        /// </summary>
        public int Length => data.Length;

        /// <summary>
        /// Datagram first data array byte value
        /// </summary>
        public byte Type
        {
            get { return data[HeaderTypeIndex]; }
            set { data[HeaderTypeIndex] = value; }
        }
        /// <summary>
        /// Datagram second data array byte value
        /// </summary>
        public byte Number
        {
            get { return data[HeaderNumberIndex]; }
            set { data[HeaderNumberIndex] = value; }
        }

        /// <summary>
        /// Creates a new datagram structure instance
        /// </summary>
        public Datagram(byte[] data, IPEndPoint ipEndPoint)
        {
            this.data = data;
            this.ipEndPoint = ipEndPoint;
        }

        /// <summary>
        /// Sets header values to the datagram data array
        /// </summary>
        public void SetHeader(byte type, byte number)
        {
            SetHeader(data, type, number);
        }

        /// <summary>
        /// Sets header values to the data array
        /// </summary>
        public static void SetHeader(byte[] data, byte type, byte number)
        {
            data[HeaderTypeIndex] = type;
            data[HeaderNumberIndex] = number;
        }
    }
}