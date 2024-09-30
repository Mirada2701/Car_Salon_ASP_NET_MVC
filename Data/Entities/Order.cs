﻿namespace Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Car>? Cars { get; set; }
    }

}