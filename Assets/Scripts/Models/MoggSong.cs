﻿using System;
using System.IO;

namespace NotReaper.Models
{
    public class MoggSong
    {
        public MoggVol volume;
        public string moggPath;
        public MoggVol pan;

        public MoggSong(MemoryStream ms)
        {
            StreamReader reader = new StreamReader(ms);
            string moggString = reader.ReadToEnd();
            string[] lines = moggString.Split(new string[] { "\\n" }, StringSplitOptions.None);
            foreach (var line in lines)
            {
                if (line.Contains("vol")) this.volume = GetMoggVolFromLine(line);
                if (line.Contains("pans")) this.volume = GetMoggVolFromLine(line);
            }
        }

        public MoggVol GetMoggVolFromLine(string line)
        {
            var split = line.Split(new char[] { '(', ')' });
            var values = split[2].Split(' ');
            return new MoggVol(float.Parse(values[0]), float.Parse(values[1]));
        }
    }

    public struct MoggVol
    {
        public float l;
        public float r;

        public MoggVol(float l, float r)
        {
            this.l = l;
            this.r = r;
        }
    }
}
