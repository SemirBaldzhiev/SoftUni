def main():
    n = int(input())
    stack = list()
    for i in range(n):
        cmds = input().split(' ')
        if cmds[0] == "1":
            stack.append(int(cmds[1]))
        elif cmds[0] == "2":
            if len(stack) > 0:
                stack.pop()
        elif cmds[0]=="3":
            if len(stack) > 0:
                print(max(stack))
        elif cmds[0] == "4":
            if len(stack) > 0:
                print(min(stack))
    stack.reverse()
    print(*stack, sep=", ")
main()