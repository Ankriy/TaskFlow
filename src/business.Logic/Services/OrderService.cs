﻿using business.Logic.DataContracts.Repositories.Customers;
using business.Logic.DataContracts.Repositories.Notes;
using business.Logic.DataContracts.Repositories.Orders;
using business.Logic.Domain.Models.Customers;
using business.Logic.Domain.Models.Notes;
using business.Logic.Domain.Models.NoteTags;
using business.Logic.Domain.Models.Orders;

namespace business.Logic.Services
{
    public class OrderService
    {
        private IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        
        public int AddOrder(Order order)
        {
            _orderRepository.Create(order);
            return order.Id;
        }
        public Order GetOrder(int id)
        {
            var order = _orderRepository.Get(id);
            return order;
        }
        public OrderList GetOrderList(int skip, int take, int userId)
        {
            var count = _orderRepository.Count(userId);
            var result = new OrderList
            {
                Skip = skip,
                Take = take,
                TotalCount = count
            };
            if (skip > count)
            {
                result.Orders = new List<Order>();
                return result;
            }

            result.Orders = _orderRepository
                .Get("", skip, take, userId)
                .Select(x => new Order()
                {
                    Id = x.Id,
                    CancellationDate = x.CancellationDate,
                    CancellationReason = x.CancellationReason,
                    CustomerId = x.CustomerId,
                    Customer = x.Customer,
                    DeliveryCost = x.DeliveryCost,
                    Description = x.Description,
                    OrderDate = x.OrderDate,
                    OrderStatusId = x.OrderStatusId,
                    OrderStatus = x.OrderStatus,
                    PaymentMethodId = x.PaymentMethodId,
                    PaymentMethod = x.PaymentMethod,
                    TotalCost = x.TotalCost,
                    UserId = x.UserId,
                    User = x.User
                }).ToList();
            return result;
        }
        public object EditOrder(Order order)
        {
            _orderRepository.Update(order);
            return order.Id;
        }
        public void DeleteOrder(int id)
        {
            _orderRepository.Delete(id);
        }
        
    }
}