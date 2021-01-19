using System;
using System.Collections.Generic;
using System.Linq;

namespace Numerology.BL
{
    public class NameSurnameManager
    {
        private Language language = Language.ENG;
        private string nameRaw = String.Empty;
        private string surnameRaw = String.Empty;
        private string fathersnameRaw = String.Empty;

        private int vowelsOfName = 0;// гласные имени p.1
        private int consonantsOfName = 0;// согласные имени p.2
        private int vowelsAndConsonantsOfName = 0;// гласные и согласные имени p.3

        private int vowelsOfSurname = 0;// гласные фамилии p.4
        private int consonantsOfSurname = 0;//  согласные фамилии p.5
        private int vowelsAndConsonantsOfSurname = 0;// гласные и согласные фамилии p.6

        private int vowelsOfFathername = 0;// гласные отчества
        private int consonantsOfFathername = 0;//  согласные отчества
        private int vowelsAndConsonantsOfFathername = 0;// гласные и согласные отчества

        private int vowelsOfNameAndSurname = 0;// гласные имени и фамилии p.7
        private bool isVowelsOfNameAndSurnameMaster = false;
        private int vowelsOfNameAndSurnameMaster = 0;

        private int consonantsOfNameAndSurname = 0;// согласные имени и фамилии p.8        
        private bool isConsonantsOfNameAndSurnameMaster = false;
        private int consonantsOfNameAndSurnameMaster = 0;

        private int vowelsAndConsonantsOfNameAndSurname = 0;// гласные и согласные имени и фамилии p.9
        private bool isVowelsAndConsonantsOfNameAndSurnameMaster = false;
        private int vowelsAndConsonantsOfNameAndSurnameMaster = 0;

        private int _lifeWayNumber = 0;// p.10

        private int vowelsAndConsonantsOfNameAndSurnameAndlifeWayNumber = 0;// p.11
        private bool isVowelsAndConsonantsOfNameAndSurnameAndlifeWayNumberMaster = false;
        private int vowelsAndConsonantsOfNameAndSurnameAndlifeWayNumberMaster = 0;

        private NameSurnameObject nameSurname = null;
        /// <summary>
        /// Readonly object containing name and surname
        /// </summary>
        public NameSurnameObject NameSurname { get { return nameSurname; } }
        public string GetLanguageString
        {
            get { return language.ToString(); }
        }
        public string GetNameRaw
        {
            get { return nameRaw; }
        }
        public string GetSurnameRaw
        {
            get { return surnameRaw; }
        }
        public string GetfathersnameRaw
        {
            get { return fathersnameRaw; }
        }
        public string GetVowelsOfNameString //p.1
        {
            get { return vowelsOfName.ToString(); }
        }
        public string GetConsonantsOfNameString //p.2
        {
            get { return consonantsOfName.ToString(); }
        }
        public string GetVowelsAndConsonantsOfNameString //p.3
        {
            get { return vowelsAndConsonantsOfName.ToString(); }
        }
        public string GetVowelsOfSurnameString //p.4
        {
            get { return vowelsOfSurname.ToString(); }
        }
        public string GetConsonantsOfSurnameString //p.5
        {
            get { return consonantsOfSurname.ToString(); }
        }
        public string GetVowelsAndConsonantsOfSurnameString //p.6
        {
            get { return vowelsAndConsonantsOfSurname.ToString(); }
        }
        public string GetVowelsOfFathernameString
        {
            get { return vowelsOfFathername.ToString(); }
        }
        public string GetConsonantsOfFathernameString
        {
            get { return consonantsOfFathername.ToString(); }
        }
        public string GetVowelsAndConsonantsOfFathernameString
        {
            get { return vowelsAndConsonantsOfFathername.ToString(); }
        }

        public string GetVowelsOfNameAndSurnameString //p.7
        {
            get { return vowelsOfNameAndSurname.ToString(); }
        }
        public bool IsVowelsOfNameAndSurnameMaster //p.7
        {
            get { return isVowelsOfNameAndSurnameMaster; }
        }
        public string GetVowelsOfNameAndSurnameMasterString //p.7
        {
            get { return vowelsOfNameAndSurnameMaster.ToString(); }
        }

        public string GetConsonantsOfNameAndSurnameString //p.8
        {
            get { return consonantsOfNameAndSurname.ToString(); }
        }
        public bool IsConsonantsOfNameAndSurnameMaster //p.8
        {
            get { return isConsonantsOfNameAndSurnameMaster; }
        }
        public string GetConsonantsOfNameAndSurnameMasterString //p.8
        {
            get { return consonantsOfNameAndSurnameMaster.ToString(); }
        }

