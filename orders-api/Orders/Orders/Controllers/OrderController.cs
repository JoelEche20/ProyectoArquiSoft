using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders.Models;
using Orders.Services;

namespace Orders.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception)
            {

                throw new Exception("there where and error with the DB");
            }
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            try
            {
                var order = await this._orderService.GetOrder(id);
                return Ok(order);
            }
            catch (Exception)
            {
                throw new Exception("there where and error with the DB");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postedBook = await this._orderService.CreateOrder(order);
            return Ok(postedBook);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> UpdateOrder(int id, [FromBody] Order order)
        {
            try
            {
                return Ok(await this._orderService.UpdateOrder(id, order));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                return Ok(await this._orderService.DeleteOrder(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }
    }
}
