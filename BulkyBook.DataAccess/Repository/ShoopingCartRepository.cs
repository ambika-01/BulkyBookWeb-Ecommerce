﻿using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BulkyBook.DataAccess.Repository
{

	public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
{
	private ApplicationDbcontext _db;
	public ShoppingCartRepository(ApplicationDbcontext db) : base(db)
	{
		_db = db;
	}



	public void Update(ShoppingCart obj)
	{
		_db.ShoppingCarts.Update(obj);
	}
}
}
