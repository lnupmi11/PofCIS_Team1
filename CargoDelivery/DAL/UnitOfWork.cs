﻿using System;

using CargoDelivery.Classes;
using CargoDelivery.DAL.Interfaces;

namespace CargoDelivery.DAL
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		public OrderContext Context { get; }
		public GenericRepository<Order> Orders { get; }
		private bool _disposed;

		public UnitOfWork()
		{
			Context = new OrderContext();
			Orders = new GenericRepository<Order>(Context);
		}
		
		public void Save()
		{
			Context.SaveChanges();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					Context.Dispose();
				}
			}

			_disposed = true;
		}
		
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
