def main():
    queue = list()

    while True:
        name = input()
        if name == "End":
            print(f"{len(queue)} people remaining.")
            break
        elif name == "Paid":
            print(*queue, sep="\n")
            queue.clear()
        else:
            queue.append(name)

main()