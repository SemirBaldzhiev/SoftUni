def get_num(word: str) -> int:
    num = 0
    for w in word:
        if w.isdigit():
            num*=10
            num+=int(w)
        else: break
    return num

text = input().split(' ')
res = []
for word in text:
    num = get_num(word)
    word = word.replace(str(num), chr(num), 1)
    curr_word = ''
    curr_word += word[0]
    curr_word += word[len(word)-1]
    curr_word+=word[2:len(word)-1]
    if len(word) > 2:
        curr_word+=word[1]
    res.append(curr_word)
print(' '.join(res))