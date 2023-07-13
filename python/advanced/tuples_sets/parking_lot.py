def main():
    n = int(input())
    parking = set()
    for _ in range(n):
        cmd = input().split(', ')
        if cmd[0] == 'IN':
            parking.add(cmd[1])
        elif cmd[0] == 'OUT':
            if cmd[1] in parking:
                parking.remove(cmd[1])
    if len(parking) == 0:
        print('Parking Lot is Empty')
    else:
        print(*parking, sep='\n')
main()