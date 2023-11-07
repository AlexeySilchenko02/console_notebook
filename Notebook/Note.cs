using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    public class Note
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string DateOfBirth { get; set; }
        public string Organization { get; set; }
        public string Position { get; set; }
        public string Remark { get; set; }

        public static Dictionary<string, Validation> fieldsValidation = new Dictionary<string, Validation>();
        static Note()
        {
            string russinSymbols = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя - ";
            string numbers = "1234567890";
            string specialSymbols = ",.?!()+=№@'\"&$;:^\\";
            fieldsValidation.Add("Id", new Validation(true, 1, 10, numbers.ToCharArray()));
            fieldsValidation.Add("Surname", new Validation(true, 1, 20, russinSymbols.ToCharArray()));
            fieldsValidation.Add("Name", new Validation(true, 1, 20, russinSymbols.ToCharArray()));
            fieldsValidation.Add("SecondName", new Validation(false, 0, 20, russinSymbols.ToCharArray()));
            fieldsValidation.Add("Phone", new Validation(true, 5, 11, numbers.ToCharArray()));
            fieldsValidation.Add("Country", new Validation(false, 0, 20, russinSymbols.ToCharArray()));
            fieldsValidation.Add("DateOfBirth", new Validation(false, 10, 10, (numbers + ".").ToCharArray()));
            fieldsValidation.Add("Organization", new Validation(false, 0, 20, russinSymbols.ToCharArray()));
            fieldsValidation.Add("Position", new Validation(false, 0, 20, russinSymbols.ToCharArray()));
            fieldsValidation.Add("Remark", new Validation(false, 0, 200, (russinSymbols + numbers + specialSymbols).ToCharArray()));
        }
        public override string ToString()
        {
            return $"\n\tID: {Id}\n\tФамилия: {Surname}\n\tИмя: {Name}\n\tОтчество: {SecondName}\n\tНомер телефона: {Phone}\n\tСтрана: {Country}\n\tДата рождения: {DateOfBirth}\n\tОрганизация: {Organization}\n\tДолжность: {Position}\n\tПримечание: {Remark}";
        }
        public string ToShortString()
        {
            return $"{Id} {Surname} {Name} {Phone}";
        }
    }
}
