using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAlex
{
    public class Coder
    {
        public Coder()
        {

        }

        public string Code(string text)
        {
            byte[] bytes = Encoding.Default.GetBytes(text);

			for (var i = 0; i < bytes.Length; i++)
            {
				if(bytes[i] == 254 || bytes[i] == 255)
				{
					bytes[i] += 35;
				}
				else
				{
					bytes[i] += 2;
				}								
			}

            return Encoding.Default.GetString(bytes);
        }

        public string Encode(string text)
        {
            byte[] bytes = Encoding.Default.GetBytes(text);

            for (var i = 0; i < bytes.Length; i++)
            {

				if (bytes[i] == 254 || bytes[i] == 255)
				{
					bytes[i] -= 35;
				}
				else
				{
					bytes[i] -= 2;
				}
			}

            return Encoding.Default.GetString(bytes);
        }

    }
}
