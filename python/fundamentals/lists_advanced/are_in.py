def is_substring(el: str, seq: list) -> bool:
    for el2 in seq:
        if el in el2:
            return True


first_seq = [x for x in input().split(', ')]
second_seq = [x for x in input().split(', ')]

res = []
for el in first_seq:
    if is_substring(el, second_seq):
        res.append(el)
print(res)