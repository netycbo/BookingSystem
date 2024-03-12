from faker import Faker
import random
import csv

fake = Faker()

class Room:
    def __init__(self,roomId, number_of_beds, private_bathroom, balcony, gym_access, pool_access, kettle, tv, tea_coffee, garden_view, street_view, safe):
        self.roomId=roomId
        
        self.number_of_beds = number_of_beds
        self.private_bathroom = private_bathroom
        self.balcony = balcony
        self.gym_access = gym_access
        self.pool_access = pool_access
        self.kettle = kettle
        self.tv = tv
        self.tea_coffee = tea_coffee
        self.garden_view = garden_view
        self.street_view = street_view
        self.safe = safe
        

def create_room():
    return Room(
        roomId =fake.unique.random_int(min=1, max=100),
        
        number_of_beds=random.randint(1, 5),
        private_bathroom=fake.boolean(chance_of_getting_true=75),
        balcony=fake.boolean(chance_of_getting_true=50),
        gym_access=fake.boolean(chance_of_getting_true=25),
        pool_access=fake.boolean(chance_of_getting_true=25),
        kettle=fake.boolean(chance_of_getting_true=50),
        tv=fake.boolean(chance_of_getting_true=80),
        tea_coffee=fake.boolean(chance_of_getting_true=80),
        garden_view=fake.boolean(chance_of_getting_true=40),
        street_view=fake.boolean(chance_of_getting_true=40),
        safe=fake.boolean(chance_of_getting_true=50),
    )

rooms = [create_room() for _ in range(100)]

with open('rooms_data.csv', 'w', newline='', encoding='utf-8') as file:
    writer = csv.writer(file)
    writer.writerow(['RoomId','NumberOfBeds', 'PrivateBathroom', 'Balcony', 'GymAccess', 'PoolAccess', 'Kettle', 'TV', 'TeaCoffee', 'GardenView', 'StreetView', 'Safe'])
    for room in rooms:
        writer.writerow([
            room.roomId,room.number_of_beds, room.private_bathroom, room.balcony, room.gym_access, room.pool_access,
            room.kettle, room.tv, room.tea_coffee, room.garden_view, room.street_view, room.safe
        ])
