def sorting_cheeses(**kwargs):
    sorted_kwargs = sorted(kwargs.items(), key = lambda item: (-len(item[1]), item[0]))
    res = []
    for k, v in sorted_kwargs:
        res.append(k)
        sorted_v = sorted(v, reverse=True)
        res += sorted_v
    return '\n'.join([str(x) for x in res])