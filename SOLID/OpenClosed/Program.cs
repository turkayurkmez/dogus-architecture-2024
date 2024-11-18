// See https://aka.ms/new-console-template for more information
using OpenClosed;

Console.WriteLine("Hello, World!");
/*
 * Bir nesne gelişime AÇIK değişime KAPALI olmalıdır.
 * 
 */

Customer customer = new Customer() { CardType=new PremiumCard()};
OrderService orderService = new OrderService() { Customer = customer};
var discountedPrice = orderService.GetDiscountedPrice(1000);
Console.WriteLine(discountedPrice.ToString());