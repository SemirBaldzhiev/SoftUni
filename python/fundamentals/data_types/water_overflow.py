n = int(input())
tank = 0
for i in range(0, n):
    water = int(input())
    if tank + water > 255: print('Insufficient capacity!')
    else: tank += water
print(tank)