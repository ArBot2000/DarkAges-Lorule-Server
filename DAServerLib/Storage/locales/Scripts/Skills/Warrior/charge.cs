﻿using Darkages.Network.ServerFormats;
using Darkages.Types;
///************************************************************************
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

using System;
using System.Threading.Tasks;

namespace Darkages.Scripting.Scripts.Skills
{
    [Script("Charge", "Dean")]
    public class Charge : SkillScript
    {
        private readonly Random rand = new Random();
        public Skill _skill;

        public Sprite Target;

        public Charge(Skill skill) : base(skill)
        {
            _skill = skill;
        }

        public override void OnFailed(Sprite sprite)
        {
            if (sprite is Aisling)
            {
                var client = (sprite as Aisling).Client;

                client.SendMessage(0x02,
                    string.IsNullOrEmpty(Skill.Template.FailMessage) ? Skill.Template.FailMessage : "failed.");
            }
        }

        public override void OnSuccess(Sprite sprite)
        {
            var collided = false;

            var action = new ServerFormat1A
            {
                Serial = sprite.Serial,
                Number = 0x82,
                Speed = 20
            };

            for (var i = 0; i < 7; i++)
            {
                var targets = sprite.GetInfront(i, true);

                var hits = 0;
                foreach (var target in targets)
                {
                    if (target.Serial == sprite.Serial)
                        continue;

                    if (target != null)
                    {
                        var imp = (200 * hits) + Skill.Level;
                        var dmg = sprite.Str * 5 + sprite.Con * 5;

                        dmg += (dmg * imp / 100);

                        if (sprite.EmpoweredAssail)
                        {
                            if (sprite is Aisling)
                            {
                                if ((sprite as Aisling).Weapon == 0)
                                    dmg *= 3;
                            }
                        }

                        target.ApplyDamage(sprite, dmg, false, Skill.Template.Sound);
                        {
                            Target = target;
                        }

                        if (sprite is Aisling aisling)
                        {
                            var position = target.Position;

                            if (sprite.Direction == 0)
                                position.Y++;
                            if (sprite.Direction == 1)
                                position.X--;
                            if (sprite.Direction == 2)
                                position.Y--;
                            if (sprite.Direction == 3)
                                position.X++;


                            aisling.Client.WarpTo(position);
                        }
                    }

                    hits++;
                }

                if (hits > 0)
                {
                    collided = true;
                    break;
                }
            }

            Task.Delay(50).ContinueWith(dc =>
            {
                if (Target != null && collided)
                {
                    if (Target is Monster || Target is Mundane || Target is Aisling)
                        Target.Show(Scope.NearbyAislings,
                            new ServerFormat29((uint)sprite.Serial, (uint)Target.Serial,
                                Skill.Template.TargetAnimation, 0, 100));


                    sprite.Show(Scope.NearbyAislings, action);
                }
            }).Wait();
        }

        public override void OnUse(Sprite sprite)
        {
            if (!Skill.Ready)
                return;

            if (sprite is Aisling)
            {
                var client = (sprite as Aisling).Client;

                if (Skill.Ready)
                {
                    if (client.Aisling.Invisible && Skill.Template.PostQualifers.HasFlag(PostQualifer.BreakInvisible))
                    {
                        client.Aisling.Flags = AislingFlags.Normal;
                        client.Refresh();
                    }

                    client.TrainSkill(Skill);
                }
            }

            var success = Skill.RollDice(rand);

            if (success)
                OnSuccess(sprite);
            else
                OnFailed(sprite);
        }
    }
}