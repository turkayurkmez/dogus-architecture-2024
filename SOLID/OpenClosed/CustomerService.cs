using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosed
{
    //public enum CardType
    //{
    //    Standard,
    //    Silver,
    //    Gold
    //}

    public abstract class CardType
    {
        public abstract decimal GetDiscountedPrice(decimal price);

      
    }

    public class StandardCardType : CardType
    {
        public override decimal GetDiscountedPrice(decimal price)
        {
            return price * .95m;
        }
    }

    public class SilverCardType : CardType
    {
        public override decimal GetDiscountedPrice(decimal price)
        {
            return price * .9m;

        }
    }

    public class GoldCardType : CardType
    {
        public override decimal GetDiscountedPrice(decimal price)
        {
            return price * .85m;

        }
    }

    public class PremiumCard : CardType
    {
        public override decimal GetDiscountedPrice(decimal price)
        {
            return price * .75m;
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public CardType CardType { get; set; }
    }
    public class OrderService
    {
        public Customer Customer { get; set; }
        public decimal GetDiscountedPrice(decimal price)
        {
            //switch (Customer.CardType)
            //{
            //    case CardType.Standard:
            //        return price * .95m;
            //    case CardType.Silver:
            //        return price * .9m;

            //    case CardType.Gold:
            //        return price * .85m;
            //    default:
            //      return price;
            //}
            return Customer.CardType.GetDiscountedPrice(price);


        }
    }
}
