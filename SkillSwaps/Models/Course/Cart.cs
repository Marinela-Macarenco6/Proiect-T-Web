using System.Collections.Generic;

namespace SkillSwaps.Models.Courses
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        // Poți adăuga și metode utile:
        public decimal TotalPrice()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Price;
            }
            return total;
        }
    }
}