        public string GetVowelsAndConsonantsOfNameAndSurnameString //p.9
        {
            get { return vowelsAndConsonantsOfNameAndSurname.ToString(); }
        }
        public bool IsVowelsAndConsonantsOfNameAndSurnameMaster //p.9
        {
            get { return isVowelsAndConsonantsOfNameAndSurnameMaster; }
        }
        public string GetVowelsAndConsonantsOfNameAndSurnameMaster //p.9
        {
            get { return vowelsAndConsonantsOfNameAndSurnameMaster.ToString(); }
        }

        public string GetLifeWayNumberString //p.10
        {
            get { return _lifeWayNumber.ToString(); }
        }

        public string GetVowelsAndConsonantsOfNameAndSurnameAndlifeWayNumberString //p.11
        {
            get { return vowelsAndConsonantsOfNameAndSurnameAndlifeWayNumber.ToString(); }
        }
        public bool IsVowelsAndConsonantsOfNameAndSurnameAndlifeWayNumberMaster //p.11
        {
            get { return isVowelsAndConsonantsOfNameAndSurnameAndlifeWayNumberMaster; }
        }
        public string GetVowelsAndConsonantsOfNameAndSurnameAndlifeWayNumberMasterString //p.11
        {
            get { return vowelsAndConsonantsOfNameAndSurnameAndlifeWayNumberMaster.ToString(); }
        }

        public Matrix NameMatrix { get; set; }

