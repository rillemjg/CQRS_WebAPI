using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos.Additional;
using Events;
using Dtos.Core;
using Domain.com.nicusa.cdc.dev.tpe2;
using Events.Events;

namespace Domain
{
    public class Payment
    {
        private IEventPublisher eventPublisher;
        private List<Product> boughtProducts;
        private string paymentGuid;

        public Payment(IEventPublisher eventPublisher, List<Product> boughtProducts, string paymentGuid)
        {
            this.eventPublisher = eventPublisher;
            this.boughtProducts = boughtProducts;
            this.paymentGuid = paymentGuid;
        }

        public void ProcessPayment(List<ShoppingCartNamedElement> shoppingCartNamedElements)
        {
            this.eventPublisher.Publish(new PaymentBeginEvent()
                                            {
                                                PaymentGuid = paymentGuid
                                            });

            if (shoppingCartNamedElements == null || shoppingCartNamedElements.Count == 0 || boughtProducts.Count == 0)
            {
                this.eventPublisher.Publish(new PaymentFailedEvent()
                    {
                        PaymentGuid = paymentGuid,
                        FailureCode = "EMPTY",
                        FailureMessage = "Shopping cart was empty"
                    });
                return;
            }

            const string merchant = "NEBRTEST";
            const string merchantKey = "NEBRTEST123123";
            const string serviceCode = "OTCTEST";
            const string localReference = "test_002";

            PaymentEngineService paymentEngineService = new PaymentEngineService();
            paymentEngineService.Url = "https://tpe-test.dev.cdc.nicusa.com/paymentengine/services/PaymentEngineService";
            WSOrderContext wsOrderContext = paymentEngineService.makeNewOrder(merchant, merchantKey, serviceCode);
            Orders order = wsOrderContext.order;

            order.localRef = localReference;
            order.originId = 1;

            WSItemsContext wsItemsContext = wsOrderContext.items;
            wsItemsContext.items = new WSItemContext[shoppingCartNamedElements.Count];
            int itemCount = 0;

            foreach (var shoppingCartNamedElement in shoppingCartNamedElements)
            {
                wsItemsContext.items[itemCount] = new WSItemContext();
                wsItemsContext.items[itemCount].item = new Item();
                wsItemsContext.items[itemCount].item.itemTypeId = 1;
                wsItemsContext.items[itemCount].item.itemTypeIdSpecified = true;
                wsItemsContext.items[itemCount].item.itemClassId = 2;
                wsItemsContext.items[itemCount].item.itemClassIdSpecified = true;
                wsItemsContext.items[itemCount].item.sku = shoppingCartNamedElement.ProductName;
                wsItemsContext.items[itemCount].item.instanceId = shoppingCartNamedElement.ProductName + shoppingCartNamedElement.ProductId;
                wsItemsContext.items[itemCount].item.unitPrice =
                    boughtProducts.Single(x => x.Id == shoppingCartNamedElement.ProductId).Price;
                wsItemsContext.items[itemCount].item.unitPriceSpecified = true;
                wsItemsContext.items[itemCount].item.quantity = shoppingCartNamedElement.Quantity;
                wsItemsContext.items[itemCount].item.quantitySpecified = true;
                wsItemsContext.items[itemCount].item.description = shoppingCartNamedElement.ProductName;

                itemCount++;
            }

            WSCustomerContext wsCustomerContext = wsOrderContext.customer;
            Address deliveryAddress = new Address();
            deliveryAddress.zip = "123456";

            wsOrderContext.paymentImplement.type = 1;
            wsOrderContext.paymentImplement.creditCard = new WSCreditCardContext();

            WSCreditCardContext wsCreditCardContext = wsOrderContext.paymentImplement.creditCard;
            wsCreditCardContext.creditCard = new CreditCard();
            wsCreditCardContext.creditCard.nameOnCard = "TOMTOM AIS";
            wsCreditCardContext.creditCard.creditCardTypeId = 1;
            wsCreditCardContext.creditCard.creditCardTypeIdSpecified = true;
            wsCreditCardContext.creditCard.useCustomerAddress = "N";
            wsCreditCardContext.textCardNumber = "4005550000000019";
            wsCreditCardContext.dateExpirationDate = DateTime.Now.AddYears(3);
            wsCreditCardContext.dateExpirationDateSpecified = true;
            wsCreditCardContext.trackData = ";4005550000000019=12105101193010877?9";

            Address billingAddress = new Address();
            billingAddress.address1 = deliveryAddress.address1;
            billingAddress.zip = deliveryAddress.zip;

            wsCreditCardContext.address = billingAddress;

            VerificationsContext verificationsContext = paymentEngineService.submitOrder(merchant, merchantKey,
                                                                                         wsOrderContext);

            if (verificationsContext.response.isFailure)
            {
                this.eventPublisher.Publish(new PaymentFailedEvent()
                                            {
                                                PaymentGuid = paymentGuid,
                                                FailureCode = verificationsContext.response.failureCode,
                                                FailureMessage = verificationsContext.response.failureMessage
                                            });
                return;
            }

            BaseResponse completeOrderResponse = paymentEngineService.completeOrderWithOrderId(merchant, merchantKey,
                                                                                                order.orderId, true);
            if (completeOrderResponse.response.isFailure)
            {               
                this.eventPublisher.Publish(new PaymentFailedEvent()
                                            {
                                                PaymentGuid = paymentGuid,
                                                FailureCode = completeOrderResponse.response.failureCode,
                                                FailureMessage = completeOrderResponse.response.failureMessage
                                            });

                return;
            }

            this.eventPublisher.Publish(new PaymentSucceededEvent()
                                            {
                                                PaymentGuid = paymentGuid
                                            });
        }
    }
}
