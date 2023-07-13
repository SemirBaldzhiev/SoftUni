def main():
    vip = set()
    regular = set()
    n = int(input())
    for _ in range(n):
        num = input()
        if num[0].isdigit():
            vip.add(num)
        else:
            regular.add(num)

    while True:
        num = input()
        if num == 'END':
            break
        if num in vip:
            vip.remove(num)
        elif num in regular:
            regular.remove(num)
    print(len(vip)+len(regular))
    if vip:
        print('\n'.join(sorted(vip)))
    if regular:
        print('\n'.join(sorted(regular)))
main()