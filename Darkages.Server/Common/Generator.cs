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
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using static Darkages.Types.ElementManager;

namespace Darkages.Common
{
    public static class Generator
    {
        public static volatile int SERIAL;

        static Generator()
        {
            Random = new Random();
            GeneratedNumbers = new Collection<int>();
            GeneratedStrings = new Collection<string>();
        }

        public static Random Random { get; }
        public static Collection<int> GeneratedNumbers { get; }
        public static Collection<string> GeneratedStrings { get; }


        public static T RandomEnumValue<T>()
        {
            lock (Random)
            {
                var v = Enum.GetValues(typeof(T));
                return (T)v.GetValue(Random.Next(1, v.Length));
            }
        }

        public static int GenerateNumber()
        {
            uint id = 0;

            lock (Random)
            {
                do
                {
                    if (ServerContext.Config?.UseIncrementalSerials ?? false)
                        Interlocked.Increment(ref SERIAL);
                    else
                        id = (uint)Random.Next();
                } while (GeneratedNumbers
                    .Contains(ServerContext.Config?.UseIncrementalSerials ?? false ? SERIAL : (int)id));
            }

            if (ServerContext.Config?.UseIncrementalSerials ?? false)
                return SERIAL;

            lock (Random)
            {
                GeneratedNumbers.Add(SERIAL);
            }

            return (int)id;
        }

        public static string CreateString(int size)
        {
            var value = new StringBuilder();

            for (var i = 0; i < size; i++)
            {
                var binary = Random.Next(0, 2);

                switch (binary)
                {
                    case 0:
                        value.Append(Convert.ToChar(Random.Next(65, 91)));
                        break;

                    case 1:
                        value.Append(Random.Next(1, 10));
                        break;
                }
            }

            return value.ToString();
        }

        public static string GenerateString(int size)
        {
            string s;

            do
            {
                s = CreateString(size);
            } while (GeneratedStrings.Contains(s));

            GeneratedStrings.Add(s);

            return s;
        }
    }
}
