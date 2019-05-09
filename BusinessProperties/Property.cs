using System.Collections.Generic;

namespace BusinessProperties
{
    public delegate bool BusinessRule<T>(T oldValue, T newValue);

    public class Property<T>
    {
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                // if (_value.Equals(value)) return; // TODO null check
                foreach (BusinessRule<T> rule in BusinessRules)
                {
                    if (!rule.Invoke(_value, value))
                    {
                        throw new BusinessException();
                    }
                }
                foreach (BusinessRule<T> compoundRule in _businessObject.BusinessRules)
                {
                    if (!compoundRule.Invoke(_value, value))
                    {
                        throw new BusinessException();
                    }
                }
                _value = value;
            }
        }

        public IList<BusinessRule<T>> BusinessRules { get; }

        private readonly BusinessClass<T> _businessObject;

        public Property(BusinessClass<T> businessObject)
        {
            BusinessRules = new List<BusinessRule<T>>();
            _businessObject = businessObject;
        }
    }
}
