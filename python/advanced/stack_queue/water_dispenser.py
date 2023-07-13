def main():
    queue = list()
    quantity = int(input())
    while True:
        name = input()
        if name == "Start":
            break
        queue.append(name)

    while True:
        cmds = input().split(" ")

        if cmds[0] == "End":
            break

        if len(cmds) == 1:
            if quantity >= int(cmds[0]):
                quantity -= int(cmds[0])
                print(f"{queue.pop(0)} got water")
            else:
                print(f"{queue.pop(0)} must wait")
        elif len(cmds) == 2 and cmds[0] == "refill":
            quantity += int(cmds[1])
    print(f"{quantity} liters left")
main()