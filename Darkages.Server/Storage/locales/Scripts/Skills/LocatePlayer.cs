﻿///************************************************************************
//Project Lorule: A Dark Ages Client (http://darkages.creatorlink.net/index/)
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

using System.Linq;
using Darkages.Scripting;
using Darkages.Types;
using ServiceStack.Text;
using static Darkages.Network.ServerFormats.ServerFormat0A;

namespace Darkages.Storage.locales.Scripts.Skills
{
    [Script("Locate Player", "Test")]
    public class LocatePlayer : SkillScript
    {
        public LocatePlayer(Skill skill) : base(skill)
        {
        }

        public override void OnUse(Sprite sprite)
        {
            var nearest = GetObjects<Aisling>(sprite.Map,
                    i => i.Serial != sprite.Serial && i.CurrentMapId == sprite.CurrentMapId)
                .OrderBy(i => i.Position.DistanceFrom(sprite.Position)).FirstOrDefault();

            //if (sprite is Aisling)
            //{
            //    var client = (sprite as Aisling).Client;

            //    if (nearest != null)
            //    {
            //        var prev = client.Aisling.Position;
            //        Position targetPosition = null;

            //        var blocks = nearest.Position.SurroundingContent(client.Aisling.Map);

            //        if (blocks.Length > 0)
            //        {
            //            var selections = blocks.Where(i => i.Content == TileContent.Item
            //                                               || i.Content == TileContent.Money
            //                                               || i.Content == TileContent.None).ToArray();

            //            var selection = selections
            //                .OrderByDescending(i => i.Position.DistanceFrom(client.Aisling.Position)).FirstOrDefault();
            //            if (selections.Length == 0 || selection == null)
            //            {
            //                client.SendMessageBox(0x02, "you can't do that.");
            //                return;
            //            }

            //            targetPosition = selection.Position;
            //        }

            //        if (targetPosition != null)
            //        {
            //            client.Aisling.XPos = targetPosition.X;
            //            client.Aisling.YPos = targetPosition.Y;


            //            if (!client.Aisling.Facing(nearest.XPos, nearest.YPos, out var direction))
            //            {
            //                client.Aisling.Direction = (byte) direction;

            //                if (client.Aisling.Position.IsNextTo(nearest.Position))
            //                    client.Aisling.Turn();
            //            }


            //            client.Refresh();
            //        }
            //    }
           // }

            OnSuccess(sprite);
        }

        public override void OnFailed(Sprite sprite)
        {
        }

        public override void OnSuccess(Sprite sprite)
        {
            if (sprite is Aisling aisling)
            {
                var msg = " Current Items\n";

                foreach (var iter in aisling.Inventory.Items)
                {
                    var item = iter.Value;
                    if (item == null)
                        continue;

                    msg += item.DisplayName + "\n";
                }

                aisling.Client.SendMessage(0x08, msg);
            }
        }
    }
}