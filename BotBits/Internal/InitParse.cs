using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using BotBits;
using PlayerIOClient;

// ReSharper disable once CheckNamespace
namespace Yonom.EE
{
    public class InitParse
    {
        public static DataChunk[] Parse(byte[] bytes)
        {
            var chunks = new List<DataChunk>();
            bytes = Decompression(bytes);
            for (var i = 0; i < bytes.Length;)
            {
                var type = BitConverter.ToUInt32(bytes, i, true); i += 4;
                var layerNum = BitConverter.ToInt32(bytes, i, true); i += 4;
                var args = new List<object>();

                var xsLength = BitConverter.ToUInt32(bytes, i, true); i += 4;
                var xs = new byte[xsLength];

                for (int x = 0; x < xsLength; x++)
                {
                    xs[x] = bytes[i++];
                }

                var ysLength = BitConverter.ToUInt32(bytes, i, true); i += 4;
                var ys = new byte[ysLength];
                for (int y = 0; y < ysLength; y++)
                {
                    ys[y] = bytes[i++];
                }

                if (goalNew.Contains((int)type))
                {
                    args.Add(BitConverter.ToUInt32(bytes, i, true)); //goal
                    i += 4;
                }
                if (rotationNew.Contains((int)type))
                {
                    args.Add(BitConverter.ToUInt32(bytes, i, true)); //rotation
                    i += 4;
                }
                if (type == 381 || type == 242) //Portals
                {
                    args.Add(BitConverter.ToUInt32(bytes, i, true)); //rotation
                    args.Add(BitConverter.ToUInt32(bytes, i + 4, true)); //id
                    args.Add(BitConverter.ToUInt32(bytes, i + 8, true)); //target
                    i += 12;
                }
                if (type == 374) //World Portal
                {
                    var targetLength = BitConverter.ToInt32(bytes, i, true);
                    args.Add(Encoding.UTF8.GetString(bytes, i + 4, targetLength)); //worldID
                    args.Add(BitConverter.ToUInt32(bytes, i + 4 + targetLength, true)); //spawnpoint ID
                    i += (8 + targetLength);
                }
                if (type == 1582) //World portal spawn point
                {
                    args.Add(BitConverter.ToUInt32(bytes, i, true)); //spawnpoint id
                    i += 4;
                }
                if (coloredBlocks.Contains((int)type) || type == 1200) //Coloured blocks
                {
                    args.Add(BitConverter.ToUInt32(bytes, i, true)); //colour
                    i += 4;
                }
                if (type == 1000) //Label
                {
                    var textLength = BitConverter.ToInt32(bytes, i, true);
                    args.Add(Encoding.UTF8.GetString(bytes, i + 4, textLength)); //text

                    var textColourLength = BitConverter.ToInt32(bytes, i + 4 + textLength, true);
                    args.Add(Encoding.UTF8.GetString(bytes, i + 8 + textLength, textColourLength)); //colour

                    args.Add(BitConverter.ToUInt32(bytes, i + 8 + textLength + textColourLength, true)); //wrap

                    i += (12 + textLength + textColourLength);
                }
                if (type == 77 || type == 83 || type == 1520) //Music blocks
                {
                    args.Add(BitConverter.ToUInt32(bytes, i, true)); //note id
                    i += 4;
                }
                if (type == 385) //Sign blocks
                {
                    var textLength = BitConverter.ToInt32(bytes, i, true);
                    args.Add(Encoding.UTF8.GetString(bytes, i + 4, textLength)); //text
                    args.Add(BitConverter.ToUInt32(bytes, i + 4 + textLength, true)); //sign type
                    i += (8 + textLength);
                }
                if (isNPC((int)type)) //Npc blocks
                {
                    var nameLength = BitConverter.ToInt32(bytes, i, true);
                    args.Add(Encoding.UTF8.GetString(bytes, i + 4, nameLength)); //npc name

                    var msg1Length = BitConverter.ToInt32(bytes, i + 4 + nameLength, true);
                    args.Add(Encoding.UTF8.GetString(bytes, i + 8 + nameLength, msg1Length)); //message 1

                    var msg2Length = BitConverter.ToInt32(bytes, i + 8 + nameLength + msg1Length, true);
                    args.Add(Encoding.UTF8.GetString(bytes, i + 12 + nameLength + msg1Length, msg2Length)); //message 2

                    var msg3Length = BitConverter.ToInt32(bytes, i + 12 + nameLength + msg1Length + msg2Length, true);
                    args.Add(Encoding.UTF8.GetString(bytes, i + 16 + nameLength + msg1Length + msg2Length, msg3Length)); //message 3

                    i += (16 + nameLength + msg1Length + msg2Length + msg3Length);

                }
                chunks.Add(new DataChunk(layerNum, type, xs, ys, args.ToArray()));
            }
            return chunks.ToArray();
        }
        public static byte[] Decompression(byte[] data)
        {
            MemoryStream input = new MemoryStream(data);
            MemoryStream output = new MemoryStream();
            using (DeflateStream dstream = new DeflateStream(input, CompressionMode.Decompress))
            {
                dstream.CopyTo(output);
            }
            return output.ToArray();
        }

        //Detect and read rotations or morphs
        public static int[] rotationNew =
        {
        //One ways
        1001, 1002, 1003, 1004, 1052,
        1053, 1054, 1055, 1056, 1092,
        //Spikes
        361, 1625, 1627, 1629, 1631, 1633, 1635,
        //Half blocks
        1075, 1076, 1077, 1078, 1116, 1117, 1118,
        1119, 1120, 1121,1122, 1123, 1124, 1125,
        1041, 1042, 1043, 
        //Morph
        375, 376, 377, 379, 380, 438, 439, 378,
        338,339, 340,447,448,1536,1537,
        449,450,451,452,1538,456,457,458,
        475, 476, 477,1502,1500,499,464,465,
        471,481,482,483,497,492,493,494,
        1507,1506,1581,1587,1588,1592,1593,
        1594,1595,1597,1596,1605,1606,
        1607,1608,1609,1610,1611,1612,
        1614,1615,1616,1617,276,277,279,
        280,440,275,329,273,328,327,1535,
        1140,1141,1134,1135,1155,1160,
        //Misc
        1517
    };

        //Detect and read blocks with values
        public static int[] goalNew =
        {
        165, 214, //coin gates
        43, 213, //coin doors
        1011, 1012, //death doors and gates
        185, 184, 1619, 113, //purple switches
        1080, 1079, 1620, 467, //orange switches
        423, 1028, 1027, //team
        1584, 422, 418, 420, 453, 461, 419, 417 //effects
    };

        public static int[] coloredBlocks =
        {
        631, 632, 633, //basic, canvas, checkered bgs
        1200 //basic block
    };

        public static bool isNPC(int id)
        {
            if (id >= 1550 && id <= 1559 || id >= 1569 && id <= 1579) return true;
            else return false;
        }
    }
}