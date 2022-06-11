using AutoMapper;
using EvolutionTechTest.Core.DTO;
using EvolutionTechTest.Core.Entities;
using EvolutionTechTest.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionTechTest.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryAsync<Order> _orderRepositoryAsync;
        private readonly IMapper _mapper;

        public OrderService(IRepositoryAsync<Order> orderRepositoryAsync, IMapper mapper)
        {
            _orderRepositoryAsync = orderRepositoryAsync ?? throw new ArgumentNullException(nameof(orderRepositoryAsync));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<OrderDTO> CreateAsync(OrderDTO orderDTO)
        {
            if(orderDTO == null) throw new NullReferenceException();
            Order orderMapped = _mapper.Map<Order>(orderDTO);
            await _orderRepositoryAsync.CreateAsync(orderMapped);
            return orderDTO;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllAsync()
        {
            IEnumerable<Order> orders = await _orderRepositoryAsync.GetAllAsync();

            IEnumerable<OrderDTO> orderDTOs = _mapper.Map<List<OrderDTO>>(orders);
            return orderDTOs;
        }

        public async Task<OrderDTO> GetByIdAsync(int id)
        {
            Order order = await _orderRepositoryAsync.GetByIdAsync(id);
            if (order == null) throw new NullReferenceException();
            OrderDTO orderDTO = _mapper.Map<OrderDTO>(order);
            return orderDTO;
        }

        public async Task RemoveAsync(int id)
        {
            Order order = await _orderRepositoryAsync.GetByIdAsync(id);
            if (order == null) throw new NullReferenceException();
            await _orderRepositoryAsync.RemoveAsync(order);
        }

        public async Task<OrderDTO> UpdateAsync(int id, OrderDTO orderDTO)
        {
            Order order = await _orderRepositoryAsync.GetByIdAsync(id);
            if (order == null) throw new NullReferenceException();

            //orderDTO.Id = id;
            Order orderMapped = _mapper.Map<Order>(orderDTO);
            await _orderRepositoryAsync.UpdateAsync(orderMapped);
            return orderDTO;
        }
    }
}
