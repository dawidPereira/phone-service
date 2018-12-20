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
                            .FirstOrDefaultAsync(c => c.CustomerId == customerId);

            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomerWithAdressAsync(Customer customer)
        {
            IEnumerable<Customer> customers = _context.Set<Customer>()
                                .Include(c => c.Addres)
                                .AsQueryable();

            foreach (var filter in customer.GetType().GetProperties())
            {
                var filterValue = filter.GetValue(customer);

                if (filterValue != null)
                    if (filterValue.ToString() != 0.ToString())
                {
                    customers = customers.Where
                                (p => p.GetType()
                                .GetProperty(filter.Name)
                                .GetValue(p).ToString()
                                .Contains(filterValue.ToString()));
                }
            }
            
            var response  =  customers.ToAsyncEnumerable().ToList();

            return await response;
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            var customer = await _context.Set<Customer>()
                            .FirstOrDefaultAsync(c => c.Email == email);

            return customer;
        }

        public void AddCustomer(Customer customer) => _context.Add(customer);

        public void RemoveCustomer(Customer customer) => _context.Remove(customer);
    }
}
