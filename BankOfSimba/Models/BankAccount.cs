using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfSimba.Models
{
    public class BankAccount
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string AnimalType { get; set; }
        public bool IsKing { get; set; }
        public bool IsGood { get; set; }
        public string Color
        {
            get
            {
                if (IsKing)
                {
                    return "font-weight:600;color:orange;";
                }
                else
                {
                    return "";
                }
            }
        }
        public BankAccount()
        {

        }
        public BankAccount(string name, decimal balance, string animalType, bool isKing, bool isGood)
        {
            Name = name;
            Balance = balance;
            AnimalType = animalType;
            IsKing = isKing;
            IsGood = isGood;
        }
    }
}
