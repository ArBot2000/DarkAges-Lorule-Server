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

using System.Threading.Tasks;
using Darkages.Network;

namespace Darkages.Security
{
    public sealed class SecurityProvider
    {
        #region Tree

        public static readonly byte[][] tree =
        {
            new byte[]
            {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
                0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F,
                0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
                0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
                0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F,
                0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A, 0x5B, 0x5C, 0x5D, 0x5E, 0x5F,
                0x60, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6A, 0x6B, 0x6C, 0x6D, 0x6E, 0x6F,
                0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x78, 0x79, 0x7A, 0x7B, 0x7C, 0x7D, 0x7E, 0x7F,
                0x80, 0x81, 0x82, 0x83, 0x84, 0x85, 0x86, 0x87, 0x88, 0x89, 0x8A, 0x8B, 0x8C, 0x8D, 0x8E, 0x8F,
                0x90, 0x91, 0x92, 0x93, 0x94, 0x95, 0x96, 0x97, 0x98, 0x99, 0x9A, 0x9B, 0x9C, 0x9D, 0x9E, 0x9F,
                0xA0, 0xA1, 0xA2, 0xA3, 0xA4, 0xA5, 0xA6, 0xA7, 0xA8, 0xA9, 0xAA, 0xAB, 0xAC, 0xAD, 0xAE, 0xAF,
                0xB0, 0xB1, 0xB2, 0xB3, 0xB4, 0xB5, 0xB6, 0xB7, 0xB8, 0xB9, 0xBA, 0xBB, 0xBC, 0xBD, 0xBE, 0xBF,
                0xC0, 0xC1, 0xC2, 0xC3, 0xC4, 0xC5, 0xC6, 0xC7, 0xC8, 0xC9, 0xCA, 0xCB, 0xCC, 0xCD, 0xCE, 0xCF,
                0xD0, 0xD1, 0xD2, 0xD3, 0xD4, 0xD5, 0xD6, 0xD7, 0xD8, 0xD9, 0xDA, 0xDB, 0xDC, 0xDD, 0xDE, 0xDF,
                0xE0, 0xE1, 0xE2, 0xE3, 0xE4, 0xE5, 0xE6, 0xE7, 0xE8, 0xE9, 0xEA, 0xEB, 0xEC, 0xED, 0xEE, 0xEF,
                0xF0, 0xF1, 0xF2, 0xF3, 0xF4, 0xF5, 0xF6, 0xF7, 0xF8, 0xF9, 0xFA, 0xFB, 0xFC, 0xFD, 0xFE, 0xFF
            },
            new byte[]
            {
                0x80, 0x7F, 0x81, 0x7E, 0x82, 0x7D, 0x83, 0x7C, 0x84, 0x7B, 0x85, 0x7A, 0x86, 0x79, 0x87, 0x78,
                0x88, 0x77, 0x89, 0x76, 0x8A, 0x75, 0x8B, 0x74, 0x8C, 0x73, 0x8D, 0x72, 0x8E, 0x71, 0x8F, 0x70,
                0x90, 0x6F, 0x91, 0x6E, 0x92, 0x6D, 0x93, 0x6C, 0x94, 0x6B, 0x95, 0x6A, 0x96, 0x69, 0x97, 0x68,
                0x98, 0x67, 0x99, 0x66, 0x9A, 0x65, 0x9B, 0x64, 0x9C, 0x63, 0x9D, 0x62, 0x9E, 0x61, 0x9F, 0x60,
                0xA0, 0x5F, 0xA1, 0x5E, 0xA2, 0x5D, 0xA3, 0x5C, 0xA4, 0x5B, 0xA5, 0x5A, 0xA6, 0x59, 0xA7, 0x58,
                0xA8, 0x57, 0xA9, 0x56, 0xAA, 0x55, 0xAB, 0x54, 0xAC, 0x53, 0xAD, 0x52, 0xAE, 0x51, 0xAF, 0x50,
                0xB0, 0x4F, 0xB1, 0x4E, 0xB2, 0x4D, 0xB3, 0x4C, 0xB4, 0x4B, 0xB5, 0x4A, 0xB6, 0x49, 0xB7, 0x48,
                0xB8, 0x47, 0xB9, 0x46, 0xBA, 0x45, 0xBB, 0x44, 0xBC, 0x43, 0xBD, 0x42, 0xBE, 0x41, 0xBF, 0x40,
                0xC0, 0x3F, 0xC1, 0x3E, 0xC2, 0x3D, 0xC3, 0x3C, 0xC4, 0x3B, 0xC5, 0x3A, 0xC6, 0x39, 0xC7, 0x38,
                0xC8, 0x37, 0xC9, 0x36, 0xCA, 0x35, 0xCB, 0x34, 0xCC, 0x33, 0xCD, 0x32, 0xCE, 0x31, 0xCF, 0x30,
                0xD0, 0x2F, 0xD1, 0x2E, 0xD2, 0x2D, 0xD3, 0x2C, 0xD4, 0x2B, 0xD5, 0x2A, 0xD6, 0x29, 0xD7, 0x28,
                0xD8, 0x27, 0xD9, 0x26, 0xDA, 0x25, 0xDB, 0x24, 0xDC, 0x23, 0xDD, 0x22, 0xDE, 0x21, 0xDF, 0x20,
                0xE0, 0x1F, 0xE1, 0x1E, 0xE2, 0x1D, 0xE3, 0x1C, 0xE4, 0x1B, 0xE5, 0x1A, 0xE6, 0x19, 0xE7, 0x18,
                0xE8, 0x17, 0xE9, 0x16, 0xEA, 0x15, 0xEB, 0x14, 0xEC, 0x13, 0xED, 0x12, 0xEE, 0x11, 0xEF, 0x10,
                0xF0, 0x0F, 0xF1, 0x0E, 0xF2, 0x0D, 0xF3, 0x0C, 0xF4, 0x0B, 0xF5, 0x0A, 0xF6, 0x09, 0xF7, 0x08,
                0xF8, 0x07, 0xF9, 0x06, 0xFA, 0x05, 0xFB, 0x04, 0xFC, 0x03, 0xFD, 0x02, 0xFE, 0x01, 0xFF, 0x00
            },
            new byte[]
            {
                0xFF, 0xFE, 0xFD, 0xFC, 0xFB, 0xFA, 0xF9, 0xF8, 0xF7, 0xF6, 0xF5, 0xF4, 0xF3, 0xF2, 0xF1, 0xF0,
                0xEF, 0xEE, 0xED, 0xEC, 0xEB, 0xEA, 0xE9, 0xE8, 0xE7, 0xE6, 0xE5, 0xE4, 0xE3, 0xE2, 0xE1, 0xE0,
                0xDF, 0xDE, 0xDD, 0xDC, 0xDB, 0xDA, 0xD9, 0xD8, 0xD7, 0xD6, 0xD5, 0xD4, 0xD3, 0xD2, 0xD1, 0xD0,
                0xCF, 0xCE, 0xCD, 0xCC, 0xCB, 0xCA, 0xC9, 0xC8, 0xC7, 0xC6, 0xC5, 0xC4, 0xC3, 0xC2, 0xC1, 0xC0,
                0xBF, 0xBE, 0xBD, 0xBC, 0xBB, 0xBA, 0xB9, 0xB8, 0xB7, 0xB6, 0xB5, 0xB4, 0xB3, 0xB2, 0xB1, 0xB0,
                0xAF, 0xAE, 0xAD, 0xAC, 0xAB, 0xAA, 0xA9, 0xA8, 0xA7, 0xA6, 0xA5, 0xA4, 0xA3, 0xA2, 0xA1, 0xA0,
                0x9F, 0x9E, 0x9D, 0x9C, 0x9B, 0x9A, 0x99, 0x98, 0x97, 0x96, 0x95, 0x94, 0x93, 0x92, 0x91, 0x90,
                0x8F, 0x8E, 0x8D, 0x8C, 0x8B, 0x8A, 0x89, 0x88, 0x87, 0x86, 0x85, 0x84, 0x83, 0x82, 0x81, 0x80,
                0x7F, 0x7E, 0x7D, 0x7C, 0x7B, 0x7A, 0x79, 0x78, 0x77, 0x76, 0x75, 0x74, 0x73, 0x72, 0x71, 0x70,
                0x6F, 0x6E, 0x6D, 0x6C, 0x6B, 0x6A, 0x69, 0x68, 0x67, 0x66, 0x65, 0x64, 0x63, 0x62, 0x61, 0x60,
                0x5F, 0x5E, 0x5D, 0x5C, 0x5B, 0x5A, 0x59, 0x58, 0x57, 0x56, 0x55, 0x54, 0x53, 0x52, 0x51, 0x50,
                0x4F, 0x4E, 0x4D, 0x4C, 0x4B, 0x4A, 0x49, 0x48, 0x47, 0x46, 0x45, 0x44, 0x43, 0x42, 0x41, 0x40,
                0x3F, 0x3E, 0x3D, 0x3C, 0x3B, 0x3A, 0x39, 0x38, 0x37, 0x36, 0x35, 0x34, 0x33, 0x32, 0x31, 0x30,
                0x2F, 0x2E, 0x2D, 0x2C, 0x2B, 0x2A, 0x29, 0x28, 0x27, 0x26, 0x25, 0x24, 0x23, 0x22, 0x21, 0x20,
                0x1F, 0x1E, 0x1D, 0x1C, 0x1B, 0x1A, 0x19, 0x18, 0x17, 0x16, 0x15, 0x14, 0x13, 0x12, 0x11, 0x10,
                0x0F, 0x0E, 0x0D, 0x0C, 0x0B, 0x0A, 0x09, 0x08, 0x07, 0x06, 0x05, 0x04, 0x03, 0x02, 0x01, 0x00
            },
            new byte[]
            {
                0xFF, 0x01, 0xFE, 0x02, 0xFD, 0x03, 0xFC, 0x04, 0xFB, 0x05, 0xFA, 0x06, 0xF9, 0x07, 0xF8, 0x08,
                0xF7, 0x09, 0xF6, 0x0A, 0xF5, 0x0B, 0xF4, 0x0C, 0xF3, 0x0D, 0xF2, 0x0E, 0xF1, 0x0F, 0xF0, 0x10,
                0xEF, 0x11, 0xEE, 0x12, 0xED, 0x13, 0xEC, 0x14, 0xEB, 0x15, 0xEA, 0x16, 0xE9, 0x17, 0xE8, 0x18,
                0xE7, 0x19, 0xE6, 0x1A, 0xE5, 0x1B, 0xE4, 0x1C, 0xE3, 0x1D, 0xE2, 0x1E, 0xE1, 0x1F, 0xE0, 0x20,
                0xDF, 0x21, 0xDE, 0x22, 0xDD, 0x23, 0xDC, 0x24, 0xDB, 0x25, 0xDA, 0x26, 0xD9, 0x27, 0xD8, 0x28,
                0xD7, 0x29, 0xD6, 0x2A, 0xD5, 0x2B, 0xD4, 0x2C, 0xD3, 0x2D, 0xD2, 0x2E, 0xD1, 0x2F, 0xD0, 0x30,
                0xCF, 0x31, 0xCE, 0x32, 0xCD, 0x33, 0xCC, 0x34, 0xCB, 0x35, 0xCA, 0x36, 0xC9, 0x37, 0xC8, 0x38,
                0xC7, 0x39, 0xC6, 0x3A, 0xC5, 0x3B, 0xC4, 0x3C, 0xC3, 0x3D, 0xC2, 0x3E, 0xC1, 0x3F, 0xC0, 0x40,
                0xBF, 0x41, 0xBE, 0x42, 0xBD, 0x43, 0xBC, 0x44, 0xBB, 0x45, 0xBA, 0x46, 0xB9, 0x47, 0xB8, 0x48,
                0xB7, 0x49, 0xB6, 0x4A, 0xB5, 0x4B, 0xB4, 0x4C, 0xB3, 0x4D, 0xB2, 0x4E, 0xB1, 0x4F, 0xB0, 0x50,
                0xAF, 0x51, 0xAE, 0x52, 0xAD, 0x53, 0xAC, 0x54, 0xAB, 0x55, 0xAA, 0x56, 0xA9, 0x57, 0xA8, 0x58,
                0xA7, 0x59, 0xA6, 0x5A, 0xA5, 0x5B, 0xA4, 0x5C, 0xA3, 0x5D, 0xA2, 0x5E, 0xA1, 0x5F, 0xA0, 0x60,
                0x9F, 0x61, 0x9E, 0x62, 0x9D, 0x63, 0x9C, 0x64, 0x9B, 0x65, 0x9A, 0x66, 0x99, 0x67, 0x98, 0x68,
                0x97, 0x69, 0x96, 0x6A, 0x95, 0x6B, 0x94, 0x6C, 0x93, 0x6D, 0x92, 0x6E, 0x91, 0x6F, 0x90, 0x70,
                0x8F, 0x71, 0x8E, 0x72, 0x8D, 0x73, 0x8C, 0x74, 0x8B, 0x75, 0x8A, 0x76, 0x89, 0x77, 0x88, 0x78,
                0x87, 0x79, 0x86, 0x7A, 0x85, 0x7B, 0x84, 0x7C, 0x83, 0x7D, 0x82, 0x7E, 0x81, 0x7F, 0x80, 0x80
            },
            new byte[]
            {
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01,
                0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04,
                0x09, 0x09, 0x09, 0x09, 0x09, 0x09, 0x09, 0x09, 0x09, 0x09, 0x09, 0x09, 0x09, 0x09, 0x09, 0x09,
                0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10,
                0x19, 0x19, 0x19, 0x19, 0x19, 0x19, 0x19, 0x19, 0x19, 0x19, 0x19, 0x19, 0x19, 0x19, 0x19, 0x19,
                0x24, 0x24, 0x24, 0x24, 0x24, 0x24, 0x24, 0x24, 0x24, 0x24, 0x24, 0x24, 0x24, 0x24, 0x24, 0x24,
                0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31,
                0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40,
                0x51, 0x51, 0x51, 0x51, 0x51, 0x51, 0x51, 0x51, 0x51, 0x51, 0x51, 0x51, 0x51, 0x51, 0x51, 0x51,
                0x64, 0x64, 0x64, 0x64, 0x64, 0x64, 0x64, 0x64, 0x64, 0x64, 0x64, 0x64, 0x64, 0x64, 0x64, 0x64,
                0x79, 0x79, 0x79, 0x79, 0x79, 0x79, 0x79, 0x79, 0x79, 0x79, 0x79, 0x79, 0x79, 0x79, 0x79, 0x79,
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90,
                0xA9, 0xA9, 0xA9, 0xA9, 0xA9, 0xA9, 0xA9, 0xA9, 0xA9, 0xA9, 0xA9, 0xA9, 0xA9, 0xA9, 0xA9, 0xA9,
                0xC4, 0xC4, 0xC4, 0xC4, 0xC4, 0xC4, 0xC4, 0xC4, 0xC4, 0xC4, 0xC4, 0xC4, 0xC4, 0xC4, 0xC4, 0xC4,
                0xE1, 0xE1, 0xE1, 0xE1, 0xE1, 0xE1, 0xE1, 0xE1, 0xE1, 0xE1, 0xE1, 0xE1, 0xE1, 0xE1, 0xE1, 0xE1
            },
            new byte[]
            {
                0x00, 0x02, 0x04, 0x06, 0x08, 0x0A, 0x0C, 0x0E, 0x10, 0x12, 0x14, 0x16, 0x18, 0x1A, 0x1C, 0x1E,
                0x20, 0x22, 0x24, 0x26, 0x28, 0x2A, 0x2C, 0x2E, 0x30, 0x32, 0x34, 0x36, 0x38, 0x3A, 0x3C, 0x3E,
                0x40, 0x42, 0x44, 0x46, 0x48, 0x4A, 0x4C, 0x4E, 0x50, 0x52, 0x54, 0x56, 0x58, 0x5A, 0x5C, 0x5E,
                0x60, 0x62, 0x64, 0x66, 0x68, 0x6A, 0x6C, 0x6E, 0x70, 0x72, 0x74, 0x76, 0x78, 0x7A, 0x7C, 0x7E,
                0x80, 0x82, 0x84, 0x86, 0x88, 0x8A, 0x8C, 0x8E, 0x90, 0x92, 0x94, 0x96, 0x98, 0x9A, 0x9C, 0x9E,
                0xA0, 0xA2, 0xA4, 0xA6, 0xA8, 0xAA, 0xAC, 0xAE, 0xB0, 0xB2, 0xB4, 0xB6, 0xB8, 0xBA, 0xBC, 0xBE,
                0xC0, 0xC2, 0xC4, 0xC6, 0xC8, 0xCA, 0xCC, 0xCE, 0xD0, 0xD2, 0xD4, 0xD6, 0xD8, 0xDA, 0xDC, 0xDE,
                0xE0, 0xE2, 0xE4, 0xE6, 0xE8, 0xEA, 0xEC, 0xEE, 0xF0, 0xF2, 0xF4, 0xF6, 0xF8, 0xFA, 0xFC, 0xFE,
                0x00, 0x02, 0x04, 0x06, 0x08, 0x0A, 0x0C, 0x0E, 0x10, 0x12, 0x14, 0x16, 0x18, 0x1A, 0x1C, 0x1E,
                0x20, 0x22, 0x24, 0x26, 0x28, 0x2A, 0x2C, 0x2E, 0x30, 0x32, 0x34, 0x36, 0x38, 0x3A, 0x3C, 0x3E,
                0x40, 0x42, 0x44, 0x46, 0x48, 0x4A, 0x4C, 0x4E, 0x50, 0x52, 0x54, 0x56, 0x58, 0x5A, 0x5C, 0x5E,
                0x60, 0x62, 0x64, 0x66, 0x68, 0x6A, 0x6C, 0x6E, 0x70, 0x72, 0x74, 0x76, 0x78, 0x7A, 0x7C, 0x7E,
                0x80, 0x82, 0x84, 0x86, 0x88, 0x8A, 0x8C, 0x8E, 0x90, 0x92, 0x94, 0x96, 0x98, 0x9A, 0x9C, 0x9E,
                0xA0, 0xA2, 0xA4, 0xA6, 0xA8, 0xAA, 0xAC, 0xAE, 0xB0, 0xB2, 0xB4, 0xB6, 0xB8, 0xBA, 0xBC, 0xBE,
                0xC0, 0xC2, 0xC4, 0xC6, 0xC8, 0xCA, 0xCC, 0xCE, 0xD0, 0xD2, 0xD4, 0xD6, 0xD8, 0xDA, 0xDC, 0xDE,
                0xE0, 0xE2, 0xE4, 0xE6, 0xE8, 0xEA, 0xEC, 0xEE, 0xF0, 0xF2, 0xF4, 0xF6, 0xF8, 0xFA, 0xFC, 0xFE
            },
            new byte[]
            {
                0xFF, 0xFD, 0xFB, 0xF9, 0xF7, 0xF5, 0xF3, 0xF1, 0xEF, 0xED, 0xEB, 0xE9, 0xE7, 0xE5, 0xE3, 0xE1,
                0xDF, 0xDD, 0xDB, 0xD9, 0xD7, 0xD5, 0xD3, 0xD1, 0xCF, 0xCD, 0xCB, 0xC9, 0xC7, 0xC5, 0xC3, 0xC1,
                0xBF, 0xBD, 0xBB, 0xB9, 0xB7, 0xB5, 0xB3, 0xB1, 0xAF, 0xAD, 0xAB, 0xA9, 0xA7, 0xA5, 0xA3, 0xA1,
                0x9F, 0x9D, 0x9B, 0x99, 0x97, 0x95, 0x93, 0x91, 0x8F, 0x8D, 0x8B, 0x89, 0x87, 0x85, 0x83, 0x81,
                0x7F, 0x7D, 0x7B, 0x79, 0x77, 0x75, 0x73, 0x71, 0x6F, 0x6D, 0x6B, 0x69, 0x67, 0x65, 0x63, 0x61,
                0x5F, 0x5D, 0x5B, 0x59, 0x57, 0x55, 0x53, 0x51, 0x4F, 0x4D, 0x4B, 0x49, 0x47, 0x45, 0x43, 0x41,
                0x3F, 0x3D, 0x3B, 0x39, 0x37, 0x35, 0x33, 0x31, 0x2F, 0x2D, 0x2B, 0x29, 0x27, 0x25, 0x23, 0x21,
                0x1F, 0x1D, 0x1B, 0x19, 0x17, 0x15, 0x13, 0x11, 0x0F, 0x0D, 0x0B, 0x09, 0x07, 0x05, 0x03, 0x01,
                0xFF, 0xFD, 0xFB, 0xF9, 0xF7, 0xF5, 0xF3, 0xF1, 0xEF, 0xED, 0xEB, 0xE9, 0xE7, 0xE5, 0xE3, 0xE1,
                0xDF, 0xDD, 0xDB, 0xD9, 0xD7, 0xD5, 0xD3, 0xD1, 0xCF, 0xCD, 0xCB, 0xC9, 0xC7, 0xC5, 0xC3, 0xC1,
                0xBF, 0xBD, 0xBB, 0xB9, 0xB7, 0xB5, 0xB3, 0xB1, 0xAF, 0xAD, 0xAB, 0xA9, 0xA7, 0xA5, 0xA3, 0xA1,
                0x9F, 0x9D, 0x9B, 0x99, 0x97, 0x95, 0x93, 0x91, 0x8F, 0x8D, 0x8B, 0x89, 0x87, 0x85, 0x83, 0x81,
                0x7F, 0x7D, 0x7B, 0x79, 0x77, 0x75, 0x73, 0x71, 0x6F, 0x6D, 0x6B, 0x69, 0x67, 0x65, 0x63, 0x61,
                0x5F, 0x5D, 0x5B, 0x59, 0x57, 0x55, 0x53, 0x51, 0x4F, 0x4D, 0x4B, 0x49, 0x47, 0x45, 0x43, 0x41,
                0x3F, 0x3D, 0x3B, 0x39, 0x37, 0x35, 0x33, 0x31, 0x2F, 0x2D, 0x2B, 0x29, 0x27, 0x25, 0x23, 0x21,
                0x1F, 0x1D, 0x1B, 0x19, 0x17, 0x15, 0x13, 0x11, 0x0F, 0x0D, 0x0B, 0x09, 0x07, 0x05, 0x03, 0x01
            },
            new byte[]
            {
                0xFF, 0xFD, 0xFB, 0xF9, 0xF7, 0xF5, 0xF3, 0xF1, 0xEF, 0xED, 0xEB, 0xE9, 0xE7, 0xE5, 0xE3, 0xE1,
                0xDF, 0xDD, 0xDB, 0xD9, 0xD7, 0xD5, 0xD3, 0xD1, 0xCF, 0xCD, 0xCB, 0xC9, 0xC7, 0xC5, 0xC3, 0xC1,
                0xBF, 0xBD, 0xBB, 0xB9, 0xB7, 0xB5, 0xB3, 0xB1, 0xAF, 0xAD, 0xAB, 0xA9, 0xA7, 0xA5, 0xA3, 0xA1,
                0x9F, 0x9D, 0x9B, 0x99, 0x97, 0x95, 0x93, 0x91, 0x8F, 0x8D, 0x8B, 0x89, 0x87, 0x85, 0x83, 0x81,
                0x7F, 0x7D, 0x7B, 0x79, 0x77, 0x75, 0x73, 0x71, 0x6F, 0x6D, 0x6B, 0x69, 0x67, 0x65, 0x63, 0x61,
                0x5F, 0x5D, 0x5B, 0x59, 0x57, 0x55, 0x53, 0x51, 0x4F, 0x4D, 0x4B, 0x49, 0x47, 0x45, 0x43, 0x41,
                0x3F, 0x3D, 0x3B, 0x39, 0x37, 0x35, 0x33, 0x31, 0x2F, 0x2D, 0x2B, 0x29, 0x27, 0x25, 0x23, 0x21,
                0x1F, 0x1D, 0x1B, 0x19, 0x17, 0x15, 0x13, 0x11, 0x0F, 0x0D, 0x0B, 0x09, 0x07, 0x05, 0x03, 0x01,
                0x00, 0x02, 0x04, 0x06, 0x08, 0x0A, 0x0C, 0x0E, 0x10, 0x12, 0x14, 0x16, 0x18, 0x1A, 0x1C, 0x1E,
                0x20, 0x22, 0x24, 0x26, 0x28, 0x2A, 0x2C, 0x2E, 0x30, 0x32, 0x34, 0x36, 0x38, 0x3A, 0x3C, 0x3E,
                0x40, 0x42, 0x44, 0x46, 0x48, 0x4A, 0x4C, 0x4E, 0x50, 0x52, 0x54, 0x56, 0x58, 0x5A, 0x5C, 0x5E,
                0x60, 0x62, 0x64, 0x66, 0x68, 0x6A, 0x6C, 0x6E, 0x70, 0x72, 0x74, 0x76, 0x78, 0x7A, 0x7C, 0x7E,
                0x80, 0x82, 0x84, 0x86, 0x88, 0x8A, 0x8C, 0x8E, 0x90, 0x92, 0x94, 0x96, 0x98, 0x9A, 0x9C, 0x9E,
                0xA0, 0xA2, 0xA4, 0xA6, 0xA8, 0xAA, 0xAC, 0xAE, 0xB0, 0xB2, 0xB4, 0xB6, 0xB8, 0xBA, 0xBC, 0xBE,
                0xC0, 0xC2, 0xC4, 0xC6, 0xC8, 0xCA, 0xCC, 0xCE, 0xD0, 0xD2, 0xD4, 0xD6, 0xD8, 0xDA, 0xDC, 0xDE,
                0xE0, 0xE2, 0xE4, 0xE6, 0xE8, 0xEA, 0xEC, 0xEE, 0xF0, 0xF2, 0xF4, 0xF6, 0xF8, 0xFA, 0xFC, 0xFE
            },
            new byte[]
            {
                0x00, 0x02, 0x04, 0x06, 0x08, 0x0A, 0x0C, 0x0E, 0x10, 0x12, 0x14, 0x16, 0x18, 0x1A, 0x1C, 0x1E,
                0x20, 0x22, 0x24, 0x26, 0x28, 0x2A, 0x2C, 0x2E, 0x30, 0x32, 0x34, 0x36, 0x38, 0x3A, 0x3C, 0x3E,
                0x40, 0x42, 0x44, 0x46, 0x48, 0x4A, 0x4C, 0x4E, 0x50, 0x52, 0x54, 0x56, 0x58, 0x5A, 0x5C, 0x5E,
                0x60, 0x62, 0x64, 0x66, 0x68, 0x6A, 0x6C, 0x6E, 0x70, 0x72, 0x74, 0x76, 0x78, 0x7A, 0x7C, 0x7E,
                0x80, 0x82, 0x84, 0x86, 0x88, 0x8A, 0x8C, 0x8E, 0x90, 0x92, 0x94, 0x96, 0x98, 0x9A, 0x9C, 0x9E,
                0xA0, 0xA2, 0xA4, 0xA6, 0xA8, 0xAA, 0xAC, 0xAE, 0xB0, 0xB2, 0xB4, 0xB6, 0xB8, 0xBA, 0xBC, 0xBE,
                0xC0, 0xC2, 0xC4, 0xC6, 0xC8, 0xCA, 0xCC, 0xCE, 0xD0, 0xD2, 0xD4, 0xD6, 0xD8, 0xDA, 0xDC, 0xDE,
                0xE0, 0xE2, 0xE4, 0xE6, 0xE8, 0xEA, 0xEC, 0xEE, 0xF0, 0xF2, 0xF4, 0xF6, 0xF8, 0xFA, 0xFC, 0xFE,
                0xFF, 0xFD, 0xFB, 0xF9, 0xF7, 0xF5, 0xF3, 0xF1, 0xEF, 0xED, 0xEB, 0xE9, 0xE7, 0xE5, 0xE3, 0xE1,
                0xDF, 0xDD, 0xDB, 0xD9, 0xD7, 0xD5, 0xD3, 0xD1, 0xCF, 0xCD, 0xCB, 0xC9, 0xC7, 0xC5, 0xC3, 0xC1,
                0xBF, 0xBD, 0xBB, 0xB9, 0xB7, 0xB5, 0xB3, 0xB1, 0xAF, 0xAD, 0xAB, 0xA9, 0xA7, 0xA5, 0xA3, 0xA1,
                0x9F, 0x9D, 0x9B, 0x99, 0x97, 0x95, 0x93, 0x91, 0x8F, 0x8D, 0x8B, 0x89, 0x87, 0x85, 0x83, 0x81,
                0x7F, 0x7D, 0x7B, 0x79, 0x77, 0x75, 0x73, 0x71, 0x6F, 0x6D, 0x6B, 0x69, 0x67, 0x65, 0x63, 0x61,
                0x5F, 0x5D, 0x5B, 0x59, 0x57, 0x55, 0x53, 0x51, 0x4F, 0x4D, 0x4B, 0x49, 0x47, 0x45, 0x43, 0x41,
                0x3F, 0x3D, 0x3B, 0x39, 0x37, 0x35, 0x33, 0x31, 0x2F, 0x2D, 0x2B, 0x29, 0x27, 0x25, 0x23, 0x21,
                0x1F, 0x1D, 0x1B, 0x19, 0x17, 0x15, 0x13, 0x11, 0x0F, 0x0D, 0x0B, 0x09, 0x07, 0x05, 0x03, 0x01
            },
            new byte[]
            {
                0xFF, 0x1E, 0x1E, 0x1E, 0x1E, 0x1E, 0x1E, 0x1E, 0x1E, 0x3B, 0x3B, 0x3B, 0x3B, 0x3B, 0x3B, 0x3B,
                0x3B, 0x56, 0x56, 0x56, 0x56, 0x56, 0x56, 0x56, 0x56, 0x6F, 0x6F, 0x6F, 0x6F, 0x6F, 0x6F, 0x6F,
                0x6F, 0x86, 0x86, 0x86, 0x86, 0x86, 0x86, 0x86, 0x86, 0x9B, 0x9B, 0x9B, 0x9B, 0x9B, 0x9B, 0x9B,
                0x9B, 0xAE, 0xAE, 0xAE, 0xAE, 0xAE, 0xAE, 0xAE, 0xAE, 0xBF, 0xBF, 0xBF, 0xBF, 0xBF, 0xBF, 0xBF,
                0xBF, 0xCE, 0xCE, 0xCE, 0xCE, 0xCE, 0xCE, 0xCE, 0xCE, 0xDB, 0xDB, 0xDB, 0xDB, 0xDB, 0xDB, 0xDB,
                0xDB, 0xE6, 0xE6, 0xE6, 0xE6, 0xE6, 0xE6, 0xE6, 0xE6, 0xEF, 0xEF, 0xEF, 0xEF, 0xEF, 0xEF, 0xEF,
                0xEF, 0xF6, 0xF6, 0xF6, 0xF6, 0xF6, 0xF6, 0xF6, 0xF6, 0xFB, 0xFB, 0xFB, 0xFB, 0xFB, 0xFB, 0xFB,
                0xFB, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE,
                0xFB, 0xFB, 0xFB, 0xFB, 0xFB, 0xFB, 0xFB, 0xFB, 0xF6, 0xF6, 0xF6, 0xF6, 0xF6, 0xF6, 0xF6, 0xF6,
                0xEF, 0xEF, 0xEF, 0xEF, 0xEF, 0xEF, 0xEF, 0xEF, 0xE6, 0xE6, 0xE6, 0xE6, 0xE6, 0xE6, 0xE6, 0xE6,
                0xDB, 0xDB, 0xDB, 0xDB, 0xDB, 0xDB, 0xDB, 0xDB, 0xCE, 0xCE, 0xCE, 0xCE, 0xCE, 0xCE, 0xCE, 0xCE,
                0xBF, 0xBF, 0xBF, 0xBF, 0xBF, 0xBF, 0xBF, 0xBF, 0xAE, 0xAE, 0xAE, 0xAE, 0xAE, 0xAE, 0xAE, 0xAE,
                0x9B, 0x9B, 0x9B, 0x9B, 0x9B, 0x9B, 0x9B, 0x9B, 0x86, 0x86, 0x86, 0x86, 0x86, 0x86, 0x86, 0x86,
                0x6F, 0x6F, 0x6F, 0x6F, 0x6F, 0x6F, 0x6F, 0x6F, 0x56, 0x56, 0x56, 0x56, 0x56, 0x56, 0x56, 0x56,
                0x3B, 0x3B, 0x3B, 0x3B, 0x3B, 0x3B, 0x3B, 0x3B, 0x1E, 0x1E, 0x1E, 0x1E, 0x1E, 0x1E, 0x1E, 0x1E
            }
        };

