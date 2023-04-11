using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space_helper_bot
{
    public class AccesToken
    {
        public static readonly string Value = File.ReadAllText("token.txt").ToString();
    }
}
