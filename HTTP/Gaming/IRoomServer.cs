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

using OpenNetworkLibrary.HTTP.Authorization;
using OpenSharedLibrary.Credentials.Accounts;
using OpenSharedLibrary.Gaming.Rooms;

namespace OpenNetworkLibrary.HTTP.Gaming
{
    /// <summary>
    /// Room server interface
    /// </summary>
    public interface IRoomServer<TRoom, TAccount, TAccountFactory> : IAuthServer<TAccount, TAccountFactory>
        where TRoom : IRoom
        where TAccount : IAccount
        where TAccountFactory : IAccountFactory<TAccount>
    {
        /// <summary>
        /// Room concurrent collection
        /// </summary>
        public RoomDictionary<TRoom, TAccount> Rooms { get; }
    }
}