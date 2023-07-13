def func_executor(*args):
    res = ''
    for t in args:
        res += f'{t[0].__name__} - {t[0](*t[1])}\n'
    return res