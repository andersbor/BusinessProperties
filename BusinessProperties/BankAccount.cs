using System.Collections.Generic;

namespace BusinessProperties
{
    public class BankAccount : BusinessClass<BankAccount>
    {
        public Property<int> Balance { get; set; }
        public Property<string> Owner { get; set; }

        public BankAccount()
        {
            Balance = new Property<int>(this);
            Owner = new Property<string>(this);
        }
    }

    public class BusinessClass<T>
    {
        public IList<BusinessRule<T>> BusinessRules { get; set; }
    }
}