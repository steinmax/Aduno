using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReSign.Database.Logic.Helpers
{
    public static class UUIDGenerator
    {
        public static string QrTokenGenerator()
        {
            Guid g = Guid.NewGuid();
            string str = g.ToString();
            string[] result = str.Split("-");
            if (result != null)
            {
                return result.FirstOrDefault();
            }
            else
            {
                throw new ArgumentNullException("Es enstand ein Fehler bei der Tokengenerierung bitte versuchen Sie es nocht ein Mal");
            }
        }

        public static string UserTokenGenerator()
        {
            Guid g = Guid.NewGuid();
            string str = g.ToString();
            return str;
        }
    }
}
