using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store2.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Base = "api/v1/";
        public static class Products
        {
            public const string GetAll = Base + "products";
            public const string GetProduct = Base + "products/{id}";
            public const string AddProduct = Base + "products";
            public const string Update = Base + "products/{id}";
            public const string Delete = Base + "products/{id}";
        }
        public static class Add
        {
            public const string AddUser = Base + "user";
            public const string Login = Base + "user/login";
            public const string GetUser = Base + "user/{email}";
            public const string DeleteUser = Base + "user/{email}";
            public const string UpdateUser = Base + "user/{email}";
        }
    }
}
