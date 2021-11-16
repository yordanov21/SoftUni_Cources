﻿using _01.Loader.Interfaces;
using _01.Loader.Models;
using System;
using System.Collections.Generic;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            IEntity entity = new User(5, 6);
            IEntity invoise = new User(5, 7);

            List<IEntity> entities = new List<IEntity>();
            entities.Add(entity);
            entities.Add(invoise);
            Console.WriteLine(entities.Contains(new StoreClient(5,5)));

            Console.WriteLine(entity.Equals(invoise));
        }
    }
}
