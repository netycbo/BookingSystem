using BookingSystem;
using BookingSystem.Components.CSV_Reader;
using BookingSystem.Data;
using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;
using BookingSystem.DataProvider;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq.Expressions;

var service = new ServiceCollection();
service.AddSingleton<IApp, App>();
service.AddSingleton<IRepository<RoomBasic>, RepositoryInFile<RoomBasic>>();
service.AddSingleton<IRepository<RoomPremium>, RepositoryInFile<RoomPremium>>();
service.AddSingleton<IRoomManager, RoomManager>();
service.AddSingleton<IRoomProvider, RoomProvider>();
service.AddSingleton<IUserCommunicacion, UserCommunication>();
service.AddSingleton<ICsvReader, CsvReader>();

var serviceProvider = service.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();
app.Run();
