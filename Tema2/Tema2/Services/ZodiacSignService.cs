using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacSign;

namespace Server.Services
{
    public class ZodiacSignService : Zodiac.ZodiacBase
    {
       public string GetSign(string date)
        {
            foreach (string line in Server.ZodiacIntervals.lines)
            {
                string[] split1 = line.Split(new Char[] {' '});
                string[] split2 = date.Split(new Char[] { '/' });
                if (int.Parse(split1[1])==int.Parse(split2[0]) && int.Parse(split1[2]) <= int.Parse(split2[1]))
                {
                        return split1[0];
                }
                else if(int.Parse(split1[3]) == int.Parse(split2[0]) && int.Parse(split1[4]) >= int.Parse(split2[1]))
                {
                    return split1[0];
                }
            }
            
            return "Nu s-a putut recunoaste zodia";
        }
        public override Task<DateResponse> GetZodiacSign(DateRequest request, ServerCallContext context)
        {
            string reply = GetSign(request.Date);
            return Task.FromResult(new DateResponse
            {
                Sign = reply
            });
        }
    }
}
