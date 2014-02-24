using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events.Events;
using Events;

namespace Domain
{
    public class ShoppingCart
    {
        private int productId, currentQuantity;
        private EventPublisher eventPublisher;

        public ShoppingCart(int productId, int currentQuantity)
        {
            this.productId = productId;
            this.currentQuantity = currentQuantity;
            eventPublisher = new EventPublisher();
        }

        public void AddQuantity(int addedQuantity)
        {
            if (currentQuantity + addedQuantity > 20 || currentQuantity + addedQuantity < 0)
            {
                this.eventPublisher.Publish(new QuantityAdditionFailedEvent() { ProductId = this.productId });
            }
            else
            {
                this.eventPublisher.Publish(new QuantityAddedEvent() { ProductId = this.productId, AddedQuantity = addedQuantity });
            }
        }
    }
}
