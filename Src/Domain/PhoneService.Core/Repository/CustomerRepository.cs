﻿using Microsoft.EntityFrameworkCore;
using PhoneService.Domain;
using PhoneService.Domain.Repository;
using PhoneService.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly PhoneServiceDbContext _context;

        public CustomerRepository(PhoneServiceDbContext context) => _context = context;


        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var customers = await _context.Set<Customer>().ToListAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _context.Set<Customer>()
                            .Include(c => c.Addres)
                            .Where(c => c.CustomerId == customerId)
                            .FirstOrDefaultAsync();
            return customer;
        }

        public void AddCustomer(Customer customer) => _context.Add(customer);

        public void RemoveCustomer(Customer customer) => _context.Remove(customer);
    }
}
