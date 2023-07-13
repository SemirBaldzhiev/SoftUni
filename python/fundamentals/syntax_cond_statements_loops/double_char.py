while True:
    string = input()
    if string == 'End': break
    if string == 'SoftUni': continue
    res = ''
    for c in string:
        res += c
        res += c
    print(res)