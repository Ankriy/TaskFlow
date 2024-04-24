﻿using business.Logic.DataContracts.Repositories;
using business.Logic.DataContracts.Repositories.Customers;
using business.Logic.DataContracts.Repositories.Notes;
using business.Logic.DataContracts.Repositories.Orders;
using business.Logic.Domain.Models.Customer;
using business.Logic.Domain.Models.Notes;
using business.Logic.Domain.Models.NoteTags;
using business.Logic.Domain.Models.Orders;
using business.Logic.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace business.DAL.EF.Repositories
{
    public class EFOrderRepository : IOrderRepository, IRepository<Order>
    {
        private readonly PostgreeContext _context;
        public EFOrderRepository(PostgreeContext context)
        {
            _context = context;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(int userid)
        {
            return _context.Customers.Where(x => x.UserId == userid).Count();
        }

        public Order Create(Order item)
        {
            _context.Orders.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(t => t.Id == id);

            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public Order Get(int id)
        {
            var tag = _context.Orders.FirstOrDefault(x => x.Id == id);
            return tag;
        }

        public ICollection<Order> Get(string search, int skip, int take, int userid)
        {
            IQueryable<Order> query = _context.Orders;

            var users = query
                .OrderBy(p => p.Id)
                .Where(x => x.UserId == userid)
                .Skip(skip)
                .Take(take)
                .ToList();

            return users;
        }

        public void Update(Order item)
        {
            _context.Orders.Update(item);
            _context.SaveChanges();
        }
    }
}