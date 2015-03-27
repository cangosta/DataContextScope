﻿using System;
using System.Data.Linq;
using System.Linq;
using Wintouch.EntityFramework.Demo.DomainModel;

namespace Wintouch.EntityFramework.Demo.DatabaseContext
{
  public class UserManagementDbContext : DataContext
	{
    static UserManagementDbContext()
	  {
	    using (UserManagementDbContext context = new UserManagementDbContext())
	    {
	      if (!context.DatabaseExists())
	      {
	        context.CreateDatabase();
	      }
	    }
	  }

    public Table<User> Users
    {
      get
      {
        return GetTable<User>();
      }
    }

    public DataContext DataContext
    {
      get
      {
        return this;
      }
    }

		public UserManagementDbContext() : base("Server=localhost;Database=DbContextScopeDemo;Trusted_Connection=true;")
		{
		}
  }

  public static class UserTableExtensions
  {
    public static User Find(this Table<User> users, Guid userId)
    {
      return users.Single(u => u.Id.CompareTo(userId) == 0);
    }
  }
}
