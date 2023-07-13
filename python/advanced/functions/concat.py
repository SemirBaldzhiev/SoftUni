def concatenate(*args, **kwargs):
    res = ''.join(args)
    for k, v in kwargs.items():
        if k in res:
            res = res.replace(k, v)
    return res