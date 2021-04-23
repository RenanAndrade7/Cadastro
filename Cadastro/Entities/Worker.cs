using System;
using System.Collections.Generic;
using System.Text;
using Cadastro.Entities.Enums;

namespace Cadastro.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public  WorkerLevel Level { get; set; }
        public Double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker()
        {

        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;

          foreach(HourContract contracts in Contracts)
            {
                if(contracts.Date.Year == year && contracts.Date.Month == month)
                {
                    sum += contracts.TotalValue();
                }
            }

            return sum;
        }
    }
}
