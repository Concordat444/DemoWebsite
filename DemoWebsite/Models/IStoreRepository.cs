﻿namespace DemoWebsite.Models
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
    }
}
