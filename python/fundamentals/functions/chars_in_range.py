def all_chars(c1, c2):
    res = []
    for i in range(ord(c1)+1, ord(c2)):
        res.append(chr(i))
    return ' '.join(res)

c1 = input()
c2 = input()

print(all_chars(c1, c2))