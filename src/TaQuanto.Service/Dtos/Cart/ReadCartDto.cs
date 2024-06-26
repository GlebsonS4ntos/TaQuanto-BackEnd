﻿using TaQuanto.Service.Dtos.CartProduct;

namespace TaQuanto.Service.Dtos.Cart
{
    public class ReadCartDto
    {
        public Guid Id { get; set; }
        public IEnumerable<ReadCartProductDto>? CartProducts { get; set; }
        public decimal ValueCart { get; set; }
    }
}
