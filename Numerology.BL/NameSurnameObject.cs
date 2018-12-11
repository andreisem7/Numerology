using System.Collections.Generic;

namespace Numerology.BL
{
    public class NameSurnameObject
    {
        public List<NumerogicalLetter> NameLetters { get; set; }
        public List<NumerogicalLetter> SurnameLetters { get; set; }
        public List<NumerogicalLetter> FathersnameLetters { get; set; }
        public NameSurnameObject()
        {
            NameLetters = new List<NumerogicalLetter>();
            SurnameLetters = new List<NumerogicalLetter>();
            FathersnameLetters = new List<NumerogicalLetter>();
        }
    }
}
