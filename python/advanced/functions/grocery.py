def grocery_store(**kwargs):
    sorted_store = dict(sorted(kwargs.items(), key=lambda x: (-x[1], -len(x[0]), x[0])))
    res = ''
    for k, v in sorted_store.items():
        res += f'{k}: {v}\n'
    return res