def main():
    n = int(input())
    names = set()
    for i in range(n):
        name = input()
        names.add(name)
    print(*names, sep="\n")

main()