using Project.Migrations;
using Project.Models;

namespace Project.Utility
{
    public static class Mapper
    {
        public static List<OrderDetail> ConvertToOrderDetail(List<Cart> cart)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();

            foreach (Cart cartItem in cart)
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    ProductId = cartItem.ProductId,
                    Count = cartItem.Count,
                    Price = (double)cartItem.Product.Price,
                    ProductName = cartItem.Product.Name,
                };
                orderDetails.Add(orderDetail);
            }
            return orderDetails;
        }
    }
}
