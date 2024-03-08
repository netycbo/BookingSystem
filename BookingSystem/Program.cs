using BookingSystem;
using BookingSystem.Components.CSV_Reader;
using BookingSystem.Data;
using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;
using BookingSystem.DataProvider;
using BookingSystem.RoomManagment;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq.Expressions;

var service = new ServiceCollection();
service.AddSingleton<IApp, App>();
//service.AddSingleton<IRepository<RoomBasic>, RepositoryInFile<RoomBasic>>();

service.AddSingleton<IRoomManager, RoomManager>();
service.AddSingleton<IRoomProvider, RoomProvider>();
service.AddSingleton<IUserCommunicacion, UserCommunication>();
service.AddSingleton<ICsvReader, CsvReader>();
service.AddSingleton<IRepository<RoomBasic>, SqlRepository<RoomBasic>>();
service.AddDbContext<BookingSystemContext>(options => options
.UseSqlServer("Data Source=LAPTOP-5N54V80V\\SQLEXPRESS;Initial Catalog=BookingSystemStorage;Integrated Security=True;Trust Server Certificate=True"));

var serviceProvider = service.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();
app.Run();
