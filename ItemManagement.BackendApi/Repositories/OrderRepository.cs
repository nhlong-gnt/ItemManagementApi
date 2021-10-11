﻿using ItemManagement.Data.Models.Entities;
using ItemManagerment.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ItemManagement.BackendApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ItemManagementDbContext _context;

        public OrderRepository(ItemManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Create(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task Delete(int orderId)
        {
            var orderToDelete = await _context.Orders.FindAsync(orderId);
            _context.Orders.Remove(orderToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrder()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetAOrder(int orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }

        public async Task Update(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}