﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }

        //Avisando para o framework a FK DepartmentId terá que existir
        public int DepartmentId { get; set; }

        //Colection Generic
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        //Total de vendas do vendedor em um dado periodo
        public double TotalSales(DateTime initial, DateTime final)
        {
            //Filtrando usando o LINQ de acordo com a data final e inicial e somando apenas o que foi vendido
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }

       
    }
}
