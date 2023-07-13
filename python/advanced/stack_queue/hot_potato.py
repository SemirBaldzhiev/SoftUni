def main():
    people = input().split(' ')
    toss = int(input())
    idx = 1
    while len(people) > 1:
        if idx == toss:
            print(f"Removed {people.pop(0)}")
            idx = 0
        else:
            people.append(people.pop(0))
        idx+=1
    print(f"Last is {people.pop(0)}")
main()