        public void SetName(Language lang, string name, string surname, string fathersname, int lifeWayNumber)
        {
            language = lang;
            nameRaw = name;
            surnameRaw = surname;
            fathersnameRaw = fathersname;
            _lifeWayNumber = lifeWayNumber;

            NameMatrix = new Matrix();

            nameSurname = InitNumerogicalLetterAlphabet(lang, name, surname, fathersname);

            vowelsOfName = int.Parse(NarrowToOneNumber(GetLettersIndexiesString(nameSurname.NameLetters.Where(v => !v.IsConsonant).ToList()), out _, out _));
            consonantsOfName = int.Parse(NarrowToOneNumber(GetLettersIndexiesString(nameSurname.NameLetters.Where(v => v.IsConsonant).ToList()), out _, out _));
            vowelsAndConsonantsOfName = int.Parse(NarrowToOneNumber(GetLettersIndexiesString(nameSurname.NameLetters), out _, out _));

            vowelsOfSurname = int.Parse(NarrowToOneNumber(GetLettersIndexiesString(nameSurname.SurnameLetters.Where(v => !v.IsConsonant).ToList()), out _, out _));
            consonantsOfSurname = int.Parse(NarrowToOneNumber(GetLettersIndexiesString(nameSurname.SurnameLetters.Where(v => v.IsConsonant).ToList()), out _, out _));
            vowelsAndConsonantsOfSurname = int.Parse(NarrowToOneNumber(GetLettersIndexiesString(nameSurname.SurnameLetters), out _, out _));

            if (!string.IsNullOrEmpty(fathersname))
            {
                vowelsOfFathername = int.Parse(NarrowToOneNumber(GetLettersIndexiesString(nameSurname.FathersnameLetters.Where(v => !v.IsConsonant).ToList()), out _, out _));
                consonantsOfFathername = int.Parse(NarrowToOneNumber(GetLettersIndexiesString(nameSurname.FathersnameLetters.Where(v => v.IsConsonant).ToList()), out _, out _));
                vowelsAndConsonantsOfFathername = int.Parse(NarrowToOneNumber(GetLettersIndexiesString(nameSurname.FathersnameLetters), out _, out _));

                vowelsOfNameAndSurname = int.Parse(NarrowToOneNumber(GetLettersIndexiesString(Combine2Ranges(Combine2Ranges(nameSurname.NameLetters.Where(v => !v.IsConsonant).ToList(), nameSurname.SurnameLetters.Where(v => !v.IsConsonant).ToList()), nameSurname.FathersnameLetters.Where(v => !v.IsConsonant).ToList())), out isVowelsOfNameAndSurnameMaster, out vowelsOfNameAndSurnameMaster));
                consonantsOfNameAndSurname = int.Parse(NarrowToOneNumber(GetLettersIndexiesString(Combine2Ranges(Combine2Ranges(nameSurname.NameLetters.Where(v => v.IsConsonant).ToList(), nameSurname.SurnameLetters.Where(v => v.IsConsonant).ToList()), nameSurname.FathersnameLetters.Where(v => v.IsConsonant).ToList())), out isConsonantsOfNameAndSurnameMaster, out consonantsOfNameAndSurnameMaster));
                vowelsAndConsonantsOfNameAndSurname = int.Parse(NarrowToOneNumber(GetLettersIndexiesString(Combine2Ranges(Combine2Ranges(nameSurname.NameLetters, nameSurname.SurnameLetters), nameSurname.FathersnameLetters)), out isVowelsAndConsonantsOfNameAndSurnameMaster, out vowelsAndConsonantsOfNameAndSurnameMaster));

                vowelsAndConsonantsOfNameAndSurnameAndlifeWayNumber = int.Parse(NarrowToOneNumber(vowelsAndConsonantsOfNameAndSurname.ToString() + _lifeWayNumber.ToString(), out isVowelsAndConsonantsOfNameAndSurnameAndlifeWayNumberMaster, out vowelsAndConsonantsOfNameAndSurnameAndlifeWayNumberMaster));
                InitMatrix(true);
            }
            else
            {
                vowelsOfNameAndSurname = int.Parse(NarrowToOneNumber(GetLettersIndexiesString(Combine2Ranges(nameSurname.NameLetters.Where(v => !v.IsConsonant).ToList(), nameSurname.SurnameLetters.Where(v => !v.IsConsonant).ToList())), out isVowelsOfNameAndSurnameMaster, out vowelsOfNameAndSurnameMaster));
                consonantsOfNameAndSurname = int.Parse(NarrowToOneNumber(GetLettersIndexiesString(Combine2Ranges(nameSurname.NameLetters.Where(v => v.IsConsonant).ToList(), nameSurname.SurnameLetters.Where(v => v.IsConsonant).ToList())), out isConsonantsOfNameAndSurnameMaster, out consonantsOfNameAndSurnameMaster));
                vowelsAndConsonantsOfNameAndSurname = int.Parse(NarrowToOneNumber(GetLettersIndexiesString(Combine2Ranges(nameSurname.NameLetters, nameSurname.SurnameLetters)), out isVowelsAndConsonantsOfNameAndSurnameMaster, out vowelsAndConsonantsOfNameAndSurnameMaster));

                vowelsAndConsonantsOfNameAndSurnameAndlifeWayNumber = int.Parse(NarrowToOneNumber(vowelsAndConsonantsOfNameAndSurname.ToString() + _lifeWayNumber.ToString(), out isVowelsAndConsonantsOfNameAndSurnameAndlifeWayNumberMaster, out vowelsAndConsonantsOfNameAndSurnameAndlifeWayNumberMaster));
                InitMatrix(false);
            }
        }
        private void InitMatrix(bool isFather)
        {
            var input = GetVowelsOfNameString + //p.1
                GetConsonantsOfNameString + //p.2
                GetVowelsAndConsonantsOfNameString + //p.3
                GetVowelsOfSurnameString + //p.4
                GetConsonantsOfSurnameString + //p.5
                GetVowelsAndConsonantsOfSurnameString + //p.6
                GetVowelsOfNameAndSurnameString + //p.7
                GetConsonantsOfNameAndSurnameString + //p.8
                GetVowelsAndConsonantsOfNameAndSurnameString + //p.9
                GetLifeWayNumberString + //p.10
                GetVowelsAndConsonantsOfNameAndSurnameAndlifeWayNumberString + //p.11
                (isFather ? GetVowelsOfFathernameString + GetConsonantsOfFathernameString + GetVowelsAndConsonantsOfFathernameString : "");

            for (int i = 0; i < Matrix.Capacity; i++)
            {
                var count = CountNumber(input, (i + 1).ToString());
                NameMatrix.AddCell(i + 1, i + 1, count);
            }
        }
        private int CountNumber(string input, string sample)
        {
            return input.Count(x => x.ToString() == sample);
        }

        private List<NumerogicalLetter> Combine2Ranges(List<NumerogicalLetter> inputFirst, List<NumerogicalLetter> inputSecond)
        {
            if (inputFirst == null && inputSecond == null) return null;
            if (inputSecond == null) return inputFirst;
            if (inputFirst == null) return inputSecond;

            inputFirst.AddRange(inputSecond);
            return inputFirst;
        }

        private string GetLettersIndexiesString(List<NumerogicalLetter> input)
        {
            string output = String.Empty;
            if (input == null || input.Count == 0) return String.Empty;
            for (int i = 0; i < input.Count; i++)
            {
                output += input[i].Index.ToString();
            }
            return output;
        }

        private string NarrowToOneNumber(string input, out bool isMaster, out int masterNumber)
        {
            string result = string.IsNullOrEmpty(input) ? "0" : input;
            isMaster = false;
            masterNumber = 0;

            var isMasterLocal = false;
            var masterNumberLocal = 0;
            while (result.Length > 1)
            {
                result = SimplifyString(result, out isMasterLocal, out masterNumberLocal);

                if (!isMaster)
                {
                    isMaster = isMasterLocal;
                    masterNumber = masterNumberLocal;
                }
            }
            return result;
        }

