﻿///************************************************************************
//Project Lorule: A Dark Ages Server (http://darkages.creatorlink.net/index/)
//Copyright(C) 2018 TrippyInc Pty Ltd
//
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.
//
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//GNU General Public License for more details.
//
//You should have received a copy of the GNU General Public License
//along with this program.If not, see<http://www.gnu.org/licenses/>.
//*************************************************************************/
using Darkages.Types;

namespace Darkages.Network.ClientFormats
{
    public class ClientFormat30 : NetworkFormat
    {
        public override bool Secured => true;
        public override byte Command => 0x30;

        public Pane PaneType { get; set; }
        public byte MovingFrom { get; set; }
        public byte MovingTo { get; set; }

        public override void Serialize(NetworkPacketReader reader)
        {
            PaneType = (Pane)reader.ReadByte();
            MovingFrom = reader.ReadByte();
            MovingTo = reader.ReadByte();
        }

        public override void Serialize(NetworkPacketWriter writer)
        {
        }
    }
}