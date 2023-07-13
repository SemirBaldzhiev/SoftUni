n = int(input())
flag=True
free_chairs = 0
for i in  range(0, n):
    tokens = input().split(' ')
    if len(tokens[0]) < int(tokens[1]):
        flag=False
        print(f'{int(tokens[1])-len(tokens[0])} more chairs needed in room {i+1}')
    else:
        free_chairs += len(tokens[0])-int(tokens[1])
if flag:
    print(f'Game On, {free_chairs} free chairs left')