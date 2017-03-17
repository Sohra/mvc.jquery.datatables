﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Mvc.JQuery.DataTables.Example.Domain
{
    static class FakeDatabase
    {
        private static List<User> _users;

        static FakeDatabase()
        {
            var r = new Random();
            var domains = "gmail.com,yahoo.com,hotmail.com".Split(',').ToArray();
            var positions = new List<PositionTypes?>
            {
                null,
                PositionTypes.Engineer,
                PositionTypes.Tester,
                PositionTypes.Manager
            };
            _users = new List<User>(Enumerable.Range(1, 100).Select(i => new User()
            {
                Id = i,
                Email =
                    "user" + i + "@" + domains[i%domains.Length],
                Name = r.Next(6) == 3 ? null : "User" + i,
                Position = positions[i%positions.Count],
                IsAdmin = i%11 == 0,
                Number = (Numbers) r.Next(4),
                Hired =
                    i%8 == 0
                        ? null as DateTime?
                        : DateTime.UtcNow.AddDays(-1*365*3*r.NextDouble()).AddHours(9).AddHours(r.Next(9)),
                Salary =
                    10000 + (DateTime.UtcNow.Minute*1000) +
                    (DateTime.UtcNow.Second*100) +
                    DateTime.UtcNow.Millisecond
            }));

        }

        public static IQueryable<User> Users
        {
            get { return _users.AsQueryable(); }
        }
    }
}