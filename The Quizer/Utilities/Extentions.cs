﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Utilities
{
    static class Extentions
    {
        private static readonly Random seed = new ();
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new (seed.Next(1000,int.MaxValue));
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
