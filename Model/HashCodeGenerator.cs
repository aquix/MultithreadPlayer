using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Model
{
    public static class HashCodeGenerator
    {
        public static uint GetHash(String s)
        {
            uint h = 0;
            for (int i = 0; i < s.Length; i++) {
                h = 31 * h + s[i];
            }
            return h;
        }
    }
}
