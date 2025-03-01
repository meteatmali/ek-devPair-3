using System;
using System.Collections.Generic;
using System.Linq;

namespace Odev
{
    public class CorporateCustomer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string Age { get; set; }
    }

    public class IndividualCustomer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public int Age { get; set; }
    }

    public class IndividualCustomerManager
    {
        private List<IndividualCustomer> _customers = new List<IndividualCustomer>();

        public void Add(int id, string name, string surname, int age)
        {
            _customers.Add(new IndividualCustomer { Id = id, CustomerName = name, CustomerSurname = surname, Age = age });
        }

        public List<IndividualCustomer> GetList()
        {
            return _customers;
        }

        public IndividualCustomer GetById(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id);
        }

        public void Delete(int id)
        {
            var customer = GetById(id);
            if (customer != null)
            {
                _customers.Remove(customer);
            }
        }
    }

    public class CorporateCustomerManager
    {
        private List<CorporateCustomer> _customers = new List<CorporateCustomer>();

        public void Add(int id, string name, string surname, string age)
        {
            _customers.Add(new CorporateCustomer { Id = id, CustomerName = name, CustomerSurname = surname, Age = age });
        }

        public List<CorporateCustomer> GetList()
        {
            return _customers;
        }

        public CorporateCustomer GetById(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id);
        }

        public void Delete(int id)
        {
            var customer = GetById(id);
            if (customer != null)
            {
                _customers.Remove(customer);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IndividualCustomerManager individualManager = new IndividualCustomerManager();
            individualManager.Add(1, "Ali", "Yılmaz", 25);
            Console.WriteLine("Added Individual: " + individualManager.GetById(1)?.CustomerName);

            individualManager.Delete(1);
            Console.WriteLine("Deleted Individual: " + (individualManager.GetById(1) == null ? "Not found" : "Exists"));

            CorporateCustomerManager corporateManager = new CorporateCustomerManager();
            corporateManager.Add(2, "Veli", "Demir", "30");
            Console.WriteLine("Added Corporate: " + corporateManager.GetById(2)?.CustomerName);

            corporateManager.Delete(2);
            Console.WriteLine("Deleted Corporate: " + (corporateManager.GetById(2) == null ? "Not found" : "Exists"));
        }
    }
}