        #endregion

        public SecurityProvider()
            : this(SecurityParameters.Default)
        {
        }

        public SecurityProvider(SecurityParameters parameters)
        {
            Parameters = parameters;
        }

        public SecurityParameters Parameters { get; set; }

        public void Transform(NetworkPacket packet)
        {
            Parallel.For(0, packet.Data.Length, delegate (int i)
            {
                int mod = (i / this.Parameters.Salt.Length) & 0xFF;

                packet.Data[i] ^= (byte)(
                    this.Parameters.Salt[i % this.Parameters.Salt.Length] ^
                    tree[this.Parameters.Seed][packet.Ordinal] ^
                    tree[this.Parameters.Seed][mod]);

                if (packet.Ordinal == mod)
                {
                    packet.Data[i] ^= tree[this.Parameters.Seed][packet.Ordinal];
                }
            });
        }

        private void Xor(NetworkPacket packet, int i)
        {
            var mod = (i / Parameters.Salt.Length) & 0xFF;

            packet.Data[i] ^= (byte) (Parameters.Salt[i % Parameters.Salt.Length]
                                      ^ tree[Parameters.Seed][packet.Ordinal]
                                      ^ tree[Parameters.Seed][mod]);

            if (packet.Ordinal == mod) packet.Data[i] ^= tree[Parameters.Seed][packet.Ordinal];
        }
    }
}