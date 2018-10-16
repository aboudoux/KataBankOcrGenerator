using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataBankOcrGenerator.Exceptions
{
    public class IncorrectAccountNumberException : AccountNumberException
    {
        public IncorrectAccountNumberException() : base("Le format du compte banquaire est incorrect (9 chiffres attendu)")
        {            
        }
    }
}