        private string SimplifyString(string input, out bool isMaster, out int masterNumber)
        {
            isMaster = false;
            masterNumber = 0;
            if (input.Length == 1) return input;

            int result = 0;
            char[] splitted = input.ToCharArray();
            for (int i = 0; i < splitted.Length; i++)
            {
                result += int.Parse(splitted[i].ToString());
            }
            if (result == 11 || result == 22 || result == 33)
            {
                isMaster = true;
                masterNumber = result;
            }
            return result.ToString();
        }

        private NameSurnameObject InitNumerogicalLetterAlphabet(Language lang, string name, string surname, string fathername)
        {
            var alphabet = GetAlphabet(lang);

            NameSurnameObject result = new NameSurnameObject();

            // Name
            char[] splittedName = name.Where(c => Char.IsLetter(c)).ToArray();
            for (int i = 0; i < splittedName.Length; i++)
            {
                var letterOfName = splittedName[i].ToString().ToUpperInvariant();
                var numerogicalLetter = alphabet.FirstOrDefault(let => let.Letter.Equals(letterOfName));

                if (numerogicalLetter == null) continue;
                if (i == 0 && lang == Language.ENG && numerogicalLetter.Letter == "Y")
                {
                    if (splittedName.Length > 1)
                    {
                        var letter = splittedName[1].ToString().ToUpperInvariant();
                        var numLetter = alphabet.First(let => let.Letter.Equals(letter));
                        if (!numLetter.IsConsonant) numerogicalLetter.IsConsonant = true;
                    }
                }
                if (lang == Language.UKR && numerogicalLetter.Letter == "Й")
                {
                    if (splittedName.Length > i + 1)
                    {
                        var letter = splittedName[i + 1].ToString().ToUpperInvariant();
                        if (letter.Equals("O")) numerogicalLetter.IsConsonant = true;
                    }
                }
                result.NameLetters.Add(numerogicalLetter);
            }
            // Surname
            char[] splittedSurname = surname.Where(c => Char.IsLetter(c)).ToArray();
            for (int i = 0; i < splittedSurname.Length; i++)
            {
                var letterOfSurame = splittedSurname[i].ToString().ToUpperInvariant();
                var numerogicalLetter = alphabet.FirstOrDefault(let => let.Letter.Equals(letterOfSurame));

                if (numerogicalLetter == null) continue;
                if (i == 0 && lang == Language.ENG && numerogicalLetter.Letter == "Y")
                {
                    if (splittedSurname.Length > 1)
                    {
                        var letter = splittedSurname[1].ToString().ToUpperInvariant();
                        var numLetter = alphabet.First(let => let.Letter.Equals(letter));
                        if (!numLetter.IsConsonant) numerogicalLetter.IsConsonant = true;
                    }
                }
                if (lang == Language.UKR && numerogicalLetter.Letter == "Й")
                {
                    if (splittedName.Length > i + 1)
                    {
                        var letter = splittedName[i + 1].ToString().ToUpperInvariant();
                        if (letter.Equals("O")) numerogicalLetter.IsConsonant = true;
                    }
                }
                result.SurnameLetters.Add(numerogicalLetter);
            }
            // Fathername
            if (!string.IsNullOrEmpty(fathername))
            {
                char[] splittedFathersname = fathername.Where(c => Char.IsLetter(c)).ToArray();
                for (int i = 0; i < splittedFathersname.Length; i++)
                {
                    var letterOfFathername = splittedFathersname[i].ToString().ToUpperInvariant();
                    var numerogicalLetter = alphabet.FirstOrDefault(let => let.Letter.Equals(letterOfFathername));

                    if (numerogicalLetter == null) continue;
                    result.FathersnameLetters.Add(numerogicalLetter);
                }
            }
            return result;
        }

        private List<NumerogicalLetter> GetAlphabet(Language lang)
        {
            switch (lang)
            {
                case Language.ENG: { return AlphabetCrapHelper.GetEnglishAlphabet(); }
                case Language.EST: { return AlphabetCrapHelper.GetEstonianAlphabet(); }
                case Language.RUS: { return AlphabetCrapHelper.GetRussianAlphabet(); }
                case Language.LAT: { return AlphabetCrapHelper.GetLatvianAlphabet(); }
                case Language.UKR: { return AlphabetCrapHelper.GetUkranianAlphabet(); }
                default: { return AlphabetCrapHelper.GetEnglishAlphabet(); }
            }
        }
    }
    public enum Language
    {
        ENG = 1,
        RUS = 2,
        EST = 3,
        LAT = 4,
        UKR = 5
    }
}
