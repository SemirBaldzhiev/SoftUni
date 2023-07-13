version = [int(x) for x in input().split('.')]
for i in range(len(version)-1, -1, -1):
    if version[i] == 9:
        version[i] = 0
    else: break
version[i]+=1
print('.'.join([str(x) for x in version